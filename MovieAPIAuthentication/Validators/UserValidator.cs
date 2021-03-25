using MovieAPIAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPIAuthentication.Validators
{
    public static class UserValidator
    {
        public static ValidatorResult IsValidUser(TbIuser user) {
            ValidatorResult validatorResult = new ValidatorResult(true);
            if (user == null) {
                validatorResult.IsValid = false;
                validatorResult.ValidationMessage="The user is null.";
                return validatorResult;
            }
            if (user.DateOfBirth == null) {
                validatorResult.IsValid = false;
                validatorResult.ValidationMessage = "The user date of birth is null.";
                return validatorResult;
            }
            if (user.Email.Trim().Equals(""))
            {
                validatorResult.IsValid = false;
                validatorResult.ValidationMessage = "The user email is empty.";
                return validatorResult;
            }
            if (user.FullName.Trim().Equals(""))
            {
                validatorResult.IsValid = false;
                validatorResult.ValidationMessage = "The user Full name is empty.";
                return validatorResult;
            }

            if (user.PhoneNumber.Trim().Equals(""))
            {
                validatorResult.IsValid = false;
                validatorResult.ValidationMessage = "The user phone number is empty.";
                return validatorResult;
            }

            if (user.Gender==0)
            {
                validatorResult.IsValid = false;
                validatorResult.ValidationMessage = "The user gender is null.";
                return validatorResult;
            }

            if (user.Username.Trim().Equals(""))
            {
                validatorResult.IsValid = false;
                validatorResult.ValidationMessage = "The user username is empty.";
                return validatorResult;
            }
            if (user.Password.Trim().Equals(""))
            {
                validatorResult.IsValid = false;
                validatorResult.ValidationMessage = "The user password is empty.";
                return validatorResult;
            }else if (user.Password.Trim().Length<8)
            {
                validatorResult.IsValid = false;
                validatorResult.ValidationMessage = "The user password length is short.Password length must be at less 8 characters.";
                return validatorResult;
            }
            return validatorResult;
        }

    }
}
