using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JumboTronExample.Startup))]
namespace JumboTronExample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           
        }
    }
}
