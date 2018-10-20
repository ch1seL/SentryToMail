using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SentryToMail.API.Configurations;
using SentryToMail.API.Domain;
using SentryToMail.API.Utils.Extension;

namespace SentryToMail.API {
	public class Startup {
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			}

			var securitySettings = Configuration.GetSection(nameof(SecuritySettings)).Get<SecuritySettings>();
			app.UseToken(securitySettings.Token);

			app.UseMvc();
		}

		public void ConfigureServices(IServiceCollection services) {
			services.AddMvcCore()
			        .AddRazorViewEngine()
			        .AddJsonFormatters(settings => settings.Formatting = Formatting.Indented)
			        .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.AddViewRender()
			        .AddAutoMapper()
			        .AddSmtpClient();

			services
				.AddScoped<IMailQueueRepository, MailQueueRepository>()
				.AddScoped<IMailSender, MailSender>();
		}
	}
}