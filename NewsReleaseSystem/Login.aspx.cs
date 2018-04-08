using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    static int errorTimes=0;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void tbLogin_Click(object sender, EventArgs e)
    {
        lbWarningName.Text = "";
        lbWarningPwd.Text = "";
        lbWarningVF.Text = "";

        if (errorTimes < 3)
        {
            LoginBegin();
        }
        else
        {
            string code = Session["ValidateNum"].ToString();
            PanelVF.Visible = true;
            if (code == tbVF.Text)
            {
                LoginBegin();
            }
            else
            {
                if (errorTimes > 3)
                {
                    lbWarningVF.Text = "验证码错误";
                }
                errorTimes++;
            }
        }
    }

    protected void tbRegister_Click(object sender, EventArgs e)
    {
        Server.Transfer("Register.aspx");
    }

    public void LoginBegin()
    {
        String strConn = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(strConn);
        string pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(tbAdmPwd.Text, "MD5");
        string sd = "select * from users where username like '" + tbAdmName.Text+"'";
        string sd2 = "select * from users where username like '" + tbAdmName.Text + "' and password like '" + pwd + "'";
        SqlCommand cmd = new SqlCommand(sd, conn);
        conn.Open();
        var Result = cmd.ExecuteScalar();
        if (Result == null)
        {
            lbWarningName.Text = "用户名不存在";
            errorTimes++;
        }
        else
        {
            cmd = new SqlCommand(sd2, conn);
            Result = cmd.ExecuteScalar();
            if (Result == null)
            {
                lbWarningPwd.Text = "密码错误";
                errorTimes++;
            }
            else
            {
                Session["ValidateName"] = tbAdmName.Text;
                Server.Transfer("BackgroundPage.aspx");
            }
        }
        conn.Close();
    }
}