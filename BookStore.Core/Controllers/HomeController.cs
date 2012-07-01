/////////////////////////////////////////////////
////   NedirTV ASP.Net MVC Öğreniyorum        /// 
////   BookStore(Kitap deposu) uygulaması     /// 
////                                          ///
////   IBRAHIM ATAY 09/11/2010                ///
////                                          ///
/////////////////////////////////////////////////

namespace BookStore.Core.Controllers
{
    using System.Web.Mvc;

    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
