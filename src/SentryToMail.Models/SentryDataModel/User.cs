using Newtonsoft.Json;

namespace SentryToMail.Models.SentryDataModel {
	public class User {
		[JsonProperty("username")]
		public string Username { get; set; }

		[JsonProperty("id")]
		[JsonConverter(typeof(ParseStringConverter))]
		public long Id { get; set; }

		[JsonProperty("email")]
		public string Email { get; set; }
	}
}