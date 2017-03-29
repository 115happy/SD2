using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace VetTrainer
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var jsonPakSetting = config.Formatters.JsonFormatter.SerializerSettings;
            jsonPakSetting.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonPakSetting.Formatting = Formatting.Indented;
            //jsonPakSetting.PreserveReferencesHandling = PreserveReferencesHandling.Objects; // 解决循环引用

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
