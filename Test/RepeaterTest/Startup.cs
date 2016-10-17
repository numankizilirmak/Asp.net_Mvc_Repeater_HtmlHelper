using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RepeaterTest.Startup))]
namespace RepeaterTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
