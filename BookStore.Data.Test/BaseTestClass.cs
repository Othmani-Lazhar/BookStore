namespace BookStore.Data.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NHibernate;
    using BookStore.Data.DataAccess.Configuration;

    public class BaseTestClass : IDisposable
    {
        public ISession Session;

        public BaseTestClass()
        {
            this.Session = SessionHelper.OpenSession();
        }

        public void Dispose()
        {
            this.Session.Close();
        }
    }
}
