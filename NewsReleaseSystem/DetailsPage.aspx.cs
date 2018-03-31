using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DetailsPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FlushConnection();
    }

    public void FlushConnection()
    {
        String strConn = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(strConn);
        string sd = "select newsTitle as 标题,newsContent as 内容,pubTime as 时间,publisher as 发布者,readTimes as 阅读次数 from news where newsTitle like '" + Request.QueryString["标题"]+"'";
        SqlCommand cmd = new SqlCommand(sd, conn);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            lbTitle.Text = dr[0].ToString();
            lbContent.Text = dr[1].ToString();
            lbPubTime.Text = dr[2].ToString();
            lbPublisher.Text = dr[3].ToString();
            lbReadTimes.Text = dr[4].ToString();
        }
        dr.Close();
        sd = "update news set readTimes = readTimes + 1 where newsTitle like '" + Request.QueryString["标题"] + "'";
        SqlCommand cmd2 = new SqlCommand(sd, conn);
        cmd2.ExecuteNonQuery();
        conn.Close();
    }

    //主题
    protected void Page_PreInit(object sender, EventArgs e)//   Page_PreInit在页初始化开始时发生。
    {
        if (Session["Theme"] == null)
        {

            Session["Theme"] = "White";
        }
        Page.Theme = (String)Session["Theme"];
    }

    protected void Page_PreRender(object sender, EventArgs e)//   Page_PreRender加载控件时发生
    {
        DropDownList1.SelectedValue = Page.Theme;
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["Theme"] = DropDownList1.SelectedValue;
        Response.Write("<script>window.alert(\"设置成功！下次生效~\");</script>");
    }
}