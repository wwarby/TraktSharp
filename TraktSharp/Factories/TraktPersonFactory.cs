using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Factories {

	/// <summary>A factory for generating <see cref="TraktPerson"/> instances</summary>
	public static class TraktPersonFactory {

		/// <summary>Create an instance of <see cref="TraktPerson"/> from an ID</summary>
		/// <param name="personId">The person ID</param>
		/// <param name="personIdType">The person ID type</param>
		/// <returns>See summary</returns>
		public static TraktPerson FromId(string personId, TraktTextPersonIdType personIdType = TraktTextPersonIdType.Auto) => FromId<TraktPerson>(personId, personIdType);

		/// <summary>Create an instance of a <see cref="TraktPerson"/> subclass from an ID</summary>
		/// <typeparam name="T">A subclass of <see cref="TraktPerson"/> to be created</typeparam>
		/// <param name="personId">The person ID</param>
		/// <param name="personIdType">The person ID type</param>
		/// <returns>See summary</returns>
		public static T FromId<T>(string personId, TraktTextPersonIdType personIdType = TraktTextPersonIdType.Auto) where T : TraktPerson {
			if (string.IsNullOrEmpty(personId)) {
				throw new ArgumentException("personId not set", nameof(personId));
			}

			if (personIdType == TraktTextPersonIdType.Auto) {
				if (personId.StartsWith("nm", StringComparison.InvariantCultureIgnoreCase)) {
					personIdType = TraktTextPersonIdType.Imdb;
				} else {
					throw new ArgumentException("Unable to detect id type", nameof(personIdType));
				}
			}

			var ret = Activator.CreateInstance<T>();
			ret.Ids = new TraktPersonIds();

			switch (personIdType) {
				case TraktTextPersonIdType.Imdb:
					ret.Ids.Imdb = personId;
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(personIdType));
			}

			return ret;
		}

		/// <summary>Create an instance of <see cref="TraktPerson"/> from an ID</summary>
		/// <param name="personId">The person ID</param>
		/// <param name="personIdType">The person ID type</param>
		/// <returns>See summary</returns>
		public static TraktPerson FromId(int personId, TraktNumericPersonIdType personIdType) => FromId<TraktPerson>(personId, personIdType);

		/// <summary>Create an instance of a <see cref="TraktPerson"/> subclass from an ID</summary>
		/// <typeparam name="T">A subclass of <see cref="TraktPerson"/> to be created</typeparam>
		/// <param name="personId">The person ID</param>
		/// <param name="personIdType">The person ID type</param>
		/// <returns>See summary</returns>
		public static T FromId<T>(int personId, TraktNumericPersonIdType personIdType) where T : TraktPerson {
			var ret = Activator.CreateInstance<T>();
			ret.Ids = new TraktPersonIds();

			switch (personIdType) {
				case TraktNumericPersonIdType.Trakt:
					ret.Ids.Trakt = personId;
					break;
				case TraktNumericPersonIdType.Tmdb:
					ret.Ids.Tmdb = personId;
					break;
				case TraktNumericPersonIdType.TvRage:
					ret.Ids.TvRage = personId;
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(personIdType));
			}

			return ret;
		}

		/// <summary>Create an collection of <see cref="TraktPerson"/> instances from a collection of IDs</summary>
		/// <param name="personIds">The person ID</param>
		/// <param name="personIdType">The person ID type</param>
		/// <returns>See summary</returns>
		public static IEnumerable<TraktPerson> FromIds(IEnumerable<string> personIds, TraktTextPersonIdType personIdType = TraktTextPersonIdType.Auto) {
			return personIds?.Select(personId => FromId<TraktPerson>(personId, personIdType));
		}

		/// <summary>Create an collection of <see cref="TraktPerson"/> subclass instances from a collection of IDs</summary>
		/// <typeparam name="T">A subclass of <see cref="TraktPerson"/> to be created</typeparam>
		/// <param name="personIds">The person ID</param>
		/// <param name="personIdType">The person ID type</param>
		/// <returns>See summary</returns>
		public static IEnumerable<T> FromIds<T>(IEnumerable<string> personIds, TraktTextPersonIdType personIdType = TraktTextPersonIdType.Auto) where T : TraktPerson {
			return personIds?.Select(personId => FromId<T>(personId, personIdType));
		}

		/// <summary>Create an collection of <see cref="TraktPerson"/> instances from a collection of IDs</summary>
		/// <param name="personIds">The person ID</param>
		/// <param name="personIdType">The person ID type</param>
		/// <returns>See summary</returns>
		public static IEnumerable<TraktPerson> FromIds(IEnumerable<int> personIds, TraktNumericPersonIdType personIdType) {
			return personIds?.Select(personId => FromId<TraktPerson>(personId, personIdType));
		}

		/// <summary>Create an collection of <see cref="TraktPerson"/> subclass instances from a collection of IDs</summary>
		/// <typeparam name="T">A subclass of <see cref="TraktPerson"/> to be created</typeparam>
		/// <param name="personIds">The person ID</param>
		/// <param name="personIdType">The person ID type</param>
		/// <returns>See summary</returns>
		public static IEnumerable<T> FromIds<T>(IEnumerable<int> personIds, TraktNumericPersonIdType personIdType) where T : TraktPerson {
			return personIds?.Select(personId => FromId<T>(personId, personIdType));
		}

	}

}