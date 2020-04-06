namespace BusinessObjects.BusinessRules
{
    public class ValidateCreditcard : ValidateRegex
    {
        public ValidateCreditcard(string propertyName) :
            base(propertyName, @"^((\d{4}[- ]?){3}\d{4})$")
        {
            ErrorMessage = propertyName + " is not a valid credit card number";
        }

        public ValidateCreditcard(string propertyName, string errorMessage) :
            this(propertyName)
        {
            ErrorMessage = errorMessage;
        }
    }
}