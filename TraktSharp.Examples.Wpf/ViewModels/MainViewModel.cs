using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;
using TraktSharp.Examples.Wpf.Helpers;
using TraktSharp.Examples.Wpf.Serialization;
using TraktSharp.Examples.Wpf.Views;
using TraktSharp.Exceptions;
using TraktSharp.Helpers;

namespace TraktSharp.Examples.Wpf.ViewModels {

	internal class MainViewModel : ViewModelBase {

		private readonly MainView _view;

		private bool _authenticateIfOptional;

		private bool _idLookup;

		private string _password;

		private string _searchText;

		private TraktExtendedOption _selectedExtendedOption;

		private TraktIdLookupType _selectedIdLookupType;

		private int _selectedMainTab;

		private TraktReportingPeriod _selectedReportingPeriod;

		private int _selectedResponseTab;

		private TestRequests.TestRequestType _selectedTestRequestType;

		private TraktSearchItemType _selectedTextQueryType;

		private string _testId;

		private string _testUsername;

		public MainViewModel() { }

		public MainViewModel(MainView view) {
			_view = view;

			Client = new TraktClient();
			AuthenticationModes = new ObservableCollection<string>(TraktEnumHelper.GetEnumDescriptions(typeof(TraktAuthenticationMode)));
			ExtendedOptions = new ObservableCollection<string>(TraktEnumHelper.GetEnumLabels(typeof(TraktExtendedOption)));
			ReportingPeriods = new ObservableCollection<string>(TraktEnumHelper.GetEnumLabels(typeof(TraktReportingPeriod)));
			TestRequestTypes = new ObservableCollection<string>(TraktEnumHelper.GetEnumDescriptions(typeof(TestRequests.TestRequestType)));
			IdLookupTypes = new ObservableCollection<string>(TraktEnumHelper.GetEnumLabels(typeof(TraktIdLookupType)));
			TextQueryTypes = new ObservableCollection<string>(TraktEnumHelper.GetEnumLabels(typeof(TraktSearchItemType)));
			TryLoadState();
			PropertyChanged += (sender, e) => TrySaveState();

			Client.BeforeRequest += (sender, e) => {
				LastResponse = "Waiting...";
				NotifyPropertyChanged(this.GetMemberName(x => x.LastResponse));

				LastResponseJson = "Waiting...";
				NotifyPropertyChanged(this.GetMemberName(x => x.LastResponseJson));

				LastReturnedValue = "Waiting...";
				NotifyPropertyChanged(this.GetMemberName(x => x.LastReturnedValue));

				var sb = new StringBuilder();
				sb.AppendLine($"{e.Request.Method.ToString().ToUpper()} {e.Request.RequestUri.AbsoluteUri} HTTP/{e.Request.Version}");
				e.Request.Headers.Select(h => $"{h.Key}: {string.Join(",", h.Value)}").ToList().ForEach(l => sb.AppendLine(l));
				sb.AppendLine();
				sb.AppendLine(e.RequestBody);
				LastRequest = sb.ToString();
				NotifyPropertyChanged(this.GetMemberName(x => x.LastRequest));
			};

			Client.AfterRequest += (sender, e) => {
				var sb = new StringBuilder();
				var status = "UNKNOWN STATUS";
				try {
					status = e.Response.Headers.First(h => h.Key.Equals("Status", StringComparison.InvariantCultureIgnoreCase)).Value.First().ToUpper();
				} catch { }

				sb.AppendLine($"HTTP/{e.Response.Version} {status}");
				e.Response.Headers.Select(h => $"{h.Key}: {string.Join(",", h.Value)}").ToList().ForEach(l => sb.AppendLine(l));
				sb.AppendLine();
				sb.AppendLine(e.ResponseText);
				LastResponse = sb.ToString();
				NotifyPropertyChanged(this.GetMemberName(x => x.LastResponse));

				LastResponseJson = !string.IsNullOrEmpty(e.ResponseText) ? PrettyPrint(e.ResponseText) : "The response did not include a body";
				NotifyPropertyChanged(this.GetMemberName(x => x.LastResponseJson));
			};
		}

