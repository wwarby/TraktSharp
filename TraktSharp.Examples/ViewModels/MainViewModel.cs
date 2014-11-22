using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using TraktSharp.Entities;
using TraktSharp.Examples.Helpers;
using TraktSharp.Examples.Views;
using TraktSharp.Helpers;

namespace TraktSharp.Examples.ViewModels {

	public class MainViewModel : ViewModelBase {

		public MainViewModel() {
			Client = new TraktClient();
			TryLoadState();
			PropertyChanged += OnPropertyChanged;
		}

		public TraktClient Client { get; private set; }

		public string Username {
			get { return Client.Authentication.Username; }
			set {
				Client.Authentication.Username = value;
				NotifyPropertyChanged();
			}
		}

		public string ClientId {
			get { return Client.Authentication.ClientId; }
			set {
				Client.Authentication.ClientId = value;
				NotifyPropertyChanged();
			}
		}

		public string ClientSecret {
			get { return Client.Authentication.ClientSecret; }
			set {
				Client.Authentication.ClientSecret = value;
				NotifyPropertyChanged();
			}
		}

		public string AuthorizationCode { get { return Client.Authentication.AuthorizationCode; } }

		public TraktAccessToken AccessToken {
			get { return Client.Authentication.CurrentAccessToken; }
			set {
				Client.Authentication.CurrentAccessToken = value;
				NotifyPropertyChanged();
			}
		}

		public void Authorize() {
			var authorizeViewModel = new AuthorizeViewModel(Client);
			var window = new AuthorizeView(authorizeViewModel);
			window.ShowDialog();
			NotifyPropertyChanged(this.GetMemberName(x => x.AuthorizationCode));
			NotifyPropertyChanged(this.GetMemberName(x => x.AccessToken));
		}

		public async void TestRequest() {
			var result = await Client.Calendars.MoviesAsync();
			Debugger.Break();
		}

		private void OnPropertyChanged(object sender, PropertyChangedEventArgs e) { TrySaveState(); }

		public static string StateSerializationPath {
			get {
				var assemblyPath = Assembly.GetExecutingAssembly().Location;
				return Path.Combine(Path.GetDirectoryName(assemblyPath), string.Format("{0}.state", Path.GetFileNameWithoutExtension(assemblyPath)));
			}
		}

		public void TryLoadState() {
			try {
				var result = JsonConvert.DeserializeObject<SavedState>(File.ReadAllText(StateSerializationPath));
				AccessToken = result.AccessToken;
				Username = result.Username;
				ClientId = result.ClientId;
				ClientSecret = result.ClientSecret;
			} catch {}
		}

		public void TrySaveState() {
			try {
				FileSystemHelper.EnsureParentDirectoryExists(StateSerializationPath);
				File.WriteAllText(StateSerializationPath, JsonConvert.SerializeObject(new SavedState {
					AccessToken = AccessToken,
					Username = Username,
					ClientId = ClientId,
					ClientSecret = ClientSecret
				}, Formatting.Indented), Encoding.UTF8);
			} catch {}
		}

	}

}