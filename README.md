# An easy way to respond in different types
Since I've seen RoR respond_to I always wanted a way to do this multiple response type from an Action, that's why I've created RespondTo

With RespondTo is possible to customize outputs for actions with minimal effort.

##Description
RespondTo works with extensions, so if you want to output json files, its necessary to use the json extension, for xml the xml extension and so forth.
After an extension installed and registered actions will start to respond models as based on url extension or Accept headers.

##Installation
    Install-Package RespondTo
Since RespondTo works with extensions, only this package isn't enough, is necessary to install an extension or create your own.  

Currently exists two extensions:
* RespondTo.Json
* RespondTo.Xml

##Usage
To use RespondTo is necessary just register extensions on your startup code, ex:

    using Route = RespondTo.Route;
    ...
    Route.RespondTo.Json().Register();
    //or register xml
    Route.RespondTo.Xml().Register();
    //or even register multiple extensions
    Route.RespondTo.Json().Xml().Register();
