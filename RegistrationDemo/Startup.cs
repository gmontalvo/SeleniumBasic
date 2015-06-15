using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RegistrationDemo.Startup))]
namespace RegistrationDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
