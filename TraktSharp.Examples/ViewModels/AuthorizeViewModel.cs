using System;
using System.Linq;
using System.Reflection;
using Microsoft.Win32;
using TraktSharp.Examples.Views;

namespace TraktSharp.Examples.ViewModels {

	public class AuthorizeViewModel : ViewModelBase {

		public AuthorizeViewModel(TraktClient traktClient) {
			// Teach the WebBrowser control some manners
			NativeMethods.DisableInternetExplorerClickSounds();

			Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION",
				string.Format("{0}.exe", Assembly.GetExecutingAssembly().GetName().Name), 0, RegistryValueKind.DWord);
			Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION",
				string.Format("{0}.vshost.exe", Assembly.GetExecutingAssembly().GetName().Name), 0, RegistryValueKind.DWord);
			
			Client = traktClient;
		}

		public TraktClient Client { get; private set; }

		public async void Navigating(AuthorizeView sender, System.Windows.Navigation.NavigatingCancelEventArgs e) {
			if (!e.Uri.AbsoluteUri.StartsWith(Client.Authentication.RedirectUri, StringComparison.CurrentCultureIgnoreCase)) { return; }
			e.Cancel = true;
			sender.DialogResult = true;
			sender.Close();
			Client.Authentication.ParseAuthorizationResponse(e.Uri);
			await Client.Authentication.GetAccessToken();
		}

	}

}