using System.Web.Http;

namespace GAB.Web.ResourcePlanning
{
    using System.Net.Http.Formatting;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "ResourcePlanning",
                routeTemplate: "api/resourceplanning/{id}",
                defaults: new
                {
                    controller = "ResourcePlanningApi",
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
