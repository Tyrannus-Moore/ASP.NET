using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Register1 : System.Web.UI.Page
    {
        static int permitRegi = 0;//0禁止注册，1开放注册权限
        protected void Page_Load(object sender, EventArgs e)
        {
            ibtn_yzm.ImageUrl = "ImageCode.aspx";
        }

        protected void btRegister_Click(object sender, EventArgs e)
        {
            string code = tbx_yzm.Text;
            HttpCookie htco = Request.Cookies["ImageV"];
            string scode = htco.Value.ToString();
            if (code != scode)
            {
                Response.Write("<script>alert('验证码输入不正确！')</script>");
            }
            else
            {
                if (permitRegi == 1)
                {
                    DAL.Class1.RegisterUser(tbAdmName.Text, tbAdmPwd.Text);
                    Response.Write("<script>alert('注册成功！')</script>");
                }
                
            }
        }

        protected void btLogin_Click(object sender, EventArgs e)
        {
            Server.Transfer("Login.aspx");
        }

        protected void useJSAjax(object sender, EventArgs e)
        {
            String sd = "select * from users where username like '" + tbAdmName.Text + "'";
            permitRegi = DAL.Class1.useJSAjax(lbWarning, sd);
        }
    }
}