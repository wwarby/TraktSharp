using System;
using System.Linq;
using System.Reflection;
using System.Windows.Navigation;
using Microsoft.Win32;
using TraktSharp.Examples.Wpf.Views;

namespace TraktSharp.Examples.Wpf.ViewModels {

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

		public void Navigating(AuthorizeView sender, NavigatingCancelEventArgs e) {
			if (!e.Uri.AbsoluteUri.StartsWith(Client.Authentication.RedirectUri, StringComparison.CurrentCultureIgnoreCase)) {
				return;
			}
			Client.Authentication.ParseAuthorizationResponse(e.Uri);
			e.Cancel = true;
			sender.DialogResult = true;
			sender.Close();
		}

	}

}