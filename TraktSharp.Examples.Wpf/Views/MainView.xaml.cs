using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using TraktSharp.Examples.Wpf.ViewModels;

namespace TraktSharp.Examples.Wpf.Views {

	public partial class MainView {

		public MainViewModel ViewModel { get; set; }

		public MainView() {
			InitializeComponent();
			ViewModel = new MainViewModel(this);
			DataContext = ViewModel;
		}

		private void AuthorizeClick(object sender, RoutedEventArgs e) { ViewModel.Authorize(); }

		private void TestRequestClick(object sender, RoutedEventArgs e) { ViewModel.TestRequest(); }

		private void SearchClick(object sender, RoutedEventArgs e) { ViewModel.Search(); }

		private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e) { ViewModel.Closing(); }

		private void TestIdKeyDown(object sender, KeyEventArgs e) {
			if (e.Key == Key.Return) { ViewModel.TestRequest(); }
		}

		private void SearchKeyDown(object sender, KeyEventArgs e) {
			if (e.Key == Key.Return) { ViewModel.Search(); }
		}

	}

}