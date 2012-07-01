/////////////////////////////////////////////////
////   NedirTV ASP.Net MVC Öğreniyorum        /// 
////   BookStore(Kitap deposu) uygulaması     /// 
////                                          ///
////   IBRAHIM ATAY 09/11/2010                ///
////                                          ///
/////////////////////////////////////////////////

namespace BookStore.Logger
{
    using System.IO;
    using System.Reflection;
    using System.Web;
    using log4net;

    public class LoggerService
    {
        /// <summary>
        /// log4net ile daha kolay çağırabilmek için static olarak tasarlandı.
        /// </summary>
        public static log4net.ILog Log
        {
            get
            {
                /// GetLogger metodu Type nesenesi almaktadır.
                return log4net.LogManager
                              .GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                /// Log property kullanıldığı üyeyi MethodBase sayesinde,
                /// Log kullanılan method ile ilgili bilgileri edinebiliriz.
            }
        }

        /// <summary>
        /// Bu method ile log4net kütüphanesine, uygulama içerisinde kullanacağı 
        /// yapılandırma ayarlarının yüklenmesi sağlanmaktadır.
        /// </summary>
        /// <param name="context">config dosyaya erişim için uygulama içerisinde geçerli 
        /// HttpContext titpini almaktadır.</param>
        public static void Setup(HttpContext context)
        {
            /// log4net için hazırladığımız config dosyanın adresini oluşturduk.
            string path = context.Server.MapPath("log4net.config");

            /// oluştuduğumuz adresi doğruluğunu test ettik.
            if (File.Exists(path))
            {
                /// config ayarlarını log4net kütüphanesine tanıtmış olduk.
                log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(path));
            }
        }
    }
}
