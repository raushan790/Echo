using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Controllers
{
    public class ControllerBase
    {
        /// <summary>
        /// Client tag provided by the service provider and stored locally. 
        /// This value must be provided with every service call.
        /// </summary>
        protected static string ClientTag { get; private set; }

        /// <summary>
        /// Static constructor
        /// </summary>
        static ControllerBase()
        {
            // Retrieve ClientTag from web config file
            ClientTag = ConfigurationManager.AppSettings.Get("ClientTag");
        }

        /// <summary>
        /// Gets a new random GUID request id.
        /// </summary>
        protected string NewRequestId
        {
            get { return Guid.NewGuid().ToString(); }
        }

        private static System.Text.RegularExpressions.Regex isGuid = new System.Text.RegularExpressions.Regex(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", System.Text.RegularExpressions.RegexOptions.Compiled);
        internal static bool IsGuid(string candidate)
        {
            bool isValid = false;

            if (candidate != null)
            {
                if (isGuid.IsMatch(candidate))
                {
                    isValid = true;
                }
            }
            return isValid;
        }
    }
}
