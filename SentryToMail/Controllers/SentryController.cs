using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SentryToMail.API.Domain;
using SentryToMail.API.Model;

namespace SentryToMail.API.Controllers {
	[Route(template: "api/[controller]")]
	[ApiController]
	public class SentryController : Controller {
		private readonly IHostingEnvironment _env;
		private readonly ILogger<SentryController> _logger;
		private readonly IMapper _mapper;
		private readonly IMailSender _mailSender;

		public SentryController(ILogger<SentryController> logger, IHostingEnvironment env, SmtpClient smtpClient, IMapper mapper, IMailSender mailSender) {
			_logger = logger;
			_env = env;
			_mapper = mapper;
			_mailSender = mailSender;
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
					_logger.LogError(message: "Not development environment detected!");
					return StatusCode(statusCode: 400);
				}
			}

			await _mailSender.TryRenderSendOrAddToQueue(mail);
			return Ok();
		}
	}
}