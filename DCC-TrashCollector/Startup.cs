using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DCC_TrashCollector.Startup))]
namespace DCC_TrashCollector
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
