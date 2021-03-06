﻿namespace BusinessObjects.BusinessRules
{
    public class ValidateLength : BusinessRule
    {
        private int _min;
        private int _max;

        public ValidateLength(string propertyName, int min, int max)
            : base(propertyName)
        {
            _min = min;
            _max = max;

            ErrorMessage = propertyName + " must be between " + _min + " and " + _max + " characters long.";
        }

        public ValidateLength(string propertyName, string errorMessage, int min, int max)
            : this(propertyName, min, max)
        {
            ErrorMessage = errorMessage;
        }

        public override bool Validate(BusinessObject businessObject)
        {
            int length = GetPropertyValue(businessObject).ToString().Length;
            return length >= _min && length <= _max;
        }
    }
}