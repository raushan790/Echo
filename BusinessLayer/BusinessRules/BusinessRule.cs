namespace BusinessObjects.BusinessRules
{
    public abstract class BusinessRule
    {
        public string PropertyName { get; set; }

        public string ErrorMessage { get; set; }

        public BusinessRule(string propertyName)
        {
            PropertyName = propertyName;
            ErrorMessage = propertyName + " is not valid";
        }

        public BusinessRule(string propertyName, string errorMessage)
            : this(propertyName)
        {
            ErrorMessage = errorMessage;
        }

        public abstract bool Validate(BusinessObject businessObject);

        protected object GetPropertyValue(BusinessObject businessObject)
        {
            return businessObject.GetType().GetProperty(PropertyName).GetValue(businessObject, null);
        }
    }
}