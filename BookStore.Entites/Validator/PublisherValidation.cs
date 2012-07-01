namespace BookStore.Entites.Validator
{
    using BookStore.Entites.Domain;
    using FluentValidation;

    public class PublisherValidation : AbstractValidator<Pulisher>
    {
        public PublisherValidation()
        {
            RuleFor(x => x.PulisherName).NotEmpty();
            RuleFor(x => x.Phone).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Addres).NotEmpty();
        }
    }
}
