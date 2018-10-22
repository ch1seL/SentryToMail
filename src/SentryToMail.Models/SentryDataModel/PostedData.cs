using Newtonsoft.Json;

namespace SentryToMail.Models.SentryDataModel {
	public class PostedData {
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}