namespace BusinessObjects.BusinessRules
{
    public class ValidateId : BusinessRule
    {
        public ValidateId(string propertyName)
            : base(propertyName)
        {
            ErrorMessage = propertyName + " is an invalid identifier";
        }

        public ValidateId(string propertyName, string errorMessage)
            : base(propertyName)
        {
            ErrorMessage = errorMessage;
        }

        public override bool Validate(BusinessObject businessObject)
        {
            try
            {
                int id = int.Parse(GetPropertyValue(businessObject).ToString());
                return id >= 0;
            }
            catch
            {
                return false;
            }
        }
    }
}