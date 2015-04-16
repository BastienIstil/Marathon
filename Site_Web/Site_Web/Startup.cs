using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Site_Web.Startup))]
namespace Site_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
