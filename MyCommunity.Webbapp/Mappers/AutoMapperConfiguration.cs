using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace MyCommunity.Webbapp.Mappers
{
    public class AutoMapperConfiguration
    {
        public static void Configuration()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<ModelToViewModel>();
                x.AddProfile<ViewModelToModel>();
            });
        }
    }
}