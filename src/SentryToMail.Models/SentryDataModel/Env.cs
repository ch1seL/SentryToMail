using Newtonsoft.Json;

namespace SentryToMail.Models.SentryDataModel {
	public class Env {
		[JsonProperty("IP Address")]
		public string IpAddress { get; set; }
	}
}