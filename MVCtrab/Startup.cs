using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCtrab.Startup))]
namespace MVCtrab
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
