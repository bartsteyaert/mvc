using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Security.Startup))]
namespace MVC_Security
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
