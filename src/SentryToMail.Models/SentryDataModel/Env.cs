using Newtonsoft.Json;

namespace SentryToMail.Models.SentryDataModel {
	public class Env {
		[JsonProperty(propertyName: "IP Address")]
		public string IpAddress { get; set; }
	}
}