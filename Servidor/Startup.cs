using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Servidor.Startup))]
namespace Servidor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
