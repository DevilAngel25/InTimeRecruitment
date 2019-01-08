using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InTimeRecruitment.Startup))]
namespace InTimeRecruitment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
