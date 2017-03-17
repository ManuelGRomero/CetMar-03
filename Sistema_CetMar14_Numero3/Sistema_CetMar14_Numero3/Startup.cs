using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sistema_CetMar14_Numero3.Startup))]
namespace Sistema_CetMar14_Numero3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
