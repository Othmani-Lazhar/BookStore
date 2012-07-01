namespace BookStore.Entites.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Coutomer : User
    {
        public virtual IList<Order> Orders { get; set; }
    }
}
