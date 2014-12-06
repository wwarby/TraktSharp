using System;
using System.Linq;
using System.Windows;
using TraktSharp.Entities;

namespace TraktSharp.Examples.Wpf {

	[Serializable]
	internal class SavedState {

		internal TraktAccessToken AccessToken { get; set; }

		internal string Username { get; set; }

		internal string ClientId { get; set; }

		internal string ClientSecret { get; set; }

		internal string SelectedTestRequestType { get; set; }

		internal int SelectedResponseTab { get; set; }

		internal int SelectedMainTab { get; set; }

		internal string SelectedExtendedOption { get; set; }

		internal string SelectedTextQueryType { get; set; }

		internal string SelectedIdLookupType { get; set; }

		internal string TestId { get; set; }

		internal bool IdLookup { get; set; }

		internal string SearchText { get; set; }

		internal double WindowHeight { get; set; }

		internal double WindowWidth { get; set; }

		internal double WindowLeft { get; set; }

		internal double WindowTop { get; set; }

		internal WindowState WindowState { get; set; }

	}

}