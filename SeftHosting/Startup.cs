using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace SeftHosting
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var configuration = new HttpConfiguration();
            configuration.Routes.MapHttpRoute(
                                name: "DafaultApi",
                                routeTemplate: "api/{controller}/{id}",
                                defaults: new {id = RouteParameter.Optional});

            appBuilder.UseWebApi(configuration);
        }
    }
}
