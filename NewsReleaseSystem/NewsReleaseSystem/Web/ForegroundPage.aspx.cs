using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class ForegroundPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sd = "select newsTitle as 标题,pubTime as 时间 from news";
               DAL.Class1.FlushConnection(sd,GVinfo);
               DAL.Class1.DBfocus(GVinfo2);
            }

        }


        protected void tbSub_Click(object sender, EventArgs e)
        {
            string sd = "select newsTitle as 标题,pubTime as 时间 from news where " + ddlKind.SelectedItem.Value + " like '%" + tbRetrieve.Text + "%'";
            DAL.Class1.FlushConnection(sd,GVinfo);
        }
    }
}