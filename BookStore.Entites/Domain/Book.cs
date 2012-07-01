namespace BookStore.Entites.Domain
{
    using System;
    using System.Collections.Generic;

    public class Book : BaseEnty
    {
        public virtual string Name { get; set; }

        public virtual Auther Auther { get; set; }

        public virtual Pulisher Pulisher { get; set; }

        public virtual float Prices { get; set; }

        public virtual string Description { get; set; }

        public virtual DateTime PublisDate { get; set; }

        public virtual bool InStok { get; set; }

        public virtual string ISBN { get; set; }

        public virtual string PicturePath { get; set; }

        public virtual IList<Category> Categories { get; set; }

        public Book()
        {
            this.Categories = new List<Category>();
        }

        public virtual void AddToCategoriy(Category category)
        {
            this.Categories.Add(category);
        }

        public virtual void RemoveToCategory(Category category)
        {
            this.Categories.Remove(category);
        }
    }
}
