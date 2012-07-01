namespace BookStore.Entites.Validator
{
    using FluentValidation;
    using BookStore.Entites.Domain;

    public class CoustomerValidation : AbstractValidator<Coutomer>
    {
        public CoustomerValidation()
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.RevordDate).NotNull();
        }
    }
}
