using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(LeadLesson.Startup))]

namespace LeadLesson
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
