using System;
using System.Linq;
using Newtonsoft.Json;
using TraktSharp.Enums;
using TraktSharp.Helpers;

namespace TraktSharp.Entities.RequestBody.Users {

	/// <summary>Request body parameters for a create list request</summary>
	[Serializable]
	public class TraktListRequestBody {

		/// <summary>The name of the list</summary>
		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		/// <summary>Description for this list</summary>
		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }

		/// <summary>Privacy setting for the list</summary>
		[JsonIgnore]
		public TraktPrivacyOption Privacy { get; set; }

		[JsonProperty(PropertyName = "privacy")]
		private string PrivacyString => TraktEnumHelper.GetDescription(Privacy);

		/// <summary>Should each item be numbered?</summary>
		[JsonProperty(PropertyName = "display_numbers")]
		public bool? DisplayNumbers { get; set; }

		/// <summary>Are comments allowed?</summary>
		[JsonProperty(PropertyName = "allow_comments")]
		public bool? AllowComments { get; set; }

	}

}