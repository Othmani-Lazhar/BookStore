////////////////////////////////////////////////
////   NedirTV ASP.Net MVC Öğreniyorum        /// 
////   BookStore(Kitap deposu) uygulaması     /// 
////                                          ///
////   IBRAHIM ATAY                           ///
////                                          ///
////////////////////////////////////////////////

namespace BookStore.Web
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using BookStore.Logger;
    using Spark.Web.Mvc;

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Book", action = "List", id = UrlParameter.Optional });
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            /// Spark View Engine kayit işlemi
            /// ViewEngines.Engines.Add(new SparkViewFactory()); /// Spark View Engine v1
            SparkEngineStarter.RegisterViewEngine(); /// Spark View Engine v1.5

            /// log4net uygulama içinde kayıt ettik.
            LoggerService.Setup(HttpContext.Current);

            ///log4net uygulama başladığını yazdık.
            LoggerService.Log.Warn("BookStore - Start !");
        }
    }
}