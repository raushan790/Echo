using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using CommonControls.ActionServiceReference;


namespace Controllers
{
    public class AuthenticationController : ControllerBase
    {
        /// <summary>
        /// GetToken must be the first call into web service. 
        /// This is irrespective of whether user is logging in or not.
        /// </summary>
        /// <returns>Unique access token that is valid for the duration of the session.</returns>
        public string GetToken()
        {
            TokenRequest request = new TokenRequest();
            request.RequestId = NewRequestId;
            request.ClientTag = ClientTag;
            
            TokenResponse response = ActionServiceClient.GetToken(request);            
            
            if (request.RequestId != response.CorrelationId)
                throw new ApplicationException("GetToken: RequestId and CorrelationId do not match.");
            return response.AccessToken;
        }

        /// <summary>
        /// Login to the system.
        /// </summary>
        /// <param name="username">User name.</param>
        /// <param name="password">Password.</param>
        /// <returns>Success or failure flag.</returns>
        public bool Login(string username, string password, out string _UserID)
        {
            LoginRequest request = new LoginRequest();
            request.RequestId = NewRequestId;
            request.ClientTag = ClientTag;
            request.AccessToken = AccessToken;

            request.UserName = username;
            request.Password = password;
            LoginResponse response = ActionServiceClient.Login(request);
            

            _UserID = response.UserID;
            return (response.Acknowledge == AcknowledgeType.Success);
        }

        /// <summary>
        /// Logout from from the system.
        /// </summary>
        /// <returns>Success or failure flag.</returns>
        public bool Logout()
        {
            LogoutRequest request = new LogoutRequest();
            request.RequestId = NewRequestId;
            request.ClientTag = ClientTag;
            request.AccessToken = AccessToken;

            LogoutResponse response = ActionServiceClient.Logout(request);
            

            return (response.Acknowledge == AcknowledgeType.Success);
        }
    }
}
