using AutoMapper;
using MyCommunity.Models;
using MyCommunity.Webbapp.Models;
using MyCommunity.Webbapp.ViewModels;

namespace MyCommunity.Webbapp.Mappers
{
    public class ModelToViewModel : Profile
    {
        public override string ProfileName
        {
            get { return "ModelToViewModel"; }
        }

        protected override void Configure()
        {
            CreateMap<Message, MessageViewModel>();
            CreateMap<Message, ReviewMessageViewModel>();
        }
    }
}