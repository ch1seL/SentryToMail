using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace SentryToMail.API {
	internal class Program {
		public static void Main(string[] args) {
			CreateWebHostBuilder(args).Build().Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) {
			return WebHost.CreateDefaultBuilder(args)
			              .UseStartup<Startup>()
			              .ConfigureLogging((hostingContext, logging) => {
				              logging.AddConfiguration(hostingContext.Configuration.GetSection(key: "Logging"));
				              logging.AddConsole();
				              logging.AddDebug();
			              });
		}
	}
}