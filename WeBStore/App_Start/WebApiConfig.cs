using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Web.Http;

namespace WeBStore
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //To ENable CameCasing we need to write these following three lines

            var Setting = config.Formatters.JsonFormatter.SerializerSettings;
            Setting.ContractResolver = new CamelCasePropertyNamesContractResolver();
            Setting.Formatting = Formatting.Indented;


            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
