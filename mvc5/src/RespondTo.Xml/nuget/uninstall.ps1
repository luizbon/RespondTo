param($installPath, $toolsPath, $package, $project)

$name = "RespondToXml"

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
	break
}

$handlers = $webServer.SelectNodes("//*") | where { $_.Name -eq "handlers" }

if($handlers -eq $null)
{
	break
}

$respondTo = $handlers.SelectSingleNode("//add[@name='$name']")

if($respondTo -eq $null)
{
	break
}

$handlers.RemoveChild($respondTo)

$webConfigXml.Save($webConfigPath)