		private TraktClient Client { get; }

		public string WindowTitle {
			get {
				var ret = new StringBuilder();
				ret.Append("TraktSharp Examples");
				if (Authenticated && (Client.Authentication.AuthenticationMode == TraktAuthenticationMode.OAuth)) {
					ret.Append(" - Authenticated with OAuth");
				}

				if (Authenticated && (Client.Authentication.AuthenticationMode == TraktAuthenticationMode.Simple)) {
					ret.Append(" - Authenticated with Simple Auth");
				}

				if (!Authenticated) {
					ret.Append(" - Not Authenticated");
				}

				return ret.ToString();
			}
		}

		public bool UseSandpit {
			get => Client.Configuration.UseSandpit;
			set {
				Client.Configuration.UseSandpit = value;
				NotifyPropertyChanged();
			}
		}

		public string Username {
			get => Client.Authentication.Username;
			set {
				Client.Authentication.Username = value;
				NotifyPropertyChanged();
			}
		}

		public string ClientId {
			get => Client.Authentication.ClientId;
			set {
				Client.Authentication.ClientId = value;
				NotifyPropertyChanged();
				NotifyPropertyChanged(this.GetMemberName(x => x.CanAuthorize));
			}
		}

		public string ClientSecret {
			get => Client.Authentication.ClientSecret;
			set {
				Client.Authentication.ClientSecret = value;
				NotifyPropertyChanged();
				NotifyPropertyChanged(this.GetMemberName(x => x.CanAuthorize));
			}
		}

		public string AuthorizationCode => Client.Authentication.AuthorizationCode;

		public TraktOAuthAccessToken OAuthAccessToken {
			get => Client.Authentication.CurrentOAuthAccessToken;
			set {
				Client.Authentication.CurrentOAuthAccessToken = value;
				NotifyPropertyChanged();
				NotifyPropertyChanged(this.GetMemberName(x => x.Authenticated));
				NotifyPropertyChanged(this.GetMemberName(x => x.WindowTitle));
				NotifyPropertyChanged(this.GetMemberName(x => x.CanRefreshAccessToken));
				NotifyPropertyChanged(this.GetMemberName(x => x.CanDiscardAccessToken));
			}
		}

		public string LoginUsernameOrEmail {
			get => Client.Authentication.LoginUsernameOrEmail;
			set {
				Client.Authentication.LoginUsernameOrEmail = value;
				NotifyPropertyChanged();
				NotifyPropertyChanged(this.GetMemberName(x => x.Authenticated));
				NotifyPropertyChanged(this.GetMemberName(x => x.WindowTitle));
				NotifyPropertyChanged(this.GetMemberName(x => x.CanLogin));
			}
		}

		public string Password {
			get => _password;
			set {
				_password = value;
				NotifyPropertyChanged();
				NotifyPropertyChanged(this.GetMemberName(x => x.CanLogin));
			}
		}

		public string SimpleAccessToken {
			get => Client.Authentication.CurrentSimpleAccessToken;
			set {
				Client.Authentication.CurrentSimpleAccessToken = value;
				NotifyPropertyChanged();
				NotifyPropertyChanged(this.GetMemberName(x => x.Authenticated));
				NotifyPropertyChanged(this.GetMemberName(x => x.WindowTitle));
				NotifyPropertyChanged(this.GetMemberName(x => x.CanLogout));
			}
		}

		public bool Authenticated => Client.Authentication.Authenticated;

		public string LastRequest { get; private set; }

		public string LastResponse { get; private set; }

		public string LastResponseJson { get; private set; }

		public string LastReturnedValue { get; private set; }

		public ObservableCollection<string> AuthenticationModes { get; set; }

