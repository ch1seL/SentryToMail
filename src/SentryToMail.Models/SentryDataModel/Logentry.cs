using Newtonsoft.Json;

namespace SentryToMail.Models.SentryDataModel {
	public class Logentry {
		[JsonProperty(propertyName: "message")]
		public string Message { get; set; }
	}
}