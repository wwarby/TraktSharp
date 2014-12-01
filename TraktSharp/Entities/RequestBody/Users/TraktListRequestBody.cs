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

		[JsonProperty(PropertyName = "privacy")]
		public string PrivacyString { get; set; }

		[JsonIgnore]
		public TraktPrivacyOption Privacy {
			get { return EnumsHelper.FromDescription(PrivacyString, TraktPrivacyOption.Unspecified); }
			set { PrivacyString = EnumsHelper.GetDescription(value); }
		}

		[JsonProperty(PropertyName = "display_numbers")]
		public bool? DisplayNumbers { get; set; }

		[JsonProperty(PropertyName = "allow_comments")]
		public bool? AllowComments { get; set; }

	}

}