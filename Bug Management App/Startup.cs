using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Owin;
 

[assembly: OwinStartupAttribute(typeof(Bug_Management_App.Startup))]
namespace Bug_Management_App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

    }
}
