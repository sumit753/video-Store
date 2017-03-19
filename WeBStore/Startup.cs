using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WeBStore.Startup))]
namespace WeBStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
