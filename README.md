# TraktSharp

A C# wrapper around Trakt API supporting version 2 of the API at the time of writing. This project is not affiliated in any way with the devs over at Trakt - please do not contact them for support with this library.

This library was written in the early days of the Trakt API and was near feature-complete in terms of API coverage at the time of it's creation. All methods have been tested to some extent, but use at your own risk.

**The project is now in maintenance mode** - I may periodically update it, but I don't personally use it any more because Trakt [stopped serving images](https://apiblog.trakt.tv/trakt-api-images-56b43c356427) (for understandable reasons, but none the less this reduced the usefulness of the API considerably for me).

## Usage

The easiest way to learn how to use TraktSharp is to clone the source and fire up the `TraktSharp.Examples.Wpf` project. This project contains a fairly feature-complete demo of all the features of the solution.

The methods all contain doc comments that describe their functionality, and you can reference the behaviours of the API itself at [Trakt's API documentation](https://trakt.docs.apiary.io). Realistically this is all the documentation there will ever be for this library unless somebody else wants to contribute any. 

## Requirements

To use this library, your project must support .NET Standard 2.0.