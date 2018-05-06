using System;
using System.Collections.Generic;
using Maticsoft.BLL;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.UI;
using System.Data;

namespace Maticsoft.Web.Admin
{
    public partial class AddColumn : BaseAdminPage
    {
        /// <summary>
        /// 栏目Id
        /// </summary>
        private int CurrentId
        {
            get { return ContextHelper.ContextQueryId("Id"); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            DoAdminSetting(302);
            if(!IsPostBack)
            {
                Flush();
            }
        }

        /// <summary>
        /// 更新文本框
        /// </summary>
        protected void Flush()
        {
            CMS_Column bCol = new CMS_Column();
            Model.CMS_Column col = new Model.CMS_Column();
            DataTable dt;
            if (CurrentId > 0)
            {
                col = bCol.GetModel(CurrentId);
                tbTitle.Text = col.Title;
                if(col.GotoUrl != "")
                {
                    cbLink.Checked = true;
                    Panel1.Visible = true;
                }
                cbIsNavi.Checked = col.IsNavigator == 1 ? true : false;
                if (col.GotoUrl != "" && col.GotoUrl != null)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "jsGotoUrl", "<script>$(\"#ckIsLink\").trigger(\"click\");$(\"#trLink\").css(\"display\",\"block\");</script>");
                    tbLink.Text = col.GotoUrl;
                }
                //只列出满足以下条件的栏目作为父栏目：不能是自己的下级栏目，不能是跳转到某网站的栏目，不能是已包含文章的栏目
                dt = bCol.GetList("Code not like '" + 
                    col.Code + "%' and (Len(GotoUrl)=0 or  GotoUrl is NULL) " +
                    "and Id not in (select distinct ColumnId from CMS_Article)").Tables[0];
            }
            else
            {
                //只列出满足以下条件的栏目作为父栏目：不能是跳转到某网站的栏目，不能是已包含文章的栏目
                dt = bCol.GetList("(Len(GotoUrl)=0 or " +
                    "GotoUrl is NULL) and Id not in " +
                    "(select distinct ColumnId from CMS_Article)").Tables[0];
            }
            ddlParentId.Items.Add(new ListItem("作为一级", "0"));
            foreach (DataRow dr in dt.Rows)
            {
                ListItem li = new ListItem();
                li.Text = GetColumnName(dr["Title"].ToString(), dr["Code"].ToString());
                li.Value = dr["Id"].ToString();

                if (col.ParentId.ToString() == li.Value)
                {
                    li.Selected = true;
                }
                ddlParentId.Items.Add(li);
            }
        }

        protected void btSave_Click(object sender, EventArgs e)
        {
            CMS_Column bCol = new CMS_Column();
            Model.CMS_Column col = new Model.CMS_Column();
            if (CurrentId > 0) col = bCol.GetModel(CurrentId);
            col.Title = tbTitle.Text;
            col.IsNavigator = cbIsNavi.Checked ? 1 : 0;

            if (cbLink.Checked)
            {
                col.GotoUrl = tbLink.Text;
            }
            else
            {
                col.GotoUrl = "";
            }

            int newParentId = int.Parse(ddlParentId.SelectedValue);
            if (CurrentId > 0)
            {
                int oldParentId = col.ParentId;
                bool isChange = newParentId == col.ParentId ? false : true;
                col.ParentId = newParentId;
                bCol.Update(col, isChange, oldParentId);
                //Do something
            }
            else
            {
                col.ParentId = newParentId;
                int newId = bCol.Add(col);
                //Do something
            }
            Response.Redirect("Column.aspx");

        }

        /// <summary>
        /// cbLink状态变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbLink_CheckedChanged(object sender, EventArgs e)
        {
            if(cbLink.Checked == true)
            {
                Panel1.Visible = true;
            }
            else
            {
                Panel1.Visible = false;
                tbLink.Text = "";
            }
        }
    }
}