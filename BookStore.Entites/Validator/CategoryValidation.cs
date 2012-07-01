namespace BookStore.Entites.Validator
{
    using FluentValidation;
    using BookStore.Entites.Domain;

    public class CategoryValidation : AbstractValidator<Category>
    {
        public CategoryValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
