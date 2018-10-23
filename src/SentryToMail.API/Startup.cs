using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SentryToMail.Configurations.Options;
using SentryToMail.Domain;
using SentryToMail.Middleware;
using SentryToMail.Models.AutoMapper;

namespace SentryToMail.API {
	public class Startup {
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
				app.UseMiddleware<LogRequestsMiddleware>();
			}

			if (!env.IsDevelopment()) {
				app.UseMiddleware<TokenMiddleware>();
			}

			app.UseMvc();
		}

		public void ConfigureServices(IServiceCollection services) {
			services
				.AddMvcCore()
				.AddRazorViewEngine()
				.AddJsonFormatters(settings => settings.Formatting = Formatting.Indented)
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services
				.AddAutoMapper(typeof(SentryToMailModelProfile));

			services
				.AddSingleton<IMailQueueRepository, MailQueueRepository>()
				.AddScoped<IViewRender, ViewRender>()
				.AddScoped<IMailSender, MailSender>()
				.AddTransient<ISmtpClient, SmtpClientWrapper>();

			services
				.AddHostedService<BackgroundMailSender>();

			services
				.AddOptions()
				.Configure<SecurityOptions>(Configuration.GetSection(nameof(SecurityOptions)))
				.Configure<RepositoriesOptions>(Configuration.GetSection(nameof(RepositoriesOptions)))
				.Configure<MailOptions>(Configuration.GetSection(nameof(MailOptions)))
				.Configure<SmtpOptions>(Configuration.GetSection(nameof(SmtpOptions)))
				.Configure<BackgroundMailSenderOptions>(Configuration.GetSection(nameof(BackgroundMailSenderOptions)));
		}
	}
}