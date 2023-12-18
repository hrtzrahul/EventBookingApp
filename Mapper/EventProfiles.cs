using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookEventApp.Models;

namespace BookEventApp.Mapper
{
    public class EventProfiles : Profile

    {
        public EventProfiles()
        {
            CreateMap<EventModel, EventViewModel>().ReverseMap();
            CreateMap<SignUpModel, SignUpViewModel>().ReverseMap();
            CreateMap<LoginModel, LoginViewModel>().ReverseMap();
            CreateMap<CommentModel, CommentViewModel>().ReverseMap();
        }
    }
}
