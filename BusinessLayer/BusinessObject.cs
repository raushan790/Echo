using System.Collections.Generic;
using BusinessObjects.BusinessRules;

namespace BusinessObjects
{
    [System.Serializable]
    public abstract class BusinessObject
    {
        protected static readonly string _versionDefault = "NotSet";
        private IList<string> _validationErrors = new List<string>();
        private IList<BusinessRule> _businessRules = new List<BusinessRule>();

        public IList<string> ValidationErrors
        {
            get { return _validationErrors; }
        }

        protected void AddRule(BusinessRule rule)
        {
            _businessRules.Add(rule);
        }

        public bool Validate()
        {
            bool isValid = true;

            _validationErrors.Clear();

            foreach (BusinessRule rule in _businessRules)
            {
                if (!rule.Validate(this))
                {
                    isValid = false;
                    _validationErrors.Add(rule.ErrorMessage);
                }
            }
            return isValid;
        }
    }
}