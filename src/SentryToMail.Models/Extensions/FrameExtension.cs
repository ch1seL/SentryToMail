using SentryToMail.Models.SentryDataModel;

namespace SentryToMail.Models.Extensions {
	public static class FrameExtension {
		public static bool IsFile(this Frame frame) {
			return frame.Filename != null;
		}

		public static string ToHtmlString(this Frame frame) {
			return
				$"{(frame.IsFile() ? $"File {frame.Filename}" : $"Module {frame.Module}")}, {(frame.IsFile() ? $"line {frame.Lineno}, " : string.Empty)} in {frame.Function}<br>&nbsp;&nbsp;{frame.ContextLine}<br>";
		}
	}
}