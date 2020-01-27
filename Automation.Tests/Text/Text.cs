using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Tests.Text
{
    public static class Text
    {
        public static string AccountCreationShortMsg => "New Health Account Created";
        public static string AccountCreationFullMsg => "You have successfully created a new Heath account. Account activation link has been sent to your email. " +
            "Please check your email and activate the account by pressing on the activation link.";

        public static string DateOfBirthErrorMsg_Undersixteen => "You must be over 16 years of age to register with";
        public static string DateOfBirthErrorMsg_Over120 => "Enter a date on or after 01-Jan-1900";
        public static string EmailConfirmationError => "The Email and the Confirmation Email do not match";
        public static string InvalidEmailError => "Enter a valid Email";
        public static string InsecurePasswordError => "Your Password is not secure";
    }

}
