using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Invensa.Startup))]
namespace Invensa
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
