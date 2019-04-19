# TraktSharp

A C# wrapper around Trakt API supporting version 2 of the API at the time of writing. This project is not affiliated in any way with the devs over at Trakt - please do not contact them for support with this library.

This library was written in the early days of the Trakt API and was near feature-complete in terms of API coverage at the time of it's creation. All methods have been tested to some extent, but use at your own risk.

**The project will not necessarily receive regular updates**. It was in maintenance mode for a long time because Trakt [stopped serving images](https://apiblog.trakt.tv/trakt-api-images-56b43c356427) (for understandable reasons, but none the less this reduced the usefulness of the API considerably for me). I am now actively using it again in a project, but I do not have the time to devote to actively maintaining features I don't personally use. If you would like to help with maintaining this library, please get in touch.

## Usage

The easiest way to learn how to use TraktSharp is to clone the source and fire up the `TraktSharp.Examples.Wpf` project. This project contains a fairly feature-complete demo of all the features of the solution.

The methods all contain doc comments that describe their functionality, and you can reference the behaviours of the API itself at [Trakt's API documentation](https://trakt.docs.apiary.io). Realistically this is all the documentation there will ever be for this library unless somebody else wants to contribute any. 

## Requirements

To use this library, your project must support .NET Standard 2.0.

## Version History:

- 0.1.0.0 (2014)
  - Initial public release
- 0.2.0.0 (March 2019)
  - Merged updates from @WilliamABradley
  - Code cleanup
  - .netstandard 2.0
- 0.3.0.0 (19th April 2019)
  - Add support for the following APIs:
    - https://api.trakt.tv/movies/anticipated
    - https://api.trakt.tv/movies/boxoffice
    - https://api.trakt.tv/movies/played
    - https://api.trakt.tv/movies/collected
    - https://api.trakt.tv/movies/watched
    - https://api.trakt.tv/shows/anticipated
    - https://api.trakt.tv/shows/played
    - https://api.trakt.tv/shows/collected
    - https://api.trakt.tv/shows/watched
  - Switched to [CefSharp](https://github.com/cefsharp/CefSharp) for authorization workflow in WPF sample app because Trakt was throwing errors in IE (WebBrowser control)
  - Use new C# language features throughout codebase
  - ReSharper rules and coding standards applied
