using AnagramFinder.Domains.Requests;
using FluentValidation;

namespace AnagramFinder.Services.Validators
{
    public class FindAnagramValidator : AbstractValidator<FindAnagramRequest>
    {
        public FindAnagramValidator()
        {
            RuleFor(property => property.Word)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(1400);
        }
    }
}
