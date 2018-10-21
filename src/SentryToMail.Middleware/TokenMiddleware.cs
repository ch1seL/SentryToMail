﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SentryToMail.Configurations;

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
			} else {
				await _next.Invoke(context);
			}
		}
	}
}