/////////////////////////////////////////////////
////   NedirTV ASP.Net MVC Öğreniyorum        /// 
////   BookStore(Kitap deposu) uygulaması     /// 
////                                          ///
////   IBRAHIM ATAY                           ///
////                                          ///
/////////////////////////////////////////////////

namespace BookStore.Core.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Mvc;
    using BookStore.Core.Configuration;
    using BookStore.Data.DataAccess.DataStore;
    using BookStore.Entites.Domain;
    using BookStore.Entites.Validator;

    public class BookController : BaseController
    {
        private BookDataStore bookdatastore = new BookDataStore();
        private AutherDataStore autherDataStore = new AutherDataStore();
        private PulisherDataStore pulisherDataStore = new PulisherDataStore();
        private CategoryDataStore categoryDataStore = new CategoryDataStore();

        public ActionResult Index()
        {
            return View();
        } /// varsayılan actionresult

        public ActionResult List()
        {
            IList<Book> books = this.bookdatastore.Load();

            return View(books);
        }

        public ActionResult Detail(int id) /// id degeri gelen book nesnesini gönderir.
        {
            Book book = this.bookdatastore.Load(id);

            ViewData["Name"] = book.Name;
            ViewData["Prices"] = book.Prices;
            ViewData["Description"] = book.Description;

            return View();
        }

        /// <summary>
        /// Kitap nesnesinin ekleme için kullanılan sayfayı kullanıcıya gönderir.
        /// </summary>
        public ActionResult Add()
        {
            /// DopDown help nesnesi için kullanılmaktadır.
            /// kullanımda;
            /// new SelectList("veri kaynağı", "değeri/value", "görünen/Text") şeklinde kullanılmaktadır.
            ViewData["autherlist"] = new SelectList(this.autherDataStore.Load(), "ID", "AutherName", 0);
            ViewData["Pulisher"] = new SelectList(this.pulisherDataStore.Load(), "ID", "PulisherName", 0);
            ViewData["Categorylist"] = new SelectList(this.categoryDataStore.Load(), "ID", "Name", 0);

            if (Session["Error"] != null)
            {
                ///ViewData["Error"] = Session["Error"]; /// ASP.Net MVC 2 
                ViewBag.Error = Session["Error"]; /// ASP.Net MVC 3
            }

            return View();
        }

        public ActionResult Save(
                                HttpPostedFile image,
                                string Name,
                                string Description,
                                string Category,
                                DateTime PublisDate,
                                string ISBN,
                                string Prices,
                                string InStok,
                                string Auther,
                                string Pulisher
                               )
        {
            BookValidation validation = new BookValidation();

            BookStore.Entites.Domain.Pulisher publisher = this.pulisherDataStore.Load(int.Parse(Pulisher));
            Auther auther = this.autherDataStore.Load(int.Parse(Auther));
            Category category = this.categoryDataStore.Load(int.Parse(Category));
            string imageuploadpath = "";

            if (image != null)
            {

                imageuploadpath = Server.MapPath(XmlConfigurator.GetSetting().PictureUploadFolder + Guid.NewGuid() + image.FileName);

                ///http://www.cs.tut.fi/~jkorpela/forms/file.html 
                ///form üzerinde image yada farklı türde veri almak için bakılması önerilir.
                image.SaveAs(imageuploadpath);
            }

            Book book = new Book
            {
                Name = Name,
                Description = Description,
                InStok = (InStok == null ? false : true),
                ISBN = ISBN,
                PublisDate = PublisDate,
                Pulisher = publisher,
                Auther = auther,
                PicturePath = imageuploadpath,
            };

            /// veri katmanında(Data), bu şekilde (kategori ekleme) fonksiyonları hazırlanması 
            /// kodlama esnasında kolaylıklar sağlamaktadır.
            book.AddToCategoriy(category); /// Book nesnesine dahil olmasını istediğimiz kategoriye ekliyoruz.

            //Kullanıcı istenildiği gibi nesne içeriğini doldurup / doldurmadığını
            //kontrol etmektedir.
            if (validation.Validate(book).IsValid)
            {
                this.bookdatastore.Insert(book);

                return RedirectToAction("List");
            }

            Session["Error"] = "Lütfen gerekli alanları doldurunuz...";

            return RedirectToAction("Add");
        }

        public ActionResult Delete(Book book)
        {
            this.bookdatastore.Delete(book);

            return RedirectToAction("List");
        }

        public ActionResult Update(Book book, int id)
        {
            book.ID = id;

            this.bookdatastore.Update(book);

            return RedirectToAction("List");
        }
    }
}
