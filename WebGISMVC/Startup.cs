using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebGISMVC.Startup))]
namespace WebGISMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
