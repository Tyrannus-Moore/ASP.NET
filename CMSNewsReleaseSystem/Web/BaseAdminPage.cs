using Maticsoft.Model;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Maticsoft.Web
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
        public CMS_AdminUser CurrentAdmin;

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

        /// <summary>
        /// 判断系统权限
        /// </summary>
        /// <param name="code">对应操作代码</param>
        /// <returns>是否有权限</returns>
        protected bool CheckAdminSetting(int code)
        {
            if (CurrentAdmin.Role.AdminSetting.Contains(code.ToString()))
                return true;
            return false;
        }

        /// <summary>
        /// 当无权限时要跳到指定页面
        /// </summary>
        /// <param name="code">对应操作代码</param>
        protected void DoAdminSetting(int code)
        {
            if (!CheckAdminSetting(code))
            {
                Response.Redirect("~/Error/WithoutRight.aspx");
            }
        }

        /// <summary>
        /// 判断栏目权限
        /// </summary>
        /// <param name="code">对应操作代码</param>
        /// <returns>是否有权限</returns>
        protected bool CheckSetting(int code,string action)
        {
            int actionCode; //0-修改 1-删除 2-新增
            if (action == "新增") actionCode = 2;
            else if (action == "删除") actionCode = 1;
            else if (action == "修改") actionCode = 0;
            else actionCode = -1; //以防出错

            if (CurrentAdmin.Role.Setting.Contains(code + "_" + actionCode))
                return true;
            return false;
        }

        /// <summary>
        /// 当无权限时要跳到指定页面
        /// </summary>
        /// <param name="code">对应操作代码</param>
        protected void DoSetting(int code,string action)
        {
            if (!CheckSetting(code,action))
            {
                Response.Redirect("~/Error/WithoutRight.aspx");
            }
        }


        /// <summary>
        /// 批量操作栏目权限
        /// </summary>
        /// <param name="code">对应操作代码</param>
        protected void DoSetting(string code)
        {
            if (!CheckSetting(code))
            {
                Response.Redirect("~/Error/WithoutRight.aspx");
            }
        }

        /// <summary>
        /// 判断批量操作栏目权限
        /// </summary>
        /// <param name="code">对应操作代码</param>
        /// <returns>是否有权限</returns>
        protected bool CheckSetting(string code)
        {
            string actionCode; 
            if (code == "批量移动") actionCode = "moveBatch";
            else if (code == "批量删除") actionCode = "deleteBatch";
            else actionCode = ""; //以防出错

            if (CurrentAdmin.Role.Setting.Contains(actionCode))
                return true;
            return false;
        }

    }
}