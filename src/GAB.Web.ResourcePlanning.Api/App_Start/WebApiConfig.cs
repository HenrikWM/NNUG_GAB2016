using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GAB.Web.ResourcePlanning.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "ResourcePlanningForEmployeeApi",
                routeTemplate: "api/resourceplanning/plan/employee/{employeeId}",
                defaults: new
                {
                    controller = "ResourcePlanningForEmployee",
                    action = "planForEmployee"
                }
            );

            config.Routes.MapHttpRoute(
                name: "ResourcePlanningApi",
                routeTemplate: "api/resourceplanning/{id}",
                defaults: new
                {
                    controller = "ResourcePlanning",
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
