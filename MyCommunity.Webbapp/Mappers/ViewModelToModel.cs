using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MyCommunity.Models;
using MyCommunity.Webbapp.ViewModels;

namespace MyCommunity.Webbapp.Mappers
{
    public class ViewModelToModel : Profile
    {
        public override string ProfileName {
            get { return "ViewModelToModel"; }
        }

        protected override void Configure()
        {
            CreateMap<MessageSendViewModel, Message>();
        }
    }
}