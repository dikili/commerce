using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;

namespace MusStore
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //in every api project this is a crucial piece to plug in so that results returned in json
            //will be camel-cased providing the advantage to consumers of this data often the javascript
            //people.


            //---------------------------------------------
            //this enables result to be returned in Json
            //---------------------------------------------


            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
           jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();


           config.Routes.MapHttpRoute(
             name: "RepliesRoute",
             routeTemplate: "api/topics/{topicid}/replies/{id}",
             defaults: new { controller="replies", id = RouteParameter.Optional }
         );


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
