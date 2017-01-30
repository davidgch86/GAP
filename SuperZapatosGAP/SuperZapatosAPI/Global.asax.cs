using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace SuperZapatosAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            // Allow expose services in xml and json format
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(
                new QueryStringMapping("type", "json", new MediaTypeHeaderValue("application/json")));

            GlobalConfiguration.Configuration.Formatters.XmlFormatter.MediaTypeMappings.Add(
                new QueryStringMapping("type", "xml", new MediaTypeHeaderValue("application/xml")));
        }
    }
}
