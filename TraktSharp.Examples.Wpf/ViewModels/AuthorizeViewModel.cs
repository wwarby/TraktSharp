using System;
using TraktSharp.Examples.Wpf.Interfaces;

namespace TraktSharp.Examples.Wpf.ViewModels {

	internal class AuthorizeViewModel : ViewModelBase, ICloseable {

		private string _address;

		public bool Completed { get; private set; }

		public event EventHandler<System.EventArgs> RequestClose;

		internal AuthorizeViewModel(TraktClient traktClient) {
			Client = traktClient;
			Address = Client.Authentication.OAuthAuthorizationUri.AbsoluteUri;
		}

		internal TraktClient Client { get; }

		public string Address {
			get => _address;
			set {
				_address = value;
				if (_address.StartsWith(Client.Authentication.OAuthRedirectUri, StringComparison.CurrentCultureIgnoreCase)) {
					HandleCallback(value);
				}
				NotifyPropertyChanged();
			}
		}

		private void HandleCallback(string address) {
			Client.Authentication.ParseOAuthAuthorizationResponse(address);
			Completed = true;
			var handler = RequestClose;
			handler?.Invoke(this, new System.EventArgs());
		}

	}

}