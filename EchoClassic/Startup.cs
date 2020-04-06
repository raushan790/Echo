using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EchoClassic.Startup))]
namespace EchoClassic
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
