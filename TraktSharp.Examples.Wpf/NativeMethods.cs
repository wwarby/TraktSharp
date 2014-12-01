using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace TraktSharp.Examples.Wpf {

	public static class NativeMethods {

		private const int FEATURE_DISABLE_NAVIGATION_SOUNDS = 21;
		private const int SET_FEATURE_ON_PROCESS = 0x00000002;

		[DllImport("urlmon.dll"), PreserveSig]
		[return: MarshalAs(UnmanagedType.Error)]
		private static extern int CoInternetSetFeatureEnabled(int featureEntry, [MarshalAs(UnmanagedType.U4)] int dwFlags, bool fEnable);

		public static void DisableInternetExplorerClickSounds() { CoInternetSetFeatureEnabled(FEATURE_DISABLE_NAVIGATION_SOUNDS, SET_FEATURE_ON_PROCESS, true); }

	}

}