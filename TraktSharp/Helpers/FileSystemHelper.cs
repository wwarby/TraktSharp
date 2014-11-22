using System;
using System.IO;
using System.Linq;

namespace TraktSharp.Helpers {

	/// <summary>
	/// Provides helper functionality for the file system
	/// </summary>
	public static class FileSystemHelper {

		/// <summary>Deletes any files and/or folders that exist in the specified directory</summary>
		/// <param name="path">The path to the directory to be emptied</param>
		public static void EmptyDirectory(string path) {
			EnsureDirectoryExists(path);
			foreach (var p in Directory.GetDirectories(path)) {
				Directory.Delete(p, true);
			}
			foreach (var p in Directory.GetFiles(path)) {
				File.Delete(p);
			}
		}

		/// <summary>Creates a directory (and any intermediate directories in the path) if it doesn't already exist</summary>
		/// <param name="path">The path to a folder that must be created if it doesn't exist</param>
		public static void EnsureDirectoryExists(string path) {
			if (!Directory.Exists(path)) {
				Directory.CreateDirectory(path);
			}
		}

		/// <summary>
		/// Creates a directory (and any intermediate directories in the path) if it doesn't already exist by taking the
		/// parent directory from a path to a file or folder
		/// </summary>
		/// <param name="path">The path to a file or folder whose containing folder must be created if it doesn't exist</param>
		public static void EnsureParentDirectoryExists(string path) { EnsureDirectoryExists(Path.GetDirectoryName(path)); }

		/// <summary>
		/// Checks that a directory exists. This is wrapper around <see cref="Directory.Exists"/> to suppress any exceptions that may occur
		/// when calling that method.
		/// </summary>
		/// <param name="path">The directory path</param>
		/// <returns><c>true</c> if the directory exists, otherwise <c>false</c></returns>
		public static bool DirectoryExists(string path) {
			try {
				return Directory.Exists(path);
			} catch {}
			return false;
		}

		/// <summary>
		/// Checks that a file exists. This is wrapper around <see cref="File.Exists"/> to suppress any exceptions that may occur
		/// when calling that method.
		/// </summary>
		/// <param name="path">The path to the file</param>
		/// <returns><c>true</c> if the file exists, otherwise <c>false</c></returns>
		public static bool FileExists(string path) {
			try {
				return File.Exists(path);
			} catch {}
			return false;
		}

	}

}