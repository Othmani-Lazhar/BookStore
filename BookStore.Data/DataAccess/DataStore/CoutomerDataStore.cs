namespace BookStore.Data.DataAccess.DataStore
{
    using BookStore.Data.DataAccess.Configuration;
    using BookStore.Entites.Domain;
    using NHibernate;

    public class CoutomerDataStore : BaseDataStore<Coutomer>
    {
        public Coutomer GetCoutomer(string username, string password)
        {
            ISession session = NHibernateHttpModule.CurrentSession;

            return session.QueryOver<Coutomer>()
                          .Where(x => x.Name == username)
                          .Where(x => x.Password == password)
                          .SingleOrDefault();
        }
    }
}
