using System;
using System.IO;
using System.Linq;

namespace TraktSharp.Helpers {

	public static class FileSystemHelper {

		public static void EmptyDirectory(string path) {
			EnsureDirectoryExists(path);
			foreach (var p in Directory.GetDirectories(path)) { Directory.Delete(p, true); }
			foreach (var p in Directory.GetFiles(path)) { File.Delete(p); }
		}

		public static void EnsureDirectoryExists(string path) {
			if (!Directory.Exists(path)) { Directory.CreateDirectory(path); }
		}

		public static void EnsureParentDirectoryExists(string path) { EnsureDirectoryExists(Path.GetDirectoryName(path)); }

		public static bool DirectoryExists(string path) {
			try { return Directory.Exists(path); } catch {}
			return false;
		}

		public static bool FileExists(string path) {
			try { return File.Exists(path); } catch {}
			return false;
		}

	}

}