using System;
using System.Linq;
using AutoMapper;
using SentryToMail.Models.Extensions;

namespace SentryToMail.Models.AutoMapper {
	public class SentryToMailModelProfile : Profile {
		public SentryToMailModelProfile() {
			CreateMap<SentryDataModel.SentryDataModel, MailModel>()
				.AfterMap((model, mailModel) => mailModel.Id = Guid.NewGuid())
				.ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Event.Tags.ToDictionary(k => k[0], v => v[1])))
				.ForMember(dest => dest.Exception, opt => opt.MapFrom(src => src.Event.Exception.Values.Length > 0 ? src.Event.Exception.Values[0].ToExceptionString() : null))
				.ForMember(dest => dest.User, opt => opt.MapFrom(src => src.Event.User))
				.ForMember(dest => dest.Request, opt => opt.MapFrom(src => src.Event.Request));
		}
	}
}