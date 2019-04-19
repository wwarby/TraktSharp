using System;
using TraktSharp.Entities;

namespace TraktSharp.Factories {

	/// <summary>A factory for generating <see cref="TraktList"/> instances</summary>
	public static class TraktListFactory {

		/// <summary>Create an instance of <see cref="TraktList"/> from an ID</summary>
		/// <param name="listId">The list ID</param>
		/// <returns>See summary</returns>
		public static TraktList FromId(string listId) {
			if (string.IsNullOrEmpty(listId)) {
				throw new ArgumentException("listId not set", nameof(listId));
			}
			var ret = new TraktList { Ids = new TraktListIds { Slug = listId } };
			return ret;
		}

		/// <summary>Create an instance of <see cref="TraktList"/> from an ID</summary>
		/// <param name="listId">The list ID</param>
		/// <returns>See summary</returns>
		public static TraktList FromId(int listId) {
			var ret = new TraktList { Ids = new TraktListIds { Trakt = listId } };
			return ret;
		}

	}

}