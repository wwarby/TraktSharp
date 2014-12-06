using System;
using System.Linq;
using Newtonsoft.Json;
using TraktSharp.Enums;
using TraktSharp.Helpers;

namespace TraktSharp.Entities.RequestBody.Users {

	[Serializable]
	public class TraktListRequestBody {

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }

		[JsonIgnore]
		public TraktPrivacyOption Privacy { get; set; }

		[JsonProperty(PropertyName = "privacy")]
		private string PrivacyString { get { return TraktEnumHelper.GetDescription(Privacy); } }

		[JsonProperty(PropertyName = "display_numbers")]
		public bool? DisplayNumbers { get; set; }

		[JsonProperty(PropertyName = "allow_comments")]
		public bool? AllowComments { get; set; }

	}

}