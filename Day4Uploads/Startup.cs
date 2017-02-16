using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Day4Uploads.Startup))]
namespace Day4Uploads
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
