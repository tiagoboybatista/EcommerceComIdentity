using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MeuEcommerce.Startup))]
namespace MeuEcommerce
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
