using Newtonsoft.Json;

namespace SentryToMail.Models.SentryDataModel {
	public class User {
		[JsonProperty(propertyName: "username")]
		public string Username { get; set; }

		[JsonProperty(propertyName: "id")]
		[JsonConverter(typeof(ParseStringConverter))]
		public long Id { get; set; }

		[JsonProperty(propertyName: "email")]
		public string Email { get; set; }
	}
}