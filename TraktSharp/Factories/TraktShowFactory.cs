using System;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Factories {

	public static class TraktShowFactory {

		public static TraktShow FromId(string id, StringShowIdType type = StringShowIdType.Auto) {
			if (string.IsNullOrEmpty(id)) {
				throw new ArgumentException("Id not set", "id");
			}

			if (type == StringShowIdType.Auto) {
				type = id.StartsWith("tt", StringComparison.InvariantCultureIgnoreCase) ? StringShowIdType.Imdb : StringShowIdType.Slug;
			}

			var ret = new TraktShow();

			switch (type) {
				case StringShowIdType.Slug:
					ret.Ids.Slug = id;
					break;
				case StringShowIdType.Imdb:
					ret.Ids.Imdb = id;
					break;
				default:
					throw new ArgumentOutOfRangeException("type");
			}

			return ret;
		}

		public static TraktShow FromId(int id, IntShowIdType type) {
			var ret = new TraktShow();

			switch (type) {
				case IntShowIdType.Trakt:
					ret.Ids.Trakt = id;
					break;
				case IntShowIdType.Tvdb:
					ret.Ids.Tvdb = id;
					break;
				case IntShowIdType.Tmdb:
					ret.Ids.Tmdb = id;
					break;
				case IntShowIdType.TvRage:
					ret.Ids.TvRage = id;
					break;
				default:
					throw new ArgumentOutOfRangeException("type");
			}

			return ret;
		}

		public static TraktShow FromTitleAndYear(string title, int? year = null) {
			if (string.IsNullOrEmpty(title)) {
				throw new ArgumentException("Title not set", "title");
			}
			return new TraktShow {Title = title, Year = year};
		}

	}

}