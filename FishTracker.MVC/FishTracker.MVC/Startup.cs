using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FishTracker.MVC.Startup))]
namespace FishTracker.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
