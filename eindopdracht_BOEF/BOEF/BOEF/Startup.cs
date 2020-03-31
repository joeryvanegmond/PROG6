using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BOEF.Startup))]
namespace BOEF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