		public string SelectedAuthenticationMode {
			get => TraktEnumHelper.GetLabel(Client.Authentication.AuthenticationMode);
			set {
				Client.Authentication.AuthenticationMode = TraktEnumHelper.FromLabel<TraktAuthenticationMode>(value);
				NotifyPropertyChanged();
				NotifyPropertyChanged(this.GetMemberName(x => x.Authenticated));
				NotifyPropertyChanged(this.GetMemberName(x => x.WindowTitle));
				NotifyPropertyChanged(this.GetMemberName(x => x.IsOAuthAuthenticationMode));
				NotifyPropertyChanged(this.GetMemberName(x => x.IsSimpleAuthenticationMode));
			}
		}

		public bool IsOAuthAuthenticationMode => Client.Authentication.AuthenticationMode == TraktAuthenticationMode.OAuth;

		public bool IsSimpleAuthenticationMode => Client.Authentication.AuthenticationMode == TraktAuthenticationMode.Simple;

		public ObservableCollection<string> ExtendedOptions { get; set; }

		public ObservableCollection<string> ReportingPeriods { get; set; }

		public string SelectedExtendedOption {
			get => TraktEnumHelper.GetLabel(_selectedExtendedOption);
			set {
				_selectedExtendedOption = TraktEnumHelper.FromLabel<TraktExtendedOption>(value);
				NotifyPropertyChanged();
			}
		}

		public string SelectedReportingPeriod {
			get => TraktEnumHelper.GetLabel(_selectedReportingPeriod);
			set {
				_selectedReportingPeriod = TraktEnumHelper.FromLabel<TraktReportingPeriod>(value);
				NotifyPropertyChanged();
			}
		}

		public ObservableCollection<string> TestRequestTypes { get; set; }

		public string SelectedTestRequestType {
			get => TraktEnumHelper.GetDescription(_selectedTestRequestType);
			set {
				_selectedTestRequestType = TraktEnumHelper.FromDescription<TestRequests.TestRequestType>(value);
				NotifyPropertyChanged();
			}
		}

		public ObservableCollection<string> TextQueryTypes { get; set; }

		public string SelectedTextQueryType {
			get => TraktEnumHelper.GetLabel(_selectedTextQueryType);
			set {
				_selectedTextQueryType = TraktEnumHelper.FromLabel<TraktSearchItemType>(value);
				NotifyPropertyChanged();
			}
		}

		public ObservableCollection<string> IdLookupTypes { get; set; }

		public string SelectedIdLookupType {
			get => TraktEnumHelper.GetLabel(_selectedIdLookupType);
			set {
				_selectedIdLookupType = TraktEnumHelper.FromLabel<TraktIdLookupType>(value);
				NotifyPropertyChanged();
			}
		}

		public int SelectedMainTab {
			get => _selectedMainTab;
			set {
				_selectedMainTab = value;
				NotifyPropertyChanged();
			}
		}

		public int SelectedResponseTab {
			get => _selectedResponseTab;
			set {
				_selectedResponseTab = value;
				NotifyPropertyChanged();
			}
		}

		public string SearchText {
			get => _searchText;
			set {
				_searchText = value;
				NotifyPropertyChanged();
				NotifyPropertyChanged(this.GetMemberName(x => x.CanSearch));
			}
		}

		public bool IdLookup {
			get => _idLookup;
			set {
				_idLookup = value;
				NotifyPropertyChanged();
				NotifyPropertyChanged(this.GetMemberName(x => x.CanSearch));
			}
		}

		public string TestId {
			get => _testId;
			set {
				_testId = value;
				NotifyPropertyChanged();
			}
		}

		public string TestUsername {
			get => _testUsername;
			set {
				_testUsername = value;
				NotifyPropertyChanged();
			}
		}

		public bool AuthenticateIfOptional {
			get => _authenticateIfOptional;
			set {
				_authenticateIfOptional = value;
				NotifyPropertyChanged();
			}
		}

		public object CanAuthorize => !string.IsNullOrEmpty(ClientId) && !string.IsNullOrEmpty(ClientSecret);

		public object CanRefreshAccessToken => (OAuthAccessToken != null) && OAuthAccessToken.IsValid;

