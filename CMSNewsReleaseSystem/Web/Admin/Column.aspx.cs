using System;
using System.Collections.Generic;
using Maticsoft.BLL;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.UI;

namespace Maticsoft.Web.Admin
{
    public partial class Column : BaseAdminPage
    {
        /// <summary>
        /// 操作
        /// </summary>
        protected string Action
        {
            get { return ContextHelper.ContextQuery("action"); }
        }

        /// <summary>
        /// 移动方向
        /// </summary>
        protected int IsUp
        {
            get { return  ContextHelper.ContextQueryId("isup"); }
        }

        /// <summary>
        /// 栏目Id
        /// </summary>
        private int CurrentId
        {
            get  { return ContextHelper.ContextQueryId("Id"); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Maticsoft.BLL.CMS_Column bCol = new Maticsoft.BLL.CMS_Column();
                if (Action == "move") bCol.MoveList(CurrentId, IsUp); // 判断页面上是否有上/下移请求
                Flush();
            }
        }

        //更新列表
        public void Flush()
        {
            Maticsoft.BLL.CMS_Column bCol = new Maticsoft.BLL.CMS_Column();
            GVinfo.DataSource = bCol.GetList("");
            GVinfo.DataBind();
        }

        int Id; // 用来获取欲删除的Id
        protected void GVinfo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int theRow = 0;//保存行号
            string theCol = "";//保存列位置信息
            theRow = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
            theCol = e.CommandName.ToString();
            Id = Convert.ToInt32(GVinfo.DataKeys[theRow].Value);
            Maticsoft.BLL.CMS_Column bCol = new Maticsoft.BLL.CMS_Column();

            if (!bCol.Delete(Id)) Alert("含有子栏目或文章，不允许删除！");
            Flush();
        }
    }
}