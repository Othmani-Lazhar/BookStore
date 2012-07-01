namespace BookStore.Entites.Domain
{
    public class Pulisher : BaseEnty
    {
        public virtual string PulisherName { get; set; }

        public virtual string Addres { get; set; }

        public virtual string Phone { get; set; }

        public virtual string WebAddres { get; set; }

        public virtual string Email { get; set; }
    }
}
