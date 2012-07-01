namespace BookStore.Data.DataAccess.Configuration
{
    using System;
    using System.Linq;
    using NHibernate;
    using NHibernate.Linq; /// Nhibernate Linq namespace
    using BookStore.Entites.Domain;

    public class EntryDataContext
    {
        private readonly ISession session;

        public EntryDataContext(ISession session)
        {
            this.session = session;
        }

        public EntryDataContext()
        {
            this.session = NHibernateHttpModule.CurrentSession;
        }

        public IQueryable<Book> Books
        {
            get
            {
                return session.Query<Book>();
            }
        }

        public IQueryable<Auther> Authers
        {
            get
            {
                return session.Query<Auther>();
            }
        }

        public IQueryable<Category> Categories
        {
            get
            {
                return session.Query<Category>();
            }
        }

        public IQueryable<Employee> Employees
        {
            get
            {
                return session.Query<Employee>();
            }
        }

        public IQueryable<Coutomer> Coutomers
        {
            get
            {
                return session.Query<Coutomer>();
            }
        }

        public IQueryable<Pulisher> Pulishers
        {
            get
            {
                return session.Query<Pulisher>();
            }
        }

        public IQueryable<Order> Orders
        {
            get
            {
                return session.Query<Order>();
            }
        }
    }
}
