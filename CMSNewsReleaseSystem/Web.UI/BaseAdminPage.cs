using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Maticsoft.Model;

namespace Web.UI
{
    public class BaseAdminPage : Page
    {
        /// <summary>
        /// 系统配置信息
        /// </summary>
        protected CMS_Config SystemConfig;

        /// <summary>
        /// 当前管理员
        /// </summary>
        protected CMS_AdminUser CurrentAdmin;

        /// <summary>
        /// 页面大小
        /// </summary>
        protected int PageSize = 4;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            SystemConfig = new CMS_Config();

            CurrentAdmin = CMS_AdminUser.CurrentAdmin;

            //判断是否登录了
            if (CurrentAdmin == null)
            {
                Response.Redirect("Login.aspx?t='exit'");
                //Javascript("top.location='Login.aspx'");
            }

            //动态加入CSS文件
            HtmlLink link = new HtmlLink();
            link.Attributes.Add("href", "../Css/ManageCss/STYLE.CSS");
            link.Attributes.Add("type", "text/css");
            link.Attributes.Add("rel", "Stylesheet");
            this.Page.Header.Controls.Add(link);

            //动态加入JS文件
            ClientScript.RegisterClientScriptInclude("jquery", "../Scripts/jquery-1.2.6.min.js");
            ClientScript.RegisterClientScriptInclude("jquery.validate", "../Scripts/jquery.validate.js");
        }


        /// <summary>
        /// 根据code将name包装为带缩进的name
        /// </summary>
        /// <param name="name">原来的标题名字</param>
        /// <param name="code">栏目代码</param>
        /// <returns>缩进的name</returns>
        protected string GetColumnName(string name, string code)
        {
            if (code.Length == 4)
                return name;
            string tmp = "├";
            int level = code.Length / 4 - 1;
            tmp = tmp.PadRight(level + 1, '─');
            return tmp + name;
        }

        /// <summary>
        /// 注册Script脚本并执行JS代码
        /// </summary>
        /// <param name="js">JS代码</param>
        protected void JavaScript(string jsCode)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "jsCode", "<script>" + jsCode + "</script>");
        }

        /// <summary>
        /// 弹出警告框
        /// </summary>
        /// <param name="message">消息</param>
        protected void Alert(string message)
        {
            JavaScript("alert(\"" + message + "\")");
        }
    }

    public class Kk { }//感谢李老师
}
