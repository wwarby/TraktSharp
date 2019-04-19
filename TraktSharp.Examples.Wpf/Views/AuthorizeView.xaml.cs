using TraktSharp.Examples.Wpf.Interfaces;
using TraktSharp.Examples.Wpf.ViewModels;

namespace TraktSharp.Examples.Wpf.Views {

	internal partial class AuthorizeView {

		public AuthorizeView(AuthorizeViewModel viewModel) {
			InitializeComponent();
			ViewModel = viewModel;
			DataContext = ViewModel;
			Loaded += (s, e) => {
				if (DataContext is ICloseable closeable) {
					closeable.RequestClose += (_, __) => Close();
				}
				AuthorizationBrowser.Focus();
			};
		}


		private AuthorizeViewModel ViewModel { get; }

	}

}