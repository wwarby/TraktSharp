using System;
using System.IO;
using System.Linq;

namespace TraktSharp.Examples.Wpf.Helpers {

	internal static class FileSystemHelper {

		internal static void EmptyDirectory(string path) {
			EnsureDirectoryExists(path);
			foreach (var p in Directory.GetDirectories(path)) {
				Directory.Delete(p, true);
			}

			foreach (var p in Directory.GetFiles(path)) {
				File.Delete(p);
			}
		}

		internal static void EnsureDirectoryExists(string path) {
			if (!Directory.Exists(path)) {
				Directory.CreateDirectory(path);
			}
		}

		internal static void EnsureParentDirectoryExists(string path) { EnsureDirectoryExists(Path.GetDirectoryName(path)); }

		internal static bool DirectoryExists(string path) {
			try {
				return Directory.Exists(path);
			} catch { }

			return false;
		}

		internal static bool FileExists(string path) {
			try {
				return File.Exists(path);
			} catch { }

			return false;
		}

	}

}