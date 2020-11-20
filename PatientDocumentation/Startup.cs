using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PatientDocumentation.Startup))]
namespace PatientDocumentation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
