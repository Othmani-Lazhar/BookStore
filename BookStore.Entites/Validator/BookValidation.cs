namespace BookStore.Entites.Validator
{
    using BookStore.Entites.Domain;
    using FluentValidation;

    public class BookValidation : AbstractValidator<Book>
    {
        public BookValidation()
        {
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.ISBN).NotNull();
            RuleFor(x => x.Prices).NotNull();
            RuleFor(x => x.InStok).NotNull();
        }
    }
}
