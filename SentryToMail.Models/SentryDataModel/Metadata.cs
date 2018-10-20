using Newtonsoft.Json;

namespace SentryToMail.Models.SentryDataModel {
	public class Metadata {
		[JsonProperty(propertyName: "title")]
		public string Title { get; set; }
	}
}