using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(testlogins.Startup))]
namespace testlogins
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
