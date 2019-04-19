using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using TraktSharp.Examples.Wpf.ViewModels;

namespace TraktSharp.Examples.Wpf.Views {

	internal partial class MainView {

		private MainViewModel ViewModel { get; }

		public MainView() {
			InitializeComponent();
			ViewModel = new MainViewModel(this);
			DataContext = ViewModel;
		}

		private void AuthorizeClick(object sender, RoutedEventArgs e) { ViewModel.Authorize(); }

		private void RefreshAccessTokenClick(object sender, RoutedEventArgs e) { ViewModel.RefreshAccessToken(); }

		private void DiscardAccessTokenClick(object sender, RoutedEventArgs e) { ViewModel.DiscardAccessToken(); }

		private void LoginClick(object sender, RoutedEventArgs e) { ViewModel.Login(); }

		private void LogoutClick(object sender, RoutedEventArgs e) { ViewModel.Logout(); }

		private void TestRequestClick(object sender, RoutedEventArgs e) { ViewModel.TestRequest(); }

		private void SearchClick(object sender, RoutedEventArgs e) { ViewModel.Search(); }

		private void WindowClosing(object sender, CancelEventArgs e) { ViewModel.Closing(); }

		private void SettingsKeyDown(object sender, KeyEventArgs e) {
			if (e.Key == Key.Return) { ViewModel.TestRequest(); }
		}

		private void SearchKeyDown(object sender, KeyEventArgs e) {
			if (e.Key == Key.Return) { ViewModel.Search(); }
		}

	}

}