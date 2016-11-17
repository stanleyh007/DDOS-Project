using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DeveloperDOtnetStoreProject.Startup))]
namespace DeveloperDOtnetStoreProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
