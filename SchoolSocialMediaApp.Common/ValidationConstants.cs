﻿namespace SchoolSocialMediaApp.Common
{
    public class ValidationConstants
    {
        //INFRASTRUCTURE Validation Constants

        //Post Validation Constants
        public const int MaxPostLength = 2000;
        public const int MinPostLength = 2;
        public const string PostContentRequired = "Post content is required.";
        public const string PostIdRequired = "Post id is required.";
        public const string PostDateAndTimeRequired = "Post creation date and time is required.";
        public const string PostCreatorIdRequired = "Post creator id is required.";
        public const string PostSchoolIdRequired = "Post school id is required.";
        public const string PostCreatorRequired = "Post creator is required.";
        public const string PostSchoolRequired = "Post school is required.";


        //Comment Validation Constants
        public const int MaxCommentLength = 1000;

        //User Validation Constants
        public const int MaxUserFirstNameLength = 50;
        public const int MaxUserLastNameLength = 50;

        //Common Validation Constants
        public const int MaxImageUrlLength = 200;

        //School Validation Constants
        public const int MaxSchoolNameLength = 100;
        public const int MaxSchoolDescriptionLength = 1000;
        public const int MaxSchoolLocationLength = 150;

        //Principal Validation Constants

        //Teacher Validation Constants
        public const int MaxSubjectLength = 50;

        //Invitation Validation Constants
        public const int MaxRoleLength = 10;
        public const int MinRoleLength = 2;

        //CORE Validation Constants

        //Login and Register Validation Constants
        public const string PhoneNumberRegEx = @"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$";

        //WEB Validation Constants

        //RegisterViewModel Validation Constants
        public const int MaxFirstNameLength = 50;
        public const int MinFirstNameLength = 2;

        public const int MaxLastNameLength = 50;
        public const int MinLastNameLength = 2;

        public const int MaxEmailLength = 320;
        public const int MinEmailLength = 3;

        public const int MaxPasswordLength = 30;
        public const int MinPasswordLength = 6;

        public const int MaxPhoneNumberLength = 15;
        public const int MinPhoneNumberLength = 7;

        public const string PasswordsDoNotMatch = "Passwords do not match.";
        public const string InvalidEmail = "Invalid Email (Must be between {2} and {1} characters).";
        public const string InvalidPassword = "Invalid Password (Must be between {2} and {1} characters).";
        public const string InvalidFirstName = "Invalid First Name (Must be between {2} and {1} characters).";
        public const string InvalidLastName = "Invalid Last Name (Must be between {2} and {1} characters).";
        public const string InvalidPhoneNumber = "Invalid Phone Number (Must be between {2} and {1} characters).";

        public const string RequiredEmailRegisterViewModel = "Email is required for account creation.";
        public const string RequiredPasswordRegisterViewModel = "Password is required for account creation.";
        public const string RequiredConfirmPasswordRegisterViewModel = "Password confirmation is required for account creation.";
        public const string RequiredFirstNameRegisterViewModel = "First name is required for account creation.";
        public const string RequiredLastNameRegisterViewModel = "Last name is required for account creation.";
        public const string RequiredPhoneNumberRegisterViewModel = "Phone number is required for account creation.";



        //LoginViewModel Validation Constants
        public const string InvalidLogin = "Invalid login.";
        public const string RequiredEmailLoginViewModel = "Email is required for login.";
        public const string RequiredPasswordLoginViewModel = "Password is required for login.";

        //SchoolViewModel Validation Constants
        public const int MinSchoolNameLength = 2;
        public const int MinSchoolDescriptionLength = 5;
        public const int MinImageUrlLength = 8;
        public const int MinSchoolLocationLength = 3;

    }
}