using Newtonsoft.Json;

namespace SentryToMail.Models.SentryDataModel {
	public class Value {
		[JsonProperty("stacktrace")]
		public Stacktrace Stacktrace { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("module")]
		public string Module { get; set; }

		[JsonProperty("value")]
		public string ValueValue { get; set; }

		[JsonProperty("thread_id")]
		public long ThreadId { get; set; }
	}
}