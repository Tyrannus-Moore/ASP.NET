using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.Admin
{
    public partial class top : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Label1.Text = "欢迎! 今天是: " + System.DateTime.Now.ToString("F");
        }
    }
}