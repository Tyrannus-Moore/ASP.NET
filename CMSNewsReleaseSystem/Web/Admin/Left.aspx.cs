using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.UI;

namespace Maticsoft.Web.Admin
{
    public partial class AdminLeft : BaseAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ltMenu.Text = GetMenuString();
            }
        }
        /// <summary>
        /// 根据XML文件动态产生菜单
        /// </summary>
        /// <returns></returns>
        protected string GetMenuString()
        {
            List<LeftMenu> menus = LeftMenu.Load();
            StringBuilder sb = new StringBuilder();
            sb.Append("<ul>");
            foreach (LeftMenu menu in menus)
            {
                sb.Append("<li class=\"main\">");
                sb.AppendFormat("<a href=\"#\" class=\"top\">{0}</a><ul>", menu.Title);
                foreach (MenuLink link in menu.Links)
                {
                    sb.AppendFormat("<li><a href=\"{0}\" target=\"RightMain\">{1}</a></li>", link.Href, link.Title);
                }
                sb.Append("</ul></li>");
            }
            sb.Append("</ul>");
            return sb.ToString();
        }
    }
}
