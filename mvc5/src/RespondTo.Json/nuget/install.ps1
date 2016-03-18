param($installPath, $toolsPath, $package, $project)

$name = "RespondToJson"
$extension = "json"

$webConfig = $project.ProjectItems | where {$_.Name -eq "Web.config"}
$webConfigPath = ($webConfig.Properties | where {$_.Name -eq "LocalPath"}).Value

$webConfigXml = New-Object xml
$webConfigXml.Load($webConfigPath)
$configuration = $webConfigXml.SelectNodes("//*") | where { $_.Name -eq "configuration" }

if($configuration -eq $null)
{
	break
}

$webServer = $configuration.SelectNodes("//*") | where { $_.Name -eq "system.webServer" }
	
if($webServer -eq $null)
{
	$webServer = $webConfigXml.CreateNode("element", "system.webServer", "")
	$configuration.AppendChild($webServer)
}

$handlers = $webServer.SelectNodes("//*") | where { $_.Name -eq "handlers" }

if($handlers -eq $null)
{
	$handlers = $webConfigXml.CreateNode("element", "handlers", "")
	$webServer.AppendChild($handlers)
}

$respondTo = $handlers.SelectSingleNode("//add[@name='$name']")

if($respondTo -eq $null)
{
	$respondTo = $webConfigXml.CreateNode("element", "add", "")
	$respondTo.SetAttribute("name", $name)
	$respondTo.SetAttribute("path", "*.$extension")
	$respondTo.SetAttribute("verb", "GET")
	$respondTo.SetAttribute("type", "System.Web.Handlers.TransferRequestHandler")
	$respondTo.SetAttribute("preCondition", "integratedMode,runtimeVersionv4.0")
	$handlers.AppendChild($respondTo)
}

$webConfigXml.Save($webConfigPath)