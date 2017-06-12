using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BierenMetSecurity.Startup))]
namespace BierenMetSecurity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
