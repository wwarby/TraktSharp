using System;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Factories {

	public static class TraktMovieFactory {

		public static TraktMovie FromId(string id, StringMovieIdType type = StringMovieIdType.Auto) {
			if (string.IsNullOrEmpty(id)) {
				throw new ArgumentException("Id not set", "id");
			}

			if (type == StringMovieIdType.Auto) {
				if (id.StartsWith("tt", StringComparison.InvariantCultureIgnoreCase)) {
					type = StringMovieIdType.Imdb;
				} else {
					type = StringMovieIdType.Slug;
				}
			}

			var ret = new TraktMovie();

			switch (type) {
				case StringMovieIdType.Slug:
					ret.Ids.Slug = id;
					break;
				case StringMovieIdType.Imdb:
					ret.Ids.Imdb = id;
					break;
				default:
					throw new ArgumentOutOfRangeException("type");
			}

			return ret;
		}

		public static TraktMovie FromId(int id, IntMovieIdType type) {
			var ret = new TraktMovie();

			switch (type) {
				case IntMovieIdType.Trakt:
					ret.Ids.Trakt = id;
					break;
				case IntMovieIdType.Tmdb:
					ret.Ids.Tmdb = id;
					break;
				default:
					throw new ArgumentOutOfRangeException("type");
			}

			return ret;
		}

		public static TraktMovie FromTitleAndYear(string title, int? year = null) {
			if (string.IsNullOrEmpty(title)) {
				throw new ArgumentException("Title not set", "title");
			}
			return new TraktMovie {Title = title, Year = year};
		}

	}

}