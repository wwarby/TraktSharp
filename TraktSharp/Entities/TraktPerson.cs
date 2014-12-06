using System;
using System.Linq;
using Newtonsoft.Json;
using TraktSharp.ExtensionMethods;

namespace TraktSharp.Entities {

	/// <summary>A person associated with a movie or show</summary>
	[Serializable]
	public class TraktPerson {

		/// <summary>The person's full name</summary>
		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		/// <summary>A collection of unique identifiers for the person in various web services</summary>
		[JsonProperty(PropertyName = "ids")]
		public TraktPersonIds Ids { get; set; }

		/// <summary>A collection of images related to the person</summary>
		[JsonProperty(PropertyName = "images")]
		public TraktPersonImages Images { get; set; }

		/// <summary>A short biography of the person</summary>
		[JsonProperty(PropertyName = "biography")]
		public string Biography { get; set; }

		/// <summary>The person's date of birth</summary>
		[JsonProperty(PropertyName = "birthday")]
		public DateTime? Birthday { get; set; }

		/// <summary>The person's age, derived from their <see cref="Birthday"/></summary>
		[JsonIgnore]
		public int Age { get { return Birthday.YearsBetween(DateTime.Now); } }

		/// <summary>The person's date of death</summary>
		[JsonProperty(PropertyName = "death")]
		public DateTime? Death { get; set; }

		/// <summary>The person's birthplace</summary>
		[JsonProperty(PropertyName = "birthplace")]
		public string Birthplace { get; set; }

		/// <summary>The URL of the person's homepage</summary>
		[JsonProperty(PropertyName = "homepage")]
		public string Homepage { get; set; }

	}

}