using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Get_A_Job.Startup))]
namespace Get_A_Job
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
