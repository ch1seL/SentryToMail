using Newtonsoft.Json;

namespace SentryToMail.Models.SentryDataModel {
	public class PostedData {
		[JsonProperty(propertyName: "type")]
		public string Type { get; set; }
	}
}