using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TreeManager.Startup))]
namespace TreeManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
