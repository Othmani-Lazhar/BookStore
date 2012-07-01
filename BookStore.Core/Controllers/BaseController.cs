/////////////////////////////////////////////////
////   NedirTV ASP.Net MVC Öğreniyorum        /// 
////   BookStore(Kitap deposu) uygulaması     /// 
////                                          ///
////   IBRAHIM ATAY 09/11/2010                ///
////                                          ///
/////////////////////////////////////////////////

namespace BookStore.Core.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;
    using BookStore.Logger;

    public class BaseController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            LoggerService.Log.Error("Controller", filterContext.Exception);
            base.OnException(filterContext);
        }
    }
}
