using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;


namespace Web.UI
{
    public class BaseAdminPage : Page
    {
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

    public class Kk { }
}
