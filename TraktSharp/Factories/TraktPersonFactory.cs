using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Factories {

	/// <summary>A factory for generating <see cref="TraktPerson"/> instances</summary>
	public static class TraktPersonFactory {

		/// <summary>Create an instance of <see cref="TraktPerson"/> from an ID</summary>
		/// <param name="personId">The person ID</param>
		/// <param name="personIdType">The person ID type</param>
		/// <returns>See summary</returns>
		public static TraktPerson FromId(string personId, StringPersonIdType personIdType = StringPersonIdType.Auto) { return FromId<TraktPerson>(personId, personIdType); }

		/// <summary>Create an instance of a <see cref="TraktPerson"/> subclass from an ID</summary>
		/// <typeparam name="T">A subclass of <see cref="TraktPerson"/> to be created</typeparam>
		/// <param name="personId">The person ID</param>
		/// <param name="personIdType">The person ID type</param>
		/// <returns>See summary</returns>
		public static T FromId<T>(string personId, StringPersonIdType personIdType = StringPersonIdType.Auto) where T : TraktPerson {
			if (string.IsNullOrEmpty(personId)) {
				throw new ArgumentException("personId not set", "personId");
			}

			if (personIdType == StringPersonIdType.Auto) {
				if (personId.StartsWith("nm", StringComparison.InvariantCultureIgnoreCase)) {
					personIdType = StringPersonIdType.Imdb;
				} else {
					throw new ArgumentException("Unable to detect id type", "personIdType");
				}
			}

			var ret = Activator.CreateInstance<T>();
			ret.Ids = new TraktPersonIds();

			switch (personIdType) {
				case StringPersonIdType.Imdb:
					ret.Ids.Imdb = personId;
					break;
				default:
					throw new ArgumentOutOfRangeException("personIdType");
			}

			return ret;
		}

		/// <summary>Create an instance of <see cref="TraktPerson"/> from an ID</summary>
		/// <param name="personId">The person ID</param>
		/// <param name="personIdType">The person ID type</param>
		/// <returns>See summary</returns>
		public static TraktPerson FromId(int personId, IntPersonIdType personIdType) { return FromId<TraktPerson>(personId, personIdType); }

		/// <summary>Create an instance of a <see cref="TraktPerson"/> subclass from an ID</summary>
		/// <typeparam name="T">A subclass of <see cref="TraktPerson"/> to be created</typeparam>
		/// <param name="personId">The person ID</param>
		/// <param name="personIdType">The person ID type</param>
		/// <returns>See summary</returns>
		public static T FromId<T>(int personId, IntPersonIdType personIdType) where T : TraktPerson {
			var ret = Activator.CreateInstance<T>();
			ret.Ids = new TraktPersonIds();

			switch (personIdType) {
				case IntPersonIdType.Trakt:
					ret.Ids.Trakt = personId;
					break;
				case IntPersonIdType.Tmdb:
					ret.Ids.Tmdb = personId;
					break;
				case IntPersonIdType.TvRage:
					ret.Ids.TvRage = personId;
					break;
				default:
					throw new ArgumentOutOfRangeException("personIdType");
			}

			return ret;
		}

		/// <summary>Create an collection of <see cref="TraktPerson"/> instances from a collecion of IDs</summary>
		/// <param name="personIds">The person ID</param>
		/// <param name="personIdType">The person ID type</param>
		/// <returns>See summary</returns>
		public static IEnumerable<TraktPerson> FromIds(IEnumerable<string> personIds, StringPersonIdType personIdType = StringPersonIdType.Auto) {
			return personIds == null ? null : personIds.Select(personId => FromId<TraktPerson>(personId, personIdType));
		}

		/// <summary>Create an collection of <see cref="TraktPerson"/> subclass instances from a collecion of IDs</summary>
		/// <typeparam name="T">A subclass of <see cref="TraktPerson"/> to be created</typeparam>
		/// <param name="personIds">The person ID</param>
		/// <param name="personIdType">The person ID type</param>
		/// <returns>See summary</returns>
		public static IEnumerable<T> FromIds<T>(IEnumerable<string> personIds, StringPersonIdType personIdType = StringPersonIdType.Auto) where T : TraktPerson {
			return personIds == null ? null : personIds.Select(personId => FromId<T>(personId, personIdType));
		}

		/// <summary>Create an collection of <see cref="TraktPerson"/> instances from a collecion of IDs</summary>
		/// <param name="personIds">The person ID</param>
		/// <param name="personIdType">The person ID type</param>
		/// <returns>See summary</returns>
		public static IEnumerable<TraktPerson> FromIds(IEnumerable<int> personIds, IntPersonIdType personIdType) {
			return personIds == null ? null : personIds.Select(personId => FromId<TraktPerson>(personId, personIdType));
		}

		/// <summary>Create an collection of <see cref="TraktPerson"/> subclass instances from a collecion of IDs</summary>
		/// <typeparam name="T">A subclass of <see cref="TraktPerson"/> to be created</typeparam>
		/// <param name="personIds">The person ID</param>
		/// <param name="personIdType">The person ID type</param>
		/// <returns>See summary</returns>
		public static IEnumerable<T> FromIds<T>(IEnumerable<int> personIds, IntPersonIdType personIdType) where T : TraktPerson {
			return personIds == null ? null : personIds.Select(personId => FromId<T>(personId, personIdType));
		}

	}

}