namespace BookStore.Entites.Domain
{
    using System;
    using System.Collections.Generic;

    public class Order : BaseEnty
    {
        public virtual IList<Book> Books { get; set; }

        public virtual float Price { get; set; }

        public virtual DateTime RecordDate { get; set; }

        public Order()
        {
            this.Books = new List<Book>();
        }
    }
}
