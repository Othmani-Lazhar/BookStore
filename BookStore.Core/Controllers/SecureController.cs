namespace BookStore.Core.Controllers
{
    using System;
    using System.Web.Mvc;
    using BookStore.Core.Authentication;
    using BookStore.Core.Utils;
    using BookStore.Data.DataAccess.DataStore;
    using BookStore.Entites.Domain;

    public class SecureController : BaseController
    {
        private CoutomerDataStore coustomerDataStore = new CoutomerDataStore();
        private MemberShip membership = new MemberShip();

        public ActionResult Index(FormCollection form)
        {
            string username = "", password = "";

            username = form["username"];
            password = form["password"];

            if (!membership.CoutomerLogin(username, password))
            {
                ViewBag["error"] = "Lütfen Bilgilerinizi Kontrol ediniz...";

                return View();
            }

            return RedirectToAction("/");
        }


        public ActionResult Register(FormCollection from)
        {
            string username, password, email;

            username = from["username"];
            password = from["password"];
            email = from["email"];

            Coutomer ctomer = new Coutomer
            {
                Email = email,
                Name = username,
                Password = Cryptography.GetMD5Hash(password),
                RevordDate = DateTime.Now,
            };

            if (membership.RegisterCoutomer(ctomer))
            {
                return RedirectToAction("Login");
            }

            ViewBag["error"] = "Lüten bilgileriniz kontrol ediniz...";

            return View();
        }
    }
}
