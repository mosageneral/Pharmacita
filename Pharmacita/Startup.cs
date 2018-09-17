using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pharmacita.Startup))]
namespace Pharmacita
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
