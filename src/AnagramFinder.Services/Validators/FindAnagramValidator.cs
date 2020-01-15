using AnagramFinder.Domains.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
