using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PruebaExamen.Startup))]
namespace PruebaExamen
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
