using Maticsoft.Model;
using System;
using System.Collections.Generic;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ibtn_yzm.ImageUrl = "ValidatorCode.aspx";
            //Server.Execute("Login.aspx");
        }

        protected void tbLogin_Click(object sender, EventArgs e)
        {
            BLL.CMS_AdminUser bau = new BLL.CMS_AdminUser();
            string code = tbx_yzm.Text;
            HttpCookie htco = Request.Cookies["ImageV"];
            string scode = htco.Value.ToString();
            if (code != scode)
            {
                Response.Write("<script>alert('验证码输入不正确！')</script>");
            }
            else
            {
                CMS_AdminUser admin = bau.GetModel(tbAdmName.Text);
                if(admin == null)
                {
                    lbWarningName.Text = "用户不存在";
                    return;
                }
                else
                {
                    lbWarningName.Text = "";
                }

                if(admin.Pwd != FormsAuthentication.HashPasswordForStoringInConfigFile(tbAdmPwd.Text, "MD5") )
                {
                    lbWarningPwd.Text = "密码错误";
                    return;
                }
                else
                {
                    lbWarningPwd.Text = "";
                }
                CMS_AdminUser.CurrentAdmin = admin;
                Response.Redirect("Index.aspx");
            }
        }

        protected void tbRegister_Click(object sender, EventArgs e)
        {
            //Server.Transfer("Register.aspx");
        }

    }
}