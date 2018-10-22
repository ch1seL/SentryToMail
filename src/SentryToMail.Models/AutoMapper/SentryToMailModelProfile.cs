using System;
using AutoMapper;
using SentryToMail.Models.Extensions;

namespace SentryToMail.Models.AutoMapper {
	public class SentryToMailModelProfile : Profile {
		public SentryToMailModelProfile() {
			CreateMap<SentryDataModel.SentryDataModel, MailModel>()
				.ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Event.Tags.ToNameValue()))
				.ForMember(dest => dest.Exception, opt => opt.MapFrom(src => src.Event.Stacktrace.ToExceptionString()))
				.AfterMap((model, mailModel) => {
					if (mailModel.Id == Guid.Empty) {
						mailModel.Id = Guid.NewGuid();
					}
				});
		}
	}
}