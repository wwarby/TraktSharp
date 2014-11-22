using System;
using System.Linq;
using System.Windows;
using TraktSharp.Examples.ViewModels;

namespace TraktSharp.Examples.Views {

	public partial class MainView {

		public MainViewModel ViewModel { get; set; }

		public MainView() {
			InitializeComponent();
			ViewModel = new MainViewModel();
			DataContext = ViewModel;
		}

		private void Authorize_Click(object sender, RoutedEventArgs e) { ViewModel.Authorize(); }

		private void TestRequest_Click(object sender, RoutedEventArgs e) { ViewModel.TestRequest(); }

	}

}