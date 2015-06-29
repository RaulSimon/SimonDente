using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimonDente.AspNet.Startup))]
namespace SimonDente.AspNet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
