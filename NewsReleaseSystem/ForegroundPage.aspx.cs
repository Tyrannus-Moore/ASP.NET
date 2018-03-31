using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ForegroundPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string sd = "select newsTitle as 标题,pubTime as 时间 from news";
            FlushConnection(sd);
            DBfocus();
        }
    }
    public void FlushConnection(string sd)
    {
        String strConn = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(strConn);
        SqlCommand cmd = new SqlCommand(sd, conn);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        GVinfo.DataSource = dr;
        GVinfo.DataBind();
        conn.Close();
        dr.Close();
    }

    public void DBfocus()
    {
        string sd = "select newsTitle as 标题,newsContent as 内容 from news where classid = 2";
        String strConn = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(strConn);
        SqlCommand cmd = new SqlCommand(sd, conn);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        GVinfo2.DataSource = dr;
        GVinfo2.DataBind();
        conn.Close();
        dr.Close();
    }

    protected void tbSub_Click(object sender, EventArgs e)
    {
        string sd = "select newsTitle as 标题,pubTime as 时间 from news where "+ ddlKind.SelectedItem.Value+" like '%" + tbRetrieve.Text + "%'";
        FlushConnection(sd);
    }
}