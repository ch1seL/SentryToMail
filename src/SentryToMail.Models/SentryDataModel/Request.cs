using Newtonsoft.Json;

namespace SentryToMail.Models.SentryDataModel {
	public class Request {
		[JsonProperty(propertyName: "cookies")]
		public string[][] Cookies { get; set; }

		[JsonProperty(propertyName: "url")]
		public string Url { get; set; }

		[JsonProperty(propertyName: "headers")]
		public string[][] Headers { get; set; }

		[JsonProperty(propertyName: "env")]
		public Env Env { get; set; }

		[JsonProperty(propertyName: "query_string")]
		public string QueryString { get; set; }

		[JsonProperty(propertyName: "method")]
		public string Method { get; set; }
	}
}