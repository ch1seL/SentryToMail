using Newtonsoft.Json;

namespace SentryToMail.Models.SentryDataModel {
	public class Request {
		[JsonProperty("url")]
		public string Url { get; set; }

		[JsonProperty("headers")]
		public string[][] Headers { get; set; }

		[JsonProperty("cookies")]
		public string[][] Cookies { get; set; }

		[JsonProperty("method")]
		public string Method { get; set; }

		[JsonProperty("env")]
		public Env Env { get; set; }
	}
}