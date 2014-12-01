using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Factories {

	/// <summary>A factory for generating <see cref="TraktMovie"/> instances</summary>
	public static class TraktMovieFactory {

		/// <summary>Create an instance of <see cref="TraktMovie"/> from an ID</summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <returns>See summary</returns>
		public static TraktMovie FromId(string movieId, StringMovieIdType movieIdType = StringMovieIdType.Auto) { return FromId<TraktMovie>(movieId, movieIdType); }

		/// <summary>Create an instance of a <see cref="TraktMovie"/> subclass from an ID</summary>
		/// <typeparam name="T">A subclass of <see cref="TraktMovie"/> to be created</typeparam>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <returns>See summary</returns>
		public static T FromId<T>(string movieId, StringMovieIdType movieIdType = StringMovieIdType.Auto) where T : TraktMovie {
			if (string.IsNullOrEmpty(movieId)) {
				throw new ArgumentException("movieId not set", "movieId");
			}

			if (movieIdType == StringMovieIdType.Auto) {
				movieIdType = movieId.StartsWith("tt", StringComparison.InvariantCultureIgnoreCase) ? StringMovieIdType.Imdb : StringMovieIdType.Slug;
			}

			var ret = Activator.CreateInstance<T>();
			ret.Ids = new TraktMovieIds();

			switch (movieIdType) {
				case StringMovieIdType.Slug:
					ret.Ids.Slug = movieId;
					break;
				case StringMovieIdType.Imdb:
					ret.Ids.Imdb = movieId;
					break;
				default:
					throw new ArgumentOutOfRangeException("movieIdType");
			}

			return ret;
		}

		/// <summary>Create an instance of <see cref="TraktMovie"/> from an ID</summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <returns>See summary</returns>
		public static TraktMovie FromId(int movieId, IntMovieIdType movieIdType) { return FromId<TraktMovie>(movieId, movieIdType); }

		/// <summary>Create an instance of a <see cref="TraktMovie"/> subclass from an ID</summary>
		/// <typeparam name="T">A subclass of <see cref="TraktMovie"/> to be created</typeparam>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <returns>See summary</returns>
		public static T FromId<T>(int movieId, IntMovieIdType movieIdType) where T : TraktMovie {
			var ret = Activator.CreateInstance<T>();
			ret.Ids = new TraktMovieIds();

			switch (movieIdType) {
				case IntMovieIdType.Trakt:
					ret.Ids.Trakt = movieId;
					break;
				case IntMovieIdType.Tmdb:
					ret.Ids.Tmdb = movieId;
					break;
				default:
					throw new ArgumentOutOfRangeException("movieIdType");
			}

			return ret;
		}

		/// <summary>Create an instance of <see cref="TraktMovie"/> from a title and year</summary>
		/// <param name="movieTitle">The movie title</param>
		/// <param name="movieYear">The movie release year</param>
		/// <returns>See summary</returns>
		public static TraktMovie FromTitleAndYear(string movieTitle, int? movieYear = null) { return FromTitleAndYear<TraktMovie>(movieTitle, movieYear); }

		/// <summary>Create an instance of a <see cref="TraktMovie"/> subclass from a title and year</summary>
		/// <typeparam name="T">A subclass of <see cref="TraktMovie"/> to be created</typeparam>
		/// <param name="movieTitle">The movie title</param>
		/// <param name="movieYear">The movie release year</param>
		/// <returns>See summary</returns>
		public static T FromTitleAndYear<T>(string movieTitle, int? movieYear = null) where T : TraktMovie {
			if (string.IsNullOrEmpty(movieTitle)) {
				throw new ArgumentException("movieTitle not set", "movieTitle");
			}
			var ret = Activator.CreateInstance<T>();
			ret.Title = movieTitle;
			ret.Year = movieYear;
			return ret;
		}

		/// <summary>Create an collection of <see cref="TraktMovie"/> instances from a collecion of IDs</summary>
		/// <param name="movieIds">A collection of movie IDs</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <returns>See summary</returns>
		public static IEnumerable<TraktMovie> FromIds(IEnumerable<string> movieIds, StringMovieIdType movieIdType = StringMovieIdType.Auto) {
			return movieIds == null ? null : movieIds.Select(movieId => FromId<TraktMovie>(movieId, movieIdType));
		}

		/// <summary>Create an collection of <see cref="TraktMovie"/> subclass instances from a collecion of IDs</summary>
		/// <typeparam name="T">A subclass of <see cref="TraktMovie"/> to be created</typeparam>
		/// <param name="movieIds">A collection of movie IDs</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <returns>See summary</returns>
		public static IEnumerable<T> FromIds<T>(IEnumerable<string> movieIds, StringMovieIdType movieIdType = StringMovieIdType.Auto) where T : TraktMovie {
			return movieIds == null ? null : movieIds.Select(movieId => FromId<T>(movieId, movieIdType));
		}

		/// <summary>Create an collection of <see cref="TraktMovie"/> instances from a collecion of IDs</summary>
		/// <param name="movieIds">A collection of movie IDs</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <returns>See summary</returns>
		public static IEnumerable<TraktMovie> FromIds(IEnumerable<int> movieIds, IntMovieIdType movieIdType) {
			return movieIds == null ? null : movieIds.Select(movieId => FromId<TraktMovie>(movieId, movieIdType));
		}

		/// <summary>Create an collection of <see cref="TraktMovie"/> subclass instances from a collecion of IDs</summary>
		/// <typeparam name="T">A subclass of <see cref="TraktMovie"/> to be created</typeparam>
		/// <param name="movieIds">A collection of movie IDs</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <returns>See summary</returns>
		public static IEnumerable<T> FromIds<T>(IEnumerable<int> movieIds, IntMovieIdType movieIdType) where T : TraktMovie {
			return movieIds == null ? null : movieIds.Select(movieId => FromId<T>(movieId, movieIdType));
		}

	}

}