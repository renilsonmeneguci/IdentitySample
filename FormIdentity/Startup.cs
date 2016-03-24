using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FormIdentity.Startup))]
namespace FormIdentity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
