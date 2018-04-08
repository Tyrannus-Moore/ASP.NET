using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;

public partial class Register : System.Web.UI.Page
{
    static int permitRegi = 0;//0禁止注册，1开放注册权限
    protected void Page_Load(object sender, EventArgs e)
    {
        UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
    }

    protected void btRegister_Click(object sender, EventArgs e)
    {
        string code = Session["ValidateNum"].ToString();
        if (code == tbVC.Text)
        {
            if (permitRegi == 1)
            {
                String strConn = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
                SqlConnection conn = new SqlConnection(strConn);
                string pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(tbAdmPwd.Text, "MD5");
                string sd = "insert into users(username,password) values ('" + tbAdmName.Text + "','" + pwd + "')";
                SqlCommand cmd = new SqlCommand(sd, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Write("<script>alert('注册成功!')</script>");
            }
        }
        else
        {
            lbWarning2.Text = "验证码不正确";
        }
    }

    protected void btLogin_Click(object sender, EventArgs e)
    {
        Server.Transfer("Login.aspx");
    }


    protected void useJSAjax(object sender, EventArgs e)
    {
        String strConn = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        String sd = "select * from users where username like '" + tbAdmName.Text + "'";
        SqlConnection conn = new SqlConnection(strConn);
        SqlCommand cmd = new SqlCommand(sd, conn);
        conn.Open();
        var Result = cmd.ExecuteScalar();
        if (Result == null)
        {
            lbWarning.Text="可以使用";
            permitRegi = 1;
        }
        else
        {
            lbWarning.Text="已经被注册";
            permitRegi = 0;
        }
        conn.Close();
    }
}