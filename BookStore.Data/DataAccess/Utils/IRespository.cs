namespace BookStore.Data.DataAccess.Utils
{
    using System.Collections.Generic;

    public interface IRespository<T>
    {
        object Insert(T item);

        bool Delete(T item);

        bool Update(T item);

        IList<T> Load();

        T Load(int id);

        T Get(int id);
    }
}
