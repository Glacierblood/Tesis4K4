using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinalTest1.Startup))]
namespace FinalTest1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
