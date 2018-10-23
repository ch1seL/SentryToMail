using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SentryToMail.Domain;
using SentryToMail.Models;
using SentryToMail.Models.SentryDataModel;

namespace SentryToMail.API.Controllers {
	[Route(template: "api/[controller]")]
	[ApiController]
	public class SentryController : Controller {
		private readonly ILogger<SentryController> _logger;
		private readonly IMapper _mapper;
		private readonly IMailSender _mailSender;
		private readonly IMailQueueRepository _mailQueueRepository;

		public SentryController(ILogger<SentryController> logger, IMapper mapper, IMailSender mailSender, IMailQueueRepository mailQueueRepository) {
			_logger = logger;
			_mapper = mapper;
			_mailSender = mailSender;
			_mailQueueRepository = mailQueueRepository;
		}

		[HttpPost]
		public async Task<IActionResult> PostAsync([FromBody] SentryDataModel dataModel) {
			var mail = _mapper.Map<MailModel>(dataModel);

			if (!TryCheckEnvironment(mail.Environment, out string error)) {
				_logger.LogInformation(error);
				return BadRequest(new { Error = error });
			}

			if (await _mailSender.RenderAndTrySendMail(mail)) {
				return Ok(new { Result = $"Mail {mail.Id} sended" });
			}
			await _mailQueueRepository.Add(mail);
			return Ok(new { Result = $"Mail {mail.Id} queued" });
		}

		[HttpGet("throw")]
		public IActionResult Throw() {
			throw new Exception("throw test exception");
		}

		private bool TryCheckEnvironment(string mailEnvironment, out string wrongEnvironmentError) {
			wrongEnvironmentError = null;

			if (string.IsNullOrWhiteSpace(mailEnvironment) || mailEnvironment == "local") {
				wrongEnvironmentError = "Empty or Local environment detected!";
			} 

			return wrongEnvironmentError == null;
		}
	}
}