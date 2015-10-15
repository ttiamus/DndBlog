using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DndBlog.Startup))]
namespace DndBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
