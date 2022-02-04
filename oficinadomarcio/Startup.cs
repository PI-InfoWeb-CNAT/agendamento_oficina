using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(oficinadomarcio.Startup))]
namespace oficinadomarcio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
