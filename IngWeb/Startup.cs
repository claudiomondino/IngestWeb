using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IngWeb.Startup))]
namespace IngWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
