using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;


namespace Maticsoft.Web
{
    public class LeftMenu
    {
        private string title;

        private string code;

        private List<MenuLink> links = new List<MenuLink>();

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        public List<MenuLink> Links
        {
            get { return links; }
            set { links = value; }
        }

        /// <summary>
        /// 动态根据XML文件加载菜单
        /// </summary>
        /// <returns>返回菜单构成的HTML</returns>

        public static List<LeftMenu> Load()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(HttpContext.Current.Request.PhysicalApplicationPath + "Admin/Menu.config");
            List<LeftMenu> menus = new List<LeftMenu>();
            XmlNodeList menuNodes = xml.SelectNodes("Menus/Menu");
            foreach (XmlNode menuNode in menuNodes)
            {
                LeftMenu menu = new LeftMenu();
                menu.Code = menuNode.Attributes["code"].Value;
                menu.Title = menuNode.Attributes["title"].Value;
                foreach (XmlNode linkNode in menuNode.ChildNodes)
                {
                    MenuLink link = new MenuLink();
                    link.Code = linkNode.Attributes["code"].Value;
                    link.Title = linkNode.Attributes["title"].Value;
                    link.Href = linkNode.Attributes["href"].Value;
                    menu.Links.Add(link);
                }
                menus.Add(menu);
            }
            return menus;
        }
    }
}