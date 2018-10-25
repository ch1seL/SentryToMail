using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SentryToMail.Configurations.Options;

namespace SentryToMail.Middleware {
	public class TokenMiddleware {
		private readonly RequestDelegate _next;
		private readonly string _token;

		public TokenMiddleware(RequestDelegate next, IOptions<SecurityOptions> securityOptionsAccessor) {
			_next = next;
			_token = securityOptionsAccessor.Value.Token;
		}

		public async Task InvokeAsync(HttpContext context) {
			if (context.Request.Query[key: "token"] != _token) {
				context.Response.StatusCode = 403;
				context.Response.ContentType = "application/json";
				await context.Response.WriteAsync(JsonConvert.SerializeObject(new { Error = "Token is invalid" }));

				string userIp = context.Connection.RemoteIpAddress.ToString();
				string userAgent = context.Request.Headers["User-Agent"].SingleOrDefault();
				var ex = new UnauthorizedAccessException($"RemoteIpAddress:{userIp} User-Agent:{userAgent}");
				ex.Data.Add("RemoteIpAddress", userIp);
				ex.Data.Add("User-Agent", userAgent);
				throw ex;
			}

			await _next.Invoke(context);
		}
	}
}