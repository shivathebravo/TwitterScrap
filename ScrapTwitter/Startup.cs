using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ScrapTwitter.Startup))]
namespace ScrapTwitter
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
