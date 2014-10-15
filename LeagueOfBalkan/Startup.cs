using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LeagueOfBalkan.Startup))]
namespace LeagueOfBalkan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
