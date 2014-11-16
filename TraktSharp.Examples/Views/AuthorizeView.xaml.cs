using System;
using System.Linq;
using TraktSharp.Examples.ViewModels;

namespace TraktSharp.Examples.Views {

	public partial class AuthorizeView {

		public AuthorizeViewModel ViewModel { get; set; }

		public AuthorizeView(AuthorizeViewModel viewModel) {
			InitializeComponent();
			ViewModel = viewModel;
			DataContext = ViewModel;
			Load();
		}

		public void Load() {
			AuthorizeBrowser.Navigate(ViewModel.Client.Authentication.AuthorizationUrl);
		}

		private void AuthorizeBrowser_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e) {
			ViewModel.Navigating(this, e);
		}

	}

}