		public object CanDiscardAccessToken => (OAuthAccessToken != null) && OAuthAccessToken.IsValid;

		public object CanLogin => !string.IsNullOrEmpty(LoginUsernameOrEmail) && !string.IsNullOrEmpty(Password);

		public object CanLogout => !string.IsNullOrEmpty(SimpleAccessToken);

		public object CanSearch => !string.IsNullOrEmpty(SearchText);

		public static string StateSerializationPath {
			get {
				var assemblyPath = Assembly.GetExecutingAssembly().Location;
				return Path.Combine(Path.GetDirectoryName(assemblyPath) ?? string.Empty, $"{Path.GetFileNameWithoutExtension(assemblyPath)}.state");
			}
		}

		public async void Authorize() {
			var authorizeViewModel = new AuthorizeViewModel(Client);
			var window = new AuthorizeView(authorizeViewModel);
			window.ShowDialog();
			NotifyPropertyChanged(this.GetMemberName(x => x.AuthorizationCode));
			OAuthAccessToken = await Client.Authentication.GetOAuthAccessToken();
		}

		public async void RefreshAccessToken() { await Client.Authentication.RefreshOAuthAccessToken(); }

		public void DiscardAccessToken() { Client.Authentication.OAuthLogout(); }

		public async void Login() {
			SimpleAccessToken = string.Empty;
			SimpleAccessToken = await Client.Authentication.LoginAsync(LoginUsernameOrEmail, Password);
		}

		public async void Logout() {
			await Client.Authentication.LogoutAsync();
			SimpleAccessToken = string.Empty;
		}

		public async void TestRequest() {
			object result;
			try {
				result = await TestRequests.ExecuteTestRequest(
					Client,
					_selectedTestRequestType,
					_selectedExtendedOption,
					TraktEnumHelper.FromLabel<TraktReportingPeriod>(SelectedReportingPeriod),
					!string.IsNullOrEmpty(TestId) ? TestId : null,
					!string.IsNullOrEmpty(TestUsername) ? TestUsername : null,
					AuthenticateIfOptional);
			} catch (Exception ex) {
				result = ex;
			}

			UpdateLastReturnValue(result);
		}

		public async void Search() {
			object result;
			try {
				if (IdLookup) {
					result = await Client.Search.IdLookupAsync(SearchText, _selectedIdLookupType, _selectedExtendedOption);
				} else {
					result = await Client.Search.TextQueryAsync(SearchText, _selectedTextQueryType, _selectedExtendedOption);
				}
			} catch (Exception ex) {
				result = ex;
			}

			UpdateLastReturnValue(result);
		}

		public void Closing() { TrySaveState(); }

		public void TryLoadState() {
			try {
				var result = JsonConvert.DeserializeObject<SavedState>(File.ReadAllText(StateSerializationPath));
				if ((result.WindowWidth > 0) && (result.WindowHeight > 0)) {
					if (result.WindowHeight > _view.MinHeight) {
						_view.Height = result.WindowHeight;
					}

					if (result.WindowWidth > _view.MinWidth) {
						_view.Width = result.WindowWidth;
					}

					_view.Left = result.WindowLeft;
					_view.Top = result.WindowTop;
					_view.WindowState = result.WindowState;
				}

				OAuthAccessToken = result.OAuthAccessToken;
				SimpleAccessToken = result.SimpleAccessToken;
				Username = result.Username;
				UseSandpit = result.UseSandpit;
				ClientId = result.ClientId;
				ClientSecret = result.ClientSecret;
				LoginUsernameOrEmail = result.LoginUsernameOrEmail;
				SelectedAuthenticationMode = result.SelectedAuthenticationMode;
				SelectedMainTab = result.SelectedMainTab;
				SelectedResponseTab = result.SelectedResponseTab;
				SelectedExtendedOption = result.SelectedExtendedOption;
				SelectedReportingPeriod = result.SelectedReportingPeriod;
				SelectedTextQueryType = result.SelectedTextQueryType;
				SelectedIdLookupType = result.SelectedIdLookupType;
				SelectedTestRequestType = result.SelectedTestRequestType;
				TestId = result.TestId;
				TestUsername = result.TestUsername;
				AuthenticateIfOptional = result.AuthenticateIfOptional;
				IdLookup = result.IdLookup;
				SearchText = result.SearchText;
			} catch { }
		}

