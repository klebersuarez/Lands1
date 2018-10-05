using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lands1.Backend.Startup))]
namespace Lands1.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
