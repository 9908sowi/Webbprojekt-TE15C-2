using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IGEN.Startup))]
namespace IGEN
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
