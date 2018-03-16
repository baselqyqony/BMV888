using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bee_Project.Startup))]
namespace Bee_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
