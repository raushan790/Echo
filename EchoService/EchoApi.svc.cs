using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BusinessObjects;
using DataObjects;
using System.ComponentModel;

namespace EchoService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class EchoApi : IEchoApi
    {

        public User GetUser(string UserName, string Password)
        {
            User chkUserDetails = null;
            try
            {

                if (chkUserDetails == null)
                {
                    chkUserDetails = DataAccess.UserDao.GetUser(UserName, Password);
                }

                return chkUserDetails;

            }
            catch (Exception)
            {

                throw;
            }
        }

       public string CreateUser(User u)
        {
            try
            {
                string userID = DataAccess.UserDao.CreateUser(u);
                return userID;
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
