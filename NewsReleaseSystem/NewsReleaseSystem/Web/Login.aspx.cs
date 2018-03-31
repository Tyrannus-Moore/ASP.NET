using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ibtn_yzm.ImageUrl = "ImageCode.aspx";
            //Server.Execute("Login.aspx");
        }

        protected void tbLogin_Click(object sender, EventArgs e)
        {
            string code = tbx_yzm.Text;
            HttpCookie htco = Request.Cookies["ImageV"];
        string scode = htco.Value.ToString();
        if (code != scode)
        {
            Response.Write("<script>alert('验证码输入不正确！')</script>");
        }
        else {
            if (DAL.Class1.CheckUser(tbAdmName.Text, tbAdmPwd.Text))
            {
                Session["ValidateName"] = tbAdmName.Text;
                Server.Transfer("BackgroundPage.aspx");
            }
            else {
                BLL.Class1.CheckUser(DAL.Class1.CheckUser(lbWarningName.Text, lbWarningPwd.Text), Label1);
            }
        }
        }

        protected void tbRegister_Click(object sender, EventArgs e)
        {
            Server.Transfer("Register.aspx");
        }
    }
}