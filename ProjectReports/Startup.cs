using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectReports.Startup))]
namespace ProjectReports
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
