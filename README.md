# RespondTo
An easy way to have multiple outputs from your ordinary actions

With RespondTo is possible to get customized outputs for every action in a project with minimal effort.

So far it has two output implementations (JSON and XML) and they can be installed via Nuget.

### Install-Package RespondTo.Json
### Install-Package RespondTo.Xml

After instalation its necessary to register routes putting one line of code in initialization.

#### Route.RespondTo.Json().Register()
#### Route.RespondTo.Xml().Register()
#### Route.RespondTo.Json().Xml().Register()
