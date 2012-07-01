namespace BookStore.Data.DataAccess.Configuration
{
    using NHibernate;
    using NHibernate.Cfg;

    public class SessionHelper
    {
        private static ISessionFactory sessionFactory;

        public static ISession OpenSession()
        {
            ISession session;
            session = SessionFactor().OpenSession();

            return session;
        }

        public static void CloseSession()
        {
            NHibernateHttpModule.CurrentSession.Close();
        }

        private static ISessionFactory SessionFactor()
        {
            if (sessionFactory == null)
            {
                Configuration config = new Configuration();

                /// xml yapılandırma dosyası kullanmak için 
                config.Configure();

                //config.SetProperty("connection.driver_class", "NHibernate.Driver.SqlClientDriver");
                //config.SetProperty("connection.connection_string", @"Server=.\sqlexpress;Database=BookStoreDB;User Id=sa;pwd=123;");
                //config.SetProperty("dialect", "NHibernate.Dialect.MsSql2005Dialect");
                //config.SetProperty("query.substitutions", "true=1;false=0");
                //config.SetProperty("proxyfactory.factory_class", "NHibernate.ByteCode.Castle.ProxyFactoryFactory, NHibernate.ByteCode.Castle");
                //config.SetProperty("hibernate.show_sql", "true");

                //config.AddAssembly("BookStore.Entites");

                //config.SetProperty("hbm2ddl.keywords", "auto-quote");
                //config.SetProperty("hibernate.cache.provider_class", "NHibernate.Caches.SysCache.SysCacheProvider, NHibernate.Caches.SysCache");

                sessionFactory = config.BuildSessionFactory();
            }

            return sessionFactory;
        }
    }
}
