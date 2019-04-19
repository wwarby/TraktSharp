using System;
using System.Linq;
using System.Windows.Navigation;
using TraktSharp.Examples.Wpf.ViewModels;

namespace TraktSharp.Examples.Wpf.Views {

	internal partial class AuthorizeView {

		public AuthorizeView(AuthorizeViewModel viewModel) {
			InitializeComponent();
			ViewModel = viewModel;
			DataContext = ViewModel;
			Load();
		}

		private AuthorizeViewModel ViewModel { get; }

		private void Load() { AuthorizeBrowser.Navigate(ViewModel.Client.Authentication.OAuthAuthorizationUri); }

		private void AuthorizeBrowserNavigating(object sender, NavigatingCancelEventArgs e) { ViewModel.Navigating(this, e); }

	}

}