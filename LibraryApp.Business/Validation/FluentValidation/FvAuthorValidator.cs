using FluentValidation;
using LibraryApp.Business.Constants;
using LibraryApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Business.Validation.FluentValidation
{
    public class FvAuthorValidator : AbstractValidator<Author>
    {
        public FvAuthorValidator()
        {
            // First name rules
            RuleFor(a => a.FirstName).NotEmpty().WithMessage(MagicStrings.ValidatorFirstNameNotEmpty);
            RuleFor(a => a.FirstName).MinimumLength(3).WithMessage(MagicStrings.ValidatorFirstNameMinimumLength);

            // Last name rules
            RuleFor(a => a.LastName).NotEmpty().WithMessage(MagicStrings.ValidatorLastNameNotEmpty);
            RuleFor(a => a.LastName).MinimumLength(3).WithMessage(MagicStrings.ValidatorLastNameMinimumLength);

            // Date of birth rules
            RuleFor(a => a.DateOfBirth).NotEmpty().WithMessage(MagicStrings.ValidatorDateOfBirthNotEmpty);
            RuleFor(a => a.DateOfBirth).Must(BeValidAge).WithMessage(MagicStrings.ValidatorDateOfBirthValidAge);
        }

        private bool BeValidAge(DateTime time)
        {
            var currentYear = DateTime.Now.Year;
            var birthYear = time.Year;

            return birthYear >= currentYear
                ? false
                : true;
        }
    }
}
