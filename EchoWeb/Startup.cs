using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EchoWeb.Startup))]
namespace EchoWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
