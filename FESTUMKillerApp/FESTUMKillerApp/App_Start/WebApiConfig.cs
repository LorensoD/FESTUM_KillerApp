using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace FESTUMKillerApp.App_Start
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            configuration.Routes.MapHttpRoute(
                "API Default",
                "api/{action}/{id}",
                new { controller = "API", action = "GetThomas", id = UrlParameter.Optional });
        }
    }
}