using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SentryToMail.Configurations.Options;
using SentryToMail.Models;
using SentryToMail.Utils;

namespace SentryToMail.Domain {
	public class MailQueueRepository : IMailQueueRepository {
		private readonly ILogger<MailQueueRepository> _logger;
		private readonly FileCollection<MailModel> _mailQueueRepository;

		public MailQueueRepository(IOptions<RepositoriesOptions> repositoryOptionsAccessor, ILogger<MailQueueRepository> logger) {
			_logger = logger;
			_mailQueueRepository = new FileCollection<MailModel>(Path.Combine(repositoryOptionsAccessor.Value.Path, nameof(MailQueueRepository)));
		}

		public Task<MailModel[]> PeekMailQueue() {
			return _mailQueueRepository.PeekAll();
		}

		public void Delete(Guid mailId) {
			_logger.LogInformation($"Delete mail {mailId} from repository");
			_mailQueueRepository.Delete(mailId);
			_logger.LogInformation($"Mail {mailId} has been deleted from repository!");
		}

		public async Task Add(MailModel mail) {
			_logger.LogInformation($"Delete mail {mail.Id} from repository");
			await _mailQueueRepository.Add(mail.Id, mail);
			_logger.LogInformation($"Mail {mail.Id} has been added to repository!");
		}
	}
}