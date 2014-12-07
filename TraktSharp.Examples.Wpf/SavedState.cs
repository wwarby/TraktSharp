using System;
using System.Linq;
using System.Windows;
using TraktSharp.Entities;

namespace TraktSharp.Examples.Wpf {

	[Serializable]
	internal class SavedState {

		public TraktOAuthAccessToken AccessToken { get; set; }

		public string Username { get; set; }

		public string ClientId { get; set; }

		public string ClientSecret { get; set; }

		public string LoginUsernameOrEmail { get; set; }

		public string SelectedTestRequestType { get; set; }

		public string SelectedAuthenticationMode { get; set; }

		public int SelectedMainTab { get; set; }

		public int SelectedResponseTab { get; set; }

		public string SelectedExtendedOption { get; set; }

		public string SelectedTextQueryType { get; set; }

		public string SelectedIdLookupType { get; set; }

		public string TestId { get; set; }

		public bool IdLookup { get; set; }

		public string SearchText { get; set; }

		public double WindowHeight { get; set; }

		public double WindowWidth { get; set; }

		public double WindowLeft { get; set; }

		public double WindowTop { get; set; }

		public WindowState WindowState { get; set; }

	}

}