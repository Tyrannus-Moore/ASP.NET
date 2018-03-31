using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class DetailsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string title = Request.QueryString["标题"];
            DAL.Class1.Flush(lbTitle, lbContent, lbPubTime, lbPublisher, lbReadTimes, title);
        }
        protected void Page_PreRender(object sender, EventArgs e)//   Page_PreRender加载控件时发生
        {
            DropDownList1.SelectedValue = Page.Theme;
        }
        protected void Page_PreInit(object sender, EventArgs e)//   Page_PreInit在页初始化开始时发生。
        {
            if (Session["Theme"] == null)
            {

                Session["Theme"] = "White";
            }
            Page.Theme = (String)Session["Theme"];
        }
        
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["Theme"] = DropDownList1.SelectedValue;
            Response.Write("<script>window.alert(\"设置成功！下次生效~\");</script>");
        }
    }
}