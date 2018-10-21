using System.Collections.Generic;
using Newtonsoft.Json;

namespace SentryToMail.Models.SentryDataModel {
	public class Event {
		[JsonProperty(propertyName: "stacktrace")]
		public Stacktrace Stacktrace { get; set; }

		[JsonProperty(propertyName: "errors")]
		public object[] Errors { get; set; }

		[JsonProperty(propertyName: "extra")]
		public Extra Extra { get; set; }

		[JsonProperty(propertyName: "contexts")]
		public Contexts Contexts { get; set; }

		[JsonProperty(propertyName: "request")]
		public Request Request { get; set; }

		[JsonProperty(propertyName: "fingerprint")]
		public string[] Fingerprint { get; set; }

		[JsonProperty(propertyName: "tags")]
		public string[][] Tags { get; set; }

		[JsonProperty(propertyName: "modules")]
		public Dictionary<string, string> Modules { get; set; }

		[JsonProperty(propertyName: "project")]
		public long Project { get; set; }

		[JsonProperty(propertyName: "received")]
		public long Received { get; set; }

		[JsonProperty(propertyName: "version")]
		[JsonConverter(typeof(ParseStringConverter))]
		public long Version { get; set; }

		[JsonProperty(propertyName: "user")]
		public User User { get; set; }

		[JsonProperty(propertyName: "logentry")]
		public Logentry Logentry { get; set; }

		[JsonProperty(propertyName: "_ref_version")]
		public long RefVersion { get; set; }

		[JsonProperty(propertyName: "event_id")]
		public string EventId { get; set; }

		[JsonProperty(propertyName: "key_id")]
		public long KeyId { get; set; }

		[JsonProperty(propertyName: "_ref")]
		public long Ref { get; set; }

		[JsonProperty(propertyName: "sdk")]
		public Sdk Sdk { get; set; }

		[JsonProperty(propertyName: "type")]
		public string Type { get; set; }

		[JsonProperty(propertyName: "id")]
		public long Id { get; set; }

		[JsonProperty(propertyName: "metadata")]
		public Metadata Metadata { get; set; }
	}
}