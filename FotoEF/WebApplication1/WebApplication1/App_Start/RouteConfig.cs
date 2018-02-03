using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.IO;
using System.Web.Optimization;

namespace WebApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.Ignore("{resource}.axd/{*pathInfo}");
            routes.Add("Default", new AppRoute());
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
        }



        public class AppRoute : Route
        {
            public AppRoute() : base("{*path}", new AppRouteHandler()) { this.RouteExistingFiles = false; }
        }
        public class AppRouteHandler : IRouteHandler
        {
            public IHttpHandler GetHttpHandler(RequestContext requestContext)
            {
                return new AppHttpHandler();
            }
        }
        public class AppHttpHandler : IHttpHandler
        {
            public AppHttpHandler()
            { }
            public void ProcessRequest(HttpContext context)
            {
                HttpResponse Response = context.Response;
                string[] css = BundleTable.Bundles.Where(w => w.GetType().Equals(typeof(StyleBundle))).Select(p => p.Path).ToArray();
                string[] js = BundleTable.Bundles.Where(w => w.GetType().Equals(typeof(ScriptBundle))).Select(p => p.Path).ToArray();

                using (StreamReader sr = new StreamReader(HttpContext.Current.Server.MapPath("~/index.html")))//~/views/main.html
                {
                    string template = sr.ReadToEnd();
                    template = template.Replace("{css}", css.Count() == 0 ? "" : Styles.Render(css).ToString());
                    template = template.Replace("{js}", js.Count() == 0 ? "" : Scripts.Render(js).ToString());
                    Response.Write(template);
                }
            }
            public bool IsReusable
            {
                // To enable pooling, return true here.
                // This keeps the handler in memory.
                get { return false; }
            }
        }




    }
}
