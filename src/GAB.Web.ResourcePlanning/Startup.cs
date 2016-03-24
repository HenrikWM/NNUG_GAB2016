using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GAB.Web.ResourcePlanning.Startup))]
namespace GAB.Web.ResourcePlanning
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
