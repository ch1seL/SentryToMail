using System.Threading;
using System.Threading.Tasks;
using SentryToMail.Models;

namespace SentryToMail.Domain {
	public interface IMailSender {
		Task<bool> RenderAndTrySendMail(MailModel mail, CancellationToken cancellationToken = default);
	}
}