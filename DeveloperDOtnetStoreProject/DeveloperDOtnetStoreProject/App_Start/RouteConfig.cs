using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DeveloperDOtnetStoreProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Body", action = "Index", id = UrlParameter.Optional }
            );
            // I Idea is that you can make new Routes, but don't know how
            routes.MapRoute(
                "ItemDetailsWithSender",
                "{controller}/{action}/{id}/{pieces}",
                new { controller = "Basket", action = "addPToBasket", id = "", pieces = "" } 
            );
        }
    }
}
