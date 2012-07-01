namespace BookStore.Core.Extensions
{
    using System.Globalization;
    using System.Web;
    using System.Web.Mvc;
    using BookStore.Core.Controllers;

    public static class LanguageResourceHelper
    {
        public static string Resource(this HtmlHelper h, string valueName)
        {
            BaseController controller = new BaseController();
            CultureInfo info = new CultureInfo(HttpContext.Current.Request.UserLanguages[0]);

            return HttpContext.GetGlobalResourceObject("Resource", valueName, info).ToString();
        }
    }
}
