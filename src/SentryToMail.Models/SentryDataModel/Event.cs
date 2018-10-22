using System.Collections.Generic;
using Newtonsoft.Json;

namespace SentryToMail.Models.SentryDataModel {
	public class Event {
		[JsonProperty("received")]
		public double Received { get; set; }

		[JsonProperty("exception")]
		public ExceptionClass Exception { get; set; }

		[JsonProperty("errors")]
		public object[] Errors { get; set; }

		[JsonProperty("tags")]
		public string[][] Tags { get; set; }

		[JsonProperty("contexts")]
		public Contexts Contexts { get; set; }

		[JsonProperty("request")]
		public Request Request { get; set; }

		[JsonProperty("fingerprint")]
		public string[] Fingerprint { get; set; }

		[JsonProperty("extra")]
		public Extra Extra { get; set; }

		[JsonProperty("modules")]
		public Dictionary<string, string> Modules { get; set; }

		[JsonProperty("project")]
		public long Project { get; set; }

		[JsonProperty("event_id")]
		public string EventId { get; set; }

		[JsonProperty("version")]
		[JsonConverter(typeof(ParseStringConverter))]
		public long Version { get; set; }

		[JsonProperty("user")]
		public User User { get; set; }

		[JsonProperty("_ref_version")]
		public long RefVersion { get; set; }

		[JsonProperty("key_id")]
		public long KeyId { get; set; }

		[JsonProperty("_ref")]
		public long Ref { get; set; }

		[JsonProperty("sdk")]
		public Sdk Sdk { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("id")]
		public long Id { get; set; }

		[JsonProperty("metadata")]
		public Metadata Metadata { get; set; }
	}
}