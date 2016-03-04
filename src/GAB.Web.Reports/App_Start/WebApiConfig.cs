using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GAB.Web.Reports
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Reports",
                routeTemplate: "api/reports/{id}",
                defaults: new
                {
                    controller = "Reports",
                    id = RouteParameter.Optional
                }
            );

            ConfigureJsonCamelCasing();
        }

        private static void ConfigureJsonCamelCasing()
        {
            MediaTypeFormatterCollection formatters = GlobalConfiguration.Configuration.Formatters;
            JsonMediaTypeFormatter jsonFormatter = formatters.JsonFormatter;

            JsonSerializerSettings settings = jsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
