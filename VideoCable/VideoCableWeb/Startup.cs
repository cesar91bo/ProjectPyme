using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VideoCableWeb.Startup))]
namespace VideoCableWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
