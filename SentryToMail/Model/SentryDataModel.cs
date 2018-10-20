using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SentryToMail.API.Model {
	public partial class SentryDataModel {
		[JsonProperty(propertyName: "project")]
		public string Project { get; set; }

		[JsonProperty(propertyName: "project_name")]
		public string ProjectName { get; set; }

		[JsonProperty(propertyName: "culprit")]
		public string Culprit { get; set; }

		[JsonProperty(propertyName: "project_slug")]
		public string ProjectSlug { get; set; }

		[JsonProperty(propertyName: "url")]
		public Uri Url { get; set; }

		[JsonProperty(propertyName: "logger")]
		public object Logger { get; set; }

		[JsonProperty(propertyName: "level")]
		public string Level { get; set; }

		[JsonProperty(propertyName: "message")]
		public string Message { get; set; }

		[JsonProperty(propertyName: "id")]
		[JsonConverter(typeof(ParseStringConverter))]
		public long Id { get; set; }

		[JsonProperty(propertyName: "event")]
		public Event Event { get; set; }
	}

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

	public class Contexts {
		[JsonProperty(propertyName: "Page Path")]
		public PagePath PagePath { get; set; }

		[JsonProperty(propertyName: "Session vars")]
		public SessionVars SessionVars { get; set; }

		[JsonProperty(propertyName: "Session Objects")]
		public SessionObjects SessionObjects { get; set; }

		[JsonProperty(propertyName: "Posted data")]
		public PostedData PostedData { get; set; }

		[JsonProperty(propertyName: "Version Information")]
		public VersionInformation VersionInformation { get; set; }

		[JsonProperty(propertyName: "runtime")]
		public Os Runtime { get; set; }

		[JsonProperty(propertyName: "os")]
		public Os Os { get; set; }

		[JsonProperty(propertyName: "Request Information")]
		public RequestInformation RequestInformation { get; set; }

		[JsonProperty(propertyName: "browser")]
		public Browser Browser { get; set; }
	}

	public class Browser {
		[JsonProperty(propertyName: "type")]
		public string Type { get; set; }

		[JsonProperty(propertyName: "name")]
		public string Name { get; set; }
	}

	public class Os {
		[JsonProperty(propertyName: "raw_description")]
		public string RawDescription { get; set; }

		[JsonProperty(propertyName: "version")]
		public string Version { get; set; }

		[JsonProperty(propertyName: "type")]
		public string Type { get; set; }

		[JsonProperty(propertyName: "name")]
		public string Name { get; set; }
	}

	public class PagePath {
		[JsonProperty(propertyName: "type")]
		public string Type { get; set; }

		[JsonProperty(propertyName: "Page1")]
		public string Page1 { get; set; }
	}

	public class PostedData {
		[JsonProperty(propertyName: "type")]
		public string Type { get; set; }
	}

	public class RequestInformation {
		[JsonProperty(propertyName: "New Session")]
		public string NewSession { get; set; }

		[JsonProperty(propertyName: "Date & Time")]
		public string DateTime { get; set; }

		[JsonProperty(propertyName: "ApplicationId")]
		public string ApplicationId { get; set; }

		[JsonProperty(propertyName: "Host")]
		public string Host { get; set; }

		[JsonProperty(propertyName: "type")]
		public string Type { get; set; }
	}

	public class SessionObjects {
		[JsonProperty(propertyName: "UserName")]
		public string UserName { get; set; }

		[JsonProperty(propertyName: "AgencyName")]
		public string AgencyName { get; set; }

		[JsonProperty(propertyName: "FormEditor")]
		public string FormEditor { get; set; }

		[JsonProperty(propertyName: "UserId")]
		[JsonConverter(typeof(ParseStringConverter))]
		public long UserId { get; set; }

		[JsonProperty(propertyName: "Insured")]
		public string Insured { get; set; }

		[JsonProperty(propertyName: "LoginUrl")]
		public Uri LoginUrl { get; set; }

		[JsonProperty(propertyName: "type")]
		public string Type { get; set; }
	}

	public class SessionVars {
		[JsonProperty(propertyName: "type")]
		public string Type { get; set; }

		[JsonProperty(propertyName: "pathLog")]
		public string PathLog { get; set; }

		[JsonProperty(propertyName: "isRootLogin")]
		public string IsRootLogin { get; set; }
	}

	public class VersionInformation {
		[JsonProperty(propertyName: "type")]
		public string Type { get; set; }

		[JsonProperty(propertyName: "storage")]
		public string Storage { get; set; }
	}

	public class Extra { }

	public class Logentry {
		[JsonProperty(propertyName: "message")]
		public string Message { get; set; }
	}

	public class Metadata {
		[JsonProperty(propertyName: "title")]
		public string Title { get; set; }
	}

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

	public class Env {
		[JsonProperty(propertyName: "IP Address")]
		public string IpAddress { get; set; }
	}

	public class Sdk {
		[JsonProperty(propertyName: "version")]
		public string Version { get; set; }

		[JsonProperty(propertyName: "name")]
		public string Name { get; set; }

		[JsonProperty(propertyName: "packages")]
		public Package[] Packages { get; set; }
	}

	public class Package {
		[JsonProperty(propertyName: "Version")]
		public string Version { get; set; }

		[JsonProperty(propertyName: "Name")]
		public string Name { get; set; }
	}

	public class Stacktrace {
		[JsonProperty(propertyName: "frames")]
		public Frame[] Frames { get; set; }
	}

	public class Frame {
		[JsonProperty(propertyName: "function")]
		public string Function { get; set; }

		[JsonProperty(propertyName: "package", NullValueHandling = NullValueHandling.Ignore)]
		public string Package { get; set; }

		[JsonProperty(propertyName: "module")]
		public string Module { get; set; }

		[JsonProperty(propertyName: "context_line")]
		public string ContextLine { get; set; }

		[JsonProperty(propertyName: "in_app")]
		public bool InApp { get; set; }

		[JsonProperty(propertyName: "abs_path", NullValueHandling = NullValueHandling.Ignore)]
		public string AbsPath { get; set; }

		[JsonProperty(propertyName: "filename", NullValueHandling = NullValueHandling.Ignore)]
		public string Filename { get; set; }

		[JsonProperty(propertyName: "lineno", NullValueHandling = NullValueHandling.Ignore)]
		public long? Lineno { get; set; }

		[JsonProperty(propertyName: "colno", NullValueHandling = NullValueHandling.Ignore)]
		public long? Colno { get; set; }
	}

	public class User {
		[JsonProperty(propertyName: "username")]
		public string Username { get; set; }

		[JsonProperty(propertyName: "id")]
		[JsonConverter(typeof(ParseStringConverter))]
		public long Id { get; set; }

		[JsonProperty(propertyName: "email")]
		public string Email { get; set; }
	}

	public partial class SentryDataModel {
		public static SentryDataModel FromJson(string json) {
			return JsonConvert.DeserializeObject<SentryDataModel>(json, Converter.Settings);
		}
	}

	public static class Serialize {
		public static string ToJson(this SentryDataModel self) {
			return JsonConvert.SerializeObject(self, Converter.Settings);
		}
	}

	internal static class Converter {
		public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings {
			MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
			DateParseHandling = DateParseHandling.None,
			Converters = {
				new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
			}
		};
	}

	internal class ParseStringConverter : JsonConverter {
		public static readonly ParseStringConverter Singleton = new ParseStringConverter();

		public override bool CanConvert(Type t) {
			return t == typeof(long) || t == typeof(long?);
		}

		public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer) {
			if (reader.TokenType == JsonToken.Null) {
				return null;
			}
			var value = serializer.Deserialize<string>(reader);
			long l;
			if (long.TryParse(value, out l)) {
				return l;
			}
			throw new Exception(message: "Cannot unmarshal type long");
		}

		public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer) {
			if (untypedValue == null) {
				serializer.Serialize(writer, value: null);
				return;
			}
			var value = (long)untypedValue;
			serializer.Serialize(writer, value.ToString());
		}
	}
}