using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MyCommunity.Models;
using MyCommunity.Webbapp.ViewModels;
using MyCommunity.Webbapp.Models;

namespace MyCommunity.Webbapp.Mappers
{
    public class ViewModelToModel : Profile
    {
        public override string ProfileName {
            get { return "ViewModelToModel"; }
        }

        protected override void Configure()
        {
           //CreateMap<MessageViewModel, Message>();
            //CreateMap<UserViewModel, ApplicationUser>();

            CreateMap<MessageViewModel, Message>();
            CreateMap<ReviewMessageViewModel, Message>();
            CreateMap<GroupViewModel, Group>();
            CreateMap<CreateGroupViewModel, Group>();
        }
    }
}