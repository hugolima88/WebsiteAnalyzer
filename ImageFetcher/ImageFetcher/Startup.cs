using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ImageFetcher.Startup))]
namespace ImageFetcher
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
