using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Day1AttrRoute.Startup))]
namespace Day1AttrRoute
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
