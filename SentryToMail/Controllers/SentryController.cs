using System.Net.Mail;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SentryToMail.API.Domain;
using SentryToMail.API.Model;

namespace SentryToMail.API.Controllers {
	[Route(template: "api/[controller]")]
	[ApiController]
	public class SentryController : Controller {
		private readonly IHostingEnvironment _env;
		private readonly ILogger<SentryController> _logger;
		private readonly IMapper _mapper;
		private readonly IMailClient _smtpClient;
		private readonly IViewRender _viewRender;

		public SentryController(ILogger<SentryController> logger, IHostingEnvironment env, IMailClient smtpClient, IMapper mapper, IViewRender viewRender) {
			_logger = logger;
			_env = env;
			_smtpClient = smtpClient;
			_mapper = mapper;
			_viewRender = viewRender;
		}

		[HttpPost]
		public async Task<IActionResult> PostAsync([FromBody] SentryDataModel dataModel) {
			var mail = _mapper.Map<MailModel>(dataModel);

			if (!_env.IsDevelopment()) {
				if (string.IsNullOrWhiteSpace(mail.Environment) || mail.Environment == "local") {
					_logger.LogInformation(message: "Local environment detected!");
					return StatusCode(statusCode: 400);
				}
				if (mail.Environment == "Production" && !_env.IsProduction()) {
					_logger.LogError(message: "Production environment detected!");
					return StatusCode(statusCode: 400);
				}
				if (mail.Environment != "Production" && !_env.IsStaging()) {
					_logger.LogError(message: "Not dev environment detected!");
					return StatusCode(statusCode: 400);
				}
			}

			string body = _viewRender.Render(name: "Emails/Sentry", mail);

			string from = $"errors-{mail.Environment}@appulate.com";
			string to = _env.IsDevelopment() ? "asalamatov@appulate.com" : $"errors-{mail.Environment}@appulate.com";
			string subject = $"[Error] {mail.Message}";
			var mailMessage = new MailMessage(from, to, subject, body) {
				IsBodyHtml = true
			};

			await _smtpClient.SendMailAsync(mailMessage);
			return Ok();
		}
	}
}