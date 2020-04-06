using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EchoClassic
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          DateTime dt=  DateTime.UtcNow.AddHours(5.5);
            string time = dt.ToShortTimeString();
            //CultureInfo provider = CultureInfo.InvariantCulture;
            //litchk.Text = DateTime.Now.ToShortDateString();
            //DateTime.Parse("11/22/2018");
        }
    }
}