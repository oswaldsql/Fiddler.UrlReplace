# Documentation

Fiddler Bulk UrlReplace is an extension of the urlreplace functionality already present in [Fiddler](https://www.telerik.com/support/fiddler)

Fiddler2’s UrlReplace lets you change URL’s on the fly transparent to most browser and many other programs using the net. This plugin extends this functionality in the following arrears.

* **Multiple replaces**: Allows you to specify a set of search/replace parameters and specify the order in which they should execute
* **Persistence** : Saves your settings from session to session
* **Load/Save** : Lets you load and save settings file for sharing
* **Logging** : Lets you see which URL’s were replaces by which search/replace items
* **[UI](UI.md)** : Presents a UI for creating and maintaining search/replace items
* **[Command line interface](CommandLineInterface.md)**: Extends the existing Comman line interface with new commands while respecting the [existing functionality](https://docs.telerik.com/fiddler/knowledgebase/quickexec)
* **Extended search options**
  * **Host only** : Searches only the host part of the URL
  * **Regular expressions** : Allows you to use regular expressions when searching/replacing
  * **Case sensitive/insensitive** : Allows you to make case sensitive replaces

See the [Examples](Examples.md) for at deeper wall through of the options

## Installation

Simply download the Plugin from [release:37448](release_37448) and place the plugin files (UrlReplace.dll and UrlReplace.Core.dll) in Fiddler's Scripts folder usually located at %USERPROFILE%\AppData\Local\Programs\Fiddler\Scripts\