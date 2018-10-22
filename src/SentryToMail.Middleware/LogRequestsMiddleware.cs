using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace SentryToMail.Middleware {
	public class LogRequestsMiddleware {
		private readonly RequestDelegate _next;

		public LogRequestsMiddleware(RequestDelegate next) {
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context) {
			var logFile = $"{AppDomain.CurrentDomain.BaseDirectory}/logs/requests-{DateTime.Now:yyyy-MM-ddTHH-mm-ss}.json";
			var fileInfo = new FileInfo(logFile);
			if (!fileInfo.Directory?.Exists ?? false) {
				fileInfo.Directory.Create();
			}

			context.Request.EnableRewind();
			var responseBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
			await File.AppendAllTextAsync(logFile, responseBody);
			context.Request.Body.Position = 0;
			await _next(context);
		}
	}
}