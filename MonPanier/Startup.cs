using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MonPanier.Startup))]
namespace MonPanier
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
