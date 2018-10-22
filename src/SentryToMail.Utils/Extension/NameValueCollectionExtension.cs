using System;
using System.Collections.Specialized;
using System.Linq;

namespace SentryToMail.Utils.Extension {
	public static class NameValueCollectionExtension {
		public static string FindValue(this NameValueCollection nameValueCollection, string key) {
			key = key.ToLower();
			return nameValueCollection.AllKeys.Contains(key, StringComparer.CurrentCultureIgnoreCase) ? nameValueCollection[key] : null;
		}
	}
}