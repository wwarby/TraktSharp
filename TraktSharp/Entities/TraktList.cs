using System;
using System.Linq;
using Newtonsoft.Json;
using TraktSharp.Helpers;

namespace TraktSharp.Entities {

	/// <summary>Details about a custom list created by a user</summary>
	[Serializable]
	public class TraktList {

		/// <summary>The list name</summary>
		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		/// <summary>The list name</summary>
		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }

		/// <summary>The privacy option for this list as a string returned from the Trakt API</summary>
		[JsonProperty(PropertyName = "privacy")]
		public string PrivacyString { get; set; }

		//TODO: More of this
		/// <summary>The privacy option for this list in a more usable enum form</summary>
		[JsonIgnore]
		public PrivacyOption Privacy {
			get { return EnumsHelper.FromDescription(PrivacyString, PrivacyOption.Unspecified); }
			set { PrivacyString = EnumsHelper.GetDescription(value); }
		}

		/// <summary>Indicates whether numbers are displayed for the items in this list</summary>
		[JsonProperty(PropertyName = "display_numbers")]
		public bool? DisplayNumbers { get; set; }

		/// <summary>Indicates whether comments are allowed on this list</summary>
		[JsonProperty(PropertyName = "allow_comments")]
		public bool? AllowComments { get; set; }

		/// <summary>The UTC date when this list was updated</summary>
		[JsonProperty(PropertyName = "updated_at")]
		public DateTime? UpdatedAt { get; set; }

		/// <summary>The number of items in this list</summary>
		[JsonProperty(PropertyName = "item_count")]
		public int? ItemCount { get; set; }

		/// <summary>The number of users who like this list</summary>
		[JsonProperty(PropertyName = "likes")]
		public int? Likes { get; set; }

		/// <summary>A collection of unique identifiers for this list in various web services</summary>
		[JsonProperty(PropertyName = "ids")]
		public TraktListIds Ids { get; set; }

		/// <summary>Indicates if the instance contains the data required for it to be sent as part of a request body in a <c>POST</c> HTTP method</summary>
		/// <returns><c>true</c> if the instance is in a fit state to be <c>POSTed</c>, otherwise <c>false</c></returns>
		internal bool IsPostable() {
			return Ids != null && Ids.HasAnyValuesSet();
		}

	}

}