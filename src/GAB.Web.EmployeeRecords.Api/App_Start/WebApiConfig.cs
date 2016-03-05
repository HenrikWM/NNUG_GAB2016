using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GAB.Web.EmployeeRecords.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "EmployeesApi",
                routeTemplate: "api/employees/{id}",
                defaults: new
                {
                    controller = "EmployeesApi",
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
