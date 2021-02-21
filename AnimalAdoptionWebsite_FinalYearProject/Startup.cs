using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AnimalAdoptionWebsite_FinalYearProject.Startup))]
namespace AnimalAdoptionWebsite_FinalYearProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
