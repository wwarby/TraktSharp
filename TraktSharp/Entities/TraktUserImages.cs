using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>A collection of images related to a user</summary>
	[Serializable]
	public class TraktUserImages {

		/// <summary>The user's avatar</summary>
		[JsonProperty(PropertyName = "avatar")]
		public TraktImage Avatar { get; set; }

	}

}