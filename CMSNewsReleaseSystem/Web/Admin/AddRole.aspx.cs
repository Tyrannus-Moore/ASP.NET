using Maticsoft.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.Admin
{
    public partial class AddRole : BaseAdminPage
    {
        private int currentId;
        private int CurrentId
        {
            get
            {
                return ContextHelper.ContextQueryId("Id");
            }
            set { currentId = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            DoAdminSetting(201);
            if (!IsPostBack)
            {
                LoadSetting();
            }
        }

        /// <summary>
        /// 加载栏目权限和系统权限
        /// </summary>
        protected void LoadSetting()
        {
            CMS_AdminRole bar = new CMS_AdminRole();
            CMS_Column bcol = new CMS_Column();
            Model.CMS_AdminRole role = CurrentId > 0 ? bar.GetModel(CurrentId) : new Model.CMS_AdminRole();
            hfSetting.Value = role.AdminSetting + "," + role.Setting; //收藏哪些勾选

            // 加载系统权限
            List<LeftMenu> menus = LeftMenu.Load();
            StringBuilder sb = new StringBuilder();
            sb.Append("<table border=\"0\" cellspacing=\"0\" cellpadding=\"5\" class=\"setTable\"> ");
            foreach(LeftMenu menu in menus)
            {
                sb.AppendFormat("<tr><td class=\"forumRowHighlight\">{0}</td></tr>", menu.Title);
                sb.Append("<tr><td class=\"listRow\">");
                foreach (MenuLink link in menu.Links)
                {
                    sb.AppendFormat("<span><input type=\"checkbox\" name=\"admin_setting\" value=\"{0}\" id=\"{1}\">{2}</span> ",link.Code, link.Code,link.Title );
                }
                sb.Append("</td></tr>");
            }
            sb.Append("</table>");
            ltAdminSetting.Text = sb.ToString();

            // 加载栏目权限
            DataTable dt = bcol.GetList("").Tables[0];
            sb = new StringBuilder();
            sb.Append("<table border=\"0\" cellspacing=\"0\" cellpadding=\"5\" class=\"setTable\"> ");
            sb.Append("<tr class='listRow'><td style='width:100px'><input type=\"checkbox\" name=\"setting\" value=\"deleteBatch\">批量删除文章</td>");
            sb.Append("<td style='width:100px'><input type=\"checkbox\" name=\"setting\" value=\"moveBatch\">批量移动文章</td>");
            sb.Append("<td style='width:100px'><input type=\"checkbox\" name=\"setting\" value=\"addBatch\">批量加入专题</td>");
            sb.Append("</tr></table>");

            sb.Append("<table border=\"0\" cellspacing=\"0\" cellpadding=\"5\" class=\"setTable\"> ");
            foreach(DataRow dr in dt.Rows)
            {
                sb.AppendFormat("<tr class='listRow'><td>{0}</td>", GetColumnName(dr["Title"].ToString(), dr["Code"].ToString()));
                sb.AppendFormat("<td style='width:220px'><input type=\"checkbox\" name=\"setting\" value=\"{0}_0\">编辑文章",dr["Id"]);
                sb.AppendFormat("<input type=\"checkbox\" name=\"setting\" value=\"{0}_1\">删除文章",dr["Id"]);
                sb.AppendFormat("<input type=\"checkbox\" name=\"setting\" value=\"{0}_2\">新增文章",dr["Id"]);
                sb.Append("</td></tr>");
            }
            sb.Append("</table>");
            ltSetting.Text = sb.ToString();
            tbTitle.Text = role.Name;
        }

        protected void btSave_Click(object sender, EventArgs e)
        {
            CMS_AdminRole bar = new CMS_AdminRole();
            Model.CMS_AdminRole role = CurrentId > 0 ? bar.GetModel(CurrentId) : new Model.CMS_AdminRole();
            role.Name = tbTitle.Text.Trim();
            role.AdminSetting = ContextHelper.ContextForm("admin_setting"); //获取所选系统权限
            role.Setting = ContextHelper.ContextForm("setting"); //获取所选栏目权限
            if (CurrentId == 0)
            {
                int newId = CurrentId = bar.Add(role);
                //SaveActionLog(newId, 1 , "角色");
            }
            else
            {
                bar.Update(role);
                //SaveActionLog(CurrentId, 3 , "角色");
            }
            Response.Redirect("Role.aspx");

        }
    }
}