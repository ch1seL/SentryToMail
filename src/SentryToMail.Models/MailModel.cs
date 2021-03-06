﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SentryToMail.Models {
	public class MailModel {
		public Guid Id { get; set; }
		public string Project { get; set; }
		public string ProjectName { get; set; }
		public string ProjectSlug { get; set; }
		public string Url { get; set; }
		public string Message { get; set; }
		public string Culprit { get; set; }
		public string Level { get; set; }
		public string Exception { get; set; }
		public string Date { get; set; }
		public string Additional { get; set; }
		public RequestMailModel Request { get; set; }
		public UserMailModel User { get; set; }
		public Dictionary<string, string> Tags { get; set; }

		[JsonIgnore]
		public string Environment => Tags.GetValueOrDefault(nameof(Environment).ToLower());
		[JsonIgnore]
		public string Module => Tags.GetValueOrDefault(nameof(Module).ToLower());
		[JsonIgnore]
		public string MachineName => Tags.GetValueOrDefault(nameof(MachineName));
	}

	public class UserMailModel {
		public string Id { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
	}

	public class RequestMailModel {
		public string Url { get; set; }
		public string Method { get; set; }
	}
}