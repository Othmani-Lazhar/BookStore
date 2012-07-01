namespace BookStore.Entites.Domain
{
    using System;

    public class User : BaseEnty
    {
        public virtual string Name { get; set; }

        public virtual string Email { get; set; }

        public virtual string Password { get; set; }

        public virtual DateTime RevordDate { get; set; }

        public virtual DateTime LoginLastDate { get; set; }
    }
}
