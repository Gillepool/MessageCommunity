using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyCommunity.Webbapp.Startup))]
namespace MyCommunity.Webbapp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
