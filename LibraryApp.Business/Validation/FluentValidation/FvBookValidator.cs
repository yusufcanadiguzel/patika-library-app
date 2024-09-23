using FluentValidation;
using LibraryApp.Business.Constants;
using LibraryApp.Entities.Concrete;

namespace LibraryApp.Business.Validation.FluentValidation
{
    public class FvBookValidator : AbstractValidator<Book>
    {
        public FvBookValidator()
        {
            // Title rules
            RuleFor(b => b.Title).NotEmpty().WithMessage(MagicStrings.ValidatorTitleNotEmpty);
            RuleFor(b => b.Title).MinimumLength(3).WithMessage(MagicStrings.ValidatorTitleMinimumLength);

            // Author Id rules
            RuleFor(b => b.AuthorId).NotEmpty().WithMessage(MagicStrings.ValidatorAuthorIdNotEmpty);

            // Genre rules
            RuleFor(b => b.Genre).NotEmpty().WithMessage(MagicStrings.ValidatorGenreNotEmpty);
            RuleFor(b => b.Genre).MinimumLength(3).WithMessage(MagicStrings.ValidatorGenreMinimumLength);

            // Publish Date rules
            RuleFor(b => b.PublishDate).NotEmpty().WithMessage(MagicStrings.ValidatorPublishDateNotEmpty);
            RuleFor(b => b.PublishDate).Must(BeValidDate).WithMessage(MagicStrings.ValidatorGenreMinimumLength);

            // ISBN rules
            RuleFor(b => b.ISBN).NotEmpty().WithMessage(MagicStrings.ValidatorIsbnNotEmpty);
            RuleFor(b => b.ISBN).MinimumLength(3).WithMessage(MagicStrings.ValidatorIsbnMinimumLength);

            // Copies available rules
            RuleFor(b => b.CopiesAvailable).NotEmpty().WithMessage(MagicStrings.ValidatorCopiesAvailableNotEmpty);
            RuleFor(b => b.CopiesAvailable).GreaterThan(-1).WithMessage(MagicStrings.ValidatorCopiesAvailableGreaterThan);
        }

        private bool BeValidDate(DateTime time)
        {
            var currentYear = DateTime.Now.Year;
            var publishYear = time.Year;

            return publishYear >= currentYear
                ? false
                : true;
        }
    }
}
