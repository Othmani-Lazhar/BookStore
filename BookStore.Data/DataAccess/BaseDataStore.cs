namespace BookStore.Data.DataAccess
{
    using System.Collections.Generic;
    using System.Linq;
    using BookStore.Data.DataAccess.Configuration;
    using BookStore.Data.DataAccess.Utils;
    using BookStore.Logger;
    using NHibernate;
    using NHibernate.Linq;

    public class BaseDataStore<T> : IRespository<T>
    {
        public object Insert(T item)
        {
            object obj;
            ISession session = NHibernateHttpModule.CurrentSession;

            using (ITransaction transacation = session.BeginTransaction())
            {
                try
                {
                    obj = session.Save(item);
                    session.Flush();
                    transacation.Commit();
                }
                catch (HibernateException ex)
                {
                    obj = null;
                    transacation.Rollback();
                    LoggerService.Log.Error("Data.insert", ex);
                }
            }

            return obj;
        }

        public bool Delete(T item)
        {
            ISession session = NHibernateHttpModule.CurrentSession;

            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    session.Delete(item);
                    session.Flush();
                    transaction.Commit();
                    return true;
                }
                catch (HibernateException ex)
                {
                    transaction.Rollback();
                    LoggerService.Log.Error("Data.Delete", ex);
                    return false;
                }
            }
        }

        public bool Update(T item)
        {
            ISession session = NHibernateHttpModule.CurrentSession;

            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    session.Update(item);
                    session.Flush();
                    transaction.Commit();
                }
                catch (HibernateException ex)
                {
                    transaction.Rollback();
                    LoggerService.Log.Error("Data.Update", ex);
                    return false;
                }
            }

            return false;
        }

        public IList<T> Load()
        {
            ISession session = NHibernateHttpModule.CurrentSession;

            return session.Query<T>().ToList<T>(); /// NHibernate 3 Linq ile sorgulama

            /// return session.CreateQuery("from " + typeof(T).Name).List<T>(); /// HQL sorgulama şekli
        }

        public T Load(int id)
        {
            ISession session = NHibernateHttpModule.CurrentSession;

            return session.Load<T>(id);
        }

        public T Get(int id)
        {
            ISession session = NHibernateHttpModule.CurrentSession;

            return session.Get<T>(id);
        }
    }
}
