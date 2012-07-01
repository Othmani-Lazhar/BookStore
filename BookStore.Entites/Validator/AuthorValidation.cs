namespace BookStore.Entites.Validator
{
    using BookStore.Entites.Domain;
    using FluentValidation;

    public class AuthorValidation : AbstractValidator<Auther>
    {
        public AuthorValidation()
        {
            RuleFor(x => x.AutherName).NotEmpty();
        }
    }
}
