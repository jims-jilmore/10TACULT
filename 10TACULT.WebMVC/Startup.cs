using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_10TACULT.WebMVC.Startup))]
namespace _10TACULT.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
