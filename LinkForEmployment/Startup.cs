using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LinkForEmployment.Startup))]
namespace LinkForEmployment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