		public void TrySaveState() {
			try {
				FileSystemHelper.EnsureParentDirectoryExists(StateSerializationPath);
				File.WriteAllText(StateSerializationPath,
					JsonConvert.SerializeObject(new SavedState {
							WindowHeight = _view.Height,
							WindowWidth = _view.Width,
							WindowLeft = _view.Left,
							WindowTop = _view.Top,
							WindowState = _view.WindowState,
							OAuthAccessToken = OAuthAccessToken,
							SimpleAccessToken = SimpleAccessToken,
							UseSandpit = UseSandpit,
							Username = Username,
							ClientId = ClientId,
							ClientSecret = ClientSecret,
							LoginUsernameOrEmail = LoginUsernameOrEmail,
							SelectedAuthenticationMode = SelectedAuthenticationMode,
							SelectedMainTab = SelectedMainTab,
							SelectedResponseTab = SelectedResponseTab,
							SelectedExtendedOption = SelectedExtendedOption,
							SelectedReportingPeriod = SelectedReportingPeriod,
							SelectedTestRequestType = SelectedTestRequestType,
							SelectedTextQueryType = SelectedTextQueryType,
							SelectedIdLookupType = SelectedIdLookupType,
							TestId = TestId,
							TestUsername = TestUsername,
							AuthenticateIfOptional = AuthenticateIfOptional,
							IdLookup = IdLookup,
							SearchText = SearchText
						},
						Formatting.Indented),
					Encoding.UTF8);
			} catch { }
		}

		public void UpdateLastReturnValue(object value) {
			var sb = new StringBuilder();
			if (value != null) {
				sb.AppendLine(value.GetType().ToString());
				sb.AppendLine();
				sb.AppendLine(PrettyPrint(value));
			} else {
				sb.AppendLine("This method does not have a return value");
			}

			LastReturnedValue = sb.ToString();
			NotifyPropertyChanged(this.GetMemberName(x => x.LastReturnedValue));
			if (value is Exception) {
				SelectedResponseTab = 3;
			}
		}

		private string PrettyPrint(string json) {
			try {
				return PrettyPrint(JArray.Parse(json));
			} catch { }

			try {
				return PrettyPrint(JObject.Parse(json));
			} catch { }

			return string.Empty;
		}

		private string PrettyPrint(object obj) {
			try {
				if (obj is Exception ex) {
					var sb = new StringBuilder();
					sb.AppendLine($"Message: {ex.Message}");
					sb.AppendLine($"Source: {ex.Source}");
					if (ex is TraktException traktEx) {
						sb.AppendLine($"Trakt Error Type: {traktEx.TraktErrorType}");
						if (ex is TraktConflictException traktConflictEx) {
							sb.AppendLine($"Expires At: {traktConflictEx.ExpiresAt}");
						}
					}

					sb.AppendLine();
					sb.AppendLine($"Stack Trace:\r\n\r\n{ex.StackTrace}");
					if (ex.InnerException != null) {
						sb.AppendLine($"Inner Exception Message: {ex.InnerException.Message}");
						sb.AppendLine($"Inner Exception Source: {ex.InnerException.Source}");
						sb.AppendLine();
						sb.AppendLine($"Inner Exception Stack Trace:\r\n\r\n{ex.InnerException.StackTrace}");
					}

					return sb.ToString();
				}

				return JsonConvert.SerializeObject(obj,
					new JsonSerializerSettings {
						Formatting = Formatting.Indented,
						ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
						ContractResolver = new OriginalPropertyNamesContractResolver {IgnoreSerializableInterface = true, IgnoreSerializableAttribute = true}
					});
			} catch { }

			return string.Empty;
		}

	}

}