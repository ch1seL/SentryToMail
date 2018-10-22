using System.Collections.Specialized;

namespace SentryToMail.Models.Extensions {
	public static class TagsExtension {
		public static NameValueCollection ToNameValue(this string[][] array) {
			var nv = new NameValueCollection();
			foreach (string[] result in array) {
				nv.Add(result[0], result[1]);
			}
			return nv;
		}
	}
}