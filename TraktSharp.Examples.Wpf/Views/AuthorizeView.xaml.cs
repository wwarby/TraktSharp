using System;
using System.Linq;
using System.Windows.Navigation;
using TraktSharp.Examples.Wpf.ViewModels;

namespace TraktSharp.Examples.Wpf.Views {

	public partial class AuthorizeView {

		public AuthorizeViewModel ViewModel { get; set; }

		public AuthorizeView(AuthorizeViewModel viewModel) {
			InitializeComponent();
			ViewModel = viewModel;
			DataContext = ViewModel;
			Load();
		}

		public void Load() { AuthorizeBrowser.Navigate(ViewModel.Client.Authentication.AuthorizationUrl); }

		private void AuthorizeBrowserNavigating(object sender, NavigatingCancelEventArgs e) { ViewModel.Navigating(this, e); }

	}

}