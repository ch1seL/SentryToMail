using System;
using Newtonsoft.Json;

namespace SentryToMail.Models.SentryDataModel {
	public class SessionObjects {
		[JsonProperty("UserName")]
		public string UserName { get; set; }

		[JsonProperty("AgencyName")]
		public string AgencyName { get; set; }

		[JsonProperty("FormEditor")]
		public string FormEditor { get; set; }

		[JsonProperty("UserId")]
		[JsonConverter(typeof(ParseStringConverter))]
		public long UserId { get; set; }

		[JsonProperty("Insured")]
		public string Insured { get; set; }

		[JsonProperty("LoginUrl")]
		public Uri LoginUrl { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}