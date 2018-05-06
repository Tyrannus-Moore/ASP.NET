using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.Admin
{
    public partial class Role : BaseAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DoAdminSetting(201);
            if (!IsPostBack)
            {
                Flush();
            }
        }

        public void Flush()
        {
            BLL.CMS_AdminRole bar = new BLL.CMS_AdminRole();
            GVinfo.DataSource = bar.GetList("");
            GVinfo.DataBind();
        }

        /// <summary>
        /// 删除
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
            BLL.CMS_AdminRole bro = new BLL.CMS_AdminRole();

            switch (e.CommandName)
            {
                case "MyDel": bro.Delete(Id); break; // 删除操作
            }

            Flush();
        }
    }
}