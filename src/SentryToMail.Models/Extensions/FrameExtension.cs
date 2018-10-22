using System;
using SentryToMail.Models.SentryDataModel;

namespace SentryToMail.Models.Extensions {
	public static class FrameExtension {
		public static bool IsFile(this Frame frame) {
			return frame.Filename != null;
		}

		public static string ToHtmlString(this Frame frame) {
			return $"  at {frame.ContextLine} {(frame.IsFile() ? $"in {frame.Filename}:line {frame.Lineno}" : string.Empty)}";
		}
	}
}