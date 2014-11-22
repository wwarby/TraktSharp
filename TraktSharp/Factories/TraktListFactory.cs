using System;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Factories {

	public static class TraktListFactory {

		public static TraktList FromId(string id) {
			if (string.IsNullOrEmpty(id)) {
				throw new ArgumentException("Id not set", "id");
			}
			var ret = new TraktList { Ids = { Slug = id } };
			return ret;
		}

		public static TraktList FromId(int id) {
			var ret = new TraktList { Ids = { Trakt = id } };
			return ret;
		}

	}

}