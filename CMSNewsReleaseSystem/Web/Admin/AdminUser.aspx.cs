using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.Admin
{
    public partial class AdminUser : BaseAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DoAdminSetting(202);
            if (!IsPostBack)
            {
                Flush();
                FlushDdlRole();
            }
        }

        public void Flush()
        {
            BLL.CMS_AdminUser bau = new BLL.CMS_AdminUser();
            GVinfo.DataSource = bau.GetList("");
            GVinfo.DataBind();
        }

        public void FlushDdlRole()
        {
            BLL.CMS_AdminRole bar = new BLL.CMS_AdminRole();
            DataTable dt = bar.GetList("").Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                ListItem item = new ListItem(dr[1].ToString(), dr[0].ToString() );
                ddlRole.Items.Add(item);
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btAdd_Click(object sender, EventArgs e)
        {
            tbUserName.Text = "";
            tbUserPwd.Text = "";
            tbUserPwd2.Text = "";
            ddlRole.SelectedIndex = 0;
            Panel1.Visible = true;
        }

        /// <summary>
        /// 新增保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btSubmit_Click(object sender, EventArgs e)
        {
            BLL.CMS_AdminUser bau = new BLL.CMS_AdminUser();
            Model.CMS_AdminUser user = new Model.CMS_AdminUser();
            user.Name = tbUserName.Text;
            user.Pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(tbUserPwd.Text, "MD5");
            user.RoleId = Convert.ToInt32(ddlRole.Text);

            bau.Add(user);

            Flush();
        }

        /// <summary>
        /// 修改或删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GVinfo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Id = 0; // 保存ID
            int theRow = 0; // 保存行号
            string theCol = ""; // 保存列位置信息
            theRow = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
            theCol = e.CommandName.ToString();
            Id = Convert.ToInt32(GVinfo.DataKeys[theRow].Value);
            BLL.CMS_AdminUser bau = new BLL.CMS_AdminUser();

            switch (e.CommandName)
            {
                case "MyDel": bau.Delete(Id); break; // 删除操作

                case "MyUp":
                    {
                        Model.CMS_AdminUser user = new Model.CMS_AdminUser();
                        user = bau.GetModel(Id);
                        Panel1.Visible = true;
                        tbUserName.Text = user.Name;
                        ddlRole.SelectedValue = user.RoleId.ToString();

                        break;
                    }
            }

            Flush();
        }
    }
}