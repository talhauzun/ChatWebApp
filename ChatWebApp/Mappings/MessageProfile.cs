using AutoMapper;
using ChatWebApp.Models;
using ChatWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWebApp.Mappings
{
    public class MessageProfile : Profile
    {

        public MessageProfile()
        {
            CreateMap<Message, MessageViewModel>()
              .ForMember(dst => dst.From, opt => opt.MapFrom(x => x.FromUser.FullName))
              .ForMember(dst => dst.To, opt => opt.MapFrom(x => x.ToRoom.Name))
              .ForMember(dst => dst.Avatar, opt => opt.MapFrom(x => x.FromUser.Avatar))
              .ForMember(dst => dst.Content, opt => opt.MapFrom(x => x.Content))
              .ForMember(dst => dst.Timestamp, opt => opt.MapFrom(x => x.Timestamp));
            CreateMap<MessageViewModel, Message>();
        }
      
    }
}
