using AutoMapper;
using SentryToMail.Models;
using SentryToMail.Models.SentryDataModel;

namespace SentryToMail.API.AutoMapper {
	public class SentryToMailModelProfile : Profile {
		public SentryToMailModelProfile() {
			CreateMap<SentryDataModel, MailModel>()
				.AfterMap<TagMapper>();
		}
	}
}