using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(E_Comerce.WebUI.Startup))]
namespace E_Comerce.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
