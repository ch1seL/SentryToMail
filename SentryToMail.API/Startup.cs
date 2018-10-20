using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SentryToMail.API.Middleware;
using SentryToMail.Configurations.Options;
using SentryToMail.Domain;
using SentryToMail.Utils.Extension;

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

			app.UseToken<TokenMiddleware>();

			app.UseMvc();
		}

		public void ConfigureServices(IServiceCollection services) {
			services
				.AddMvcCore()
				.AddRazorViewEngine()
				.AddJsonFormatters(settings => settings.Formatting = Formatting.Indented)
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services
				.AddAutoMapper()
				.AddSmtpClient();

			services
				.AddSingleton<IMailQueueRepository, MailQueueRepository>()
				.AddScoped<IViewRender, ViewRender>()
				.AddScoped<IMailSender, MailSender>();

			services
				.AddHostedService<BackgroundMailSender>();

			services
				.AddOptions()
				.Configure<RepositoriesOptions>(Configuration.GetSection(nameof(RepositoriesOptions)))
				.Configure<MailOptions>(Configuration.GetSection(nameof(MailOptions)));
		}
	}
}