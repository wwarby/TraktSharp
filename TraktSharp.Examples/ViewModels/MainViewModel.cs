using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TraktSharp.Entities;
using TraktSharp.Examples.Views;
using TraktSharp.Helpers;

namespace TraktSharp.Examples.ViewModels {

	public class MainViewModel : ViewModelBase {

		public MainViewModel() {
			
			Client = new TraktClient();
			TryLoadState();
			PropertyChanged += (sender, e) => TrySaveState();

			Client.BeforeRequest += (sender, e) => {
				
				LastResponse = "Waiting...";
				NotifyPropertyChanged("LastResponse");

				LastResponseJson = "Waiting...";
				NotifyPropertyChanged("LastResponseJson");

				LastReturnedObject = "Waiting...";
				NotifyPropertyChanged("LastReturnedObject");

				var sb = new StringBuilder();
				sb.AppendLine(string.Format("{0} {1} HTTP/{2}", e.Request.Method.ToString().ToUpper(), e.Request.RequestUri.AbsoluteUri, e.Request.Version));
				e.Request.Headers.Select(h => string.Format("{0}: {1}", h.Key, string.Join(",", h.Value))).ToList().ForEach(l => sb.AppendLine(l));
				sb.AppendLine();
				sb.AppendLine(e.RequestBody);
				LastRequest = sb.ToString();
				NotifyPropertyChanged("LastRequest");

			};

			Client.AfterRequest += (sender, e) => {
				
				var sb = new StringBuilder();
				sb.AppendLine(string.Format("HTTP/{0} {1} {2}",
					e.Response.Version,
					((int)e.Response.StatusCode).ToString(CultureInfo.InvariantCulture),
					e.Response.StatusCode.ToString().ToUpper()));
				e.Response.Headers.Select(h => string.Format("{0}: {1}", h.Key, string.Join(",", h.Value))).ToList().ForEach(l => sb.AppendLine(l));
				sb.AppendLine();
				sb.AppendLine(e.ResponseText);
				LastResponse = sb.ToString();
				NotifyPropertyChanged("LastResponse");

				LastResponseJson = PrettyPrintJson(e.ResponseText);
				NotifyPropertyChanged("LastResponseJson");

			};

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

		public string LastRequest { get; private set; }

		public string LastResponse { get; private set; }

		public string LastResponseJson { get; private set; }

		public string LastReturnedObject { get; private set; }

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
			NotifyPropertyChanged("AuthorizationCode");
			NotifyPropertyChanged("AccessToken");
		}

		public async void TestRequest() {
			var result = await RunTestRequest();
			LastReturnedObject = PrettyPrintJson(result);
			NotifyPropertyChanged("LastReturnedObject");
		}

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

		private string PrettyPrintJson(object obj) {
			try { return JsonConvert.SerializeObject(obj, Formatting.Indented); } catch { }
			return string.Empty;
		}

		private string PrettyPrintJson(string json) {
			try { return JsonConvert.SerializeObject(JArray.Parse(json), Formatting.Indented); } catch { }
			try { return JsonConvert.SerializeObject(JObject.Parse(json), Formatting.Indented); } catch { }
			return string.Empty;
		}

		private async Task<object> RunTestRequest() {
			return await Client.Genres.GetGenresAsync(GenreTypeOptions.Movies);
		}

	}

}