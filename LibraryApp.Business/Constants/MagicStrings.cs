using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Business.Constants
{
    public static class MagicStrings
    {
        // Validation error messages
        public const string ValidatorFirstNameNotEmpty = "First name field cannot be left empty.";
        public const string ValidatorFirstNameMinimumLength = "First name field cannot be shorter than three characters.";
        public const string ValidatorLastNameNotEmpty = "Last name field cannot be left empty.";
        public const string ValidatorLastNameMinimumLength = "Last name field cannot be shorter than three characters.";
        public const string ValidatorDateOfBirthNotEmpty = "Birth of date field cannot be left empty.";
        public const string ValidatorDateOfBirthValidAge = "Birth of date is no valid.";
        public const string ValidatorTitleNotEmpty = "Title field cannot be left empty";
        public const string ValidatorTitleMinimumLength = "Title field cannot be shorter than three characters.";
        public const string ValidatorGenreNotEmpty = "Genre field cannot be left empty.";
        public const string ValidatorGenreMinimumLength = "Genre field cannot be shorter than three characters";
        public const string ValidatorAuthorIdNotEmpty = "Author field cannot be left empty.";
        public const string ValidatorPublishDateNotEmpty = "Publish date field cannot be left empty.";
        public const string ValidatorPublishDateNotValid = "Publish date field is not valid.";
        public const string ValidatorIsbnNotEmpty = "ISBN field is cannot be left empty.";
        public const string ValidatorIsbnMinimumLength = "ISBN field cannot be shorter than three characters.";
        public const string ValidatorCopiesAvailableNotEmpty = "Copies available field cannot be left empty.";
        public const string ValidatorCopiesAvailableGreaterThan = "Copies available field cannot be less than zero";
    }
}
