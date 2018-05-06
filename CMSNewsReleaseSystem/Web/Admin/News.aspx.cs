using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.UI;

namespace Maticsoft.Web.Admin
{
    public partial class News : BaseAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DoAdminSetting(303);
            if(!IsPostBack)
            {
                Flush("");
                FlushColumn();
                Session["pageIndex"] = null;
            }
        }

        // 更新列表 注意显示优先级 先排onTop desc 再按时间PostDate desc
        public void Flush(string strWhere)
        {
            if(strWhere == null)
            {
                strWhere = "";
            }
            // 添加新闻后返回的页面
            if (Session["pageIndex"] != null)
            {
                AspNetPager1.CurrentPageIndex = Convert.ToInt32(Session["pageIndex"]);
            }
            int ReCount = 0;
            DataSet ds;

            BLL.CMS_Article bAtc = new BLL.CMS_Article();
            ds = bAtc.GetPageListWithColumn("onTop desc,PostDate desc", strWhere, AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize , ref ReCount);
            AspNetPager1.RecordCount = ReCount;

            GVinfo.DataSource = ds;
            GVinfo.DataBind();
        }

        // 更新DDL里面Column的可选项
        public void FlushColumn()
        {
            //只能列出满足下列条件的栏目：不能是跳转网址的栏目，也不能是有子栏目的栏目
            BLL.CMS_Column bcol = new BLL.CMS_Column();
            DataTable dt2 = bcol.GetList("(Len(GotoUrl)=0 or  GotoUrl is NULL) and id not in (select distinct ParentId from CMS_Column)").Tables[0];
            foreach (DataRow dr in dt2.Rows)
            {
                ListItem li = new ListItem();
                li.Text = GetColumnName(dr["Title"].ToString(), dr["Code"].ToString());
                li.Value = dr["Id"].ToString();
                ddlColumnId.Items.Add(li);
            }
        }

        // 删除一条新闻 或 将其置顶
        protected void GVinfo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Id = 0; // 保存ID
            int theRow = 0; // 保存行号
            string theCol = ""; // 保存列位置信息
            theRow = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
            theCol = e.CommandName.ToString();
            Id = Convert.ToInt32(GVinfo.DataKeys[theRow].Value);
            BLL.CMS_Article bAtc = new BLL.CMS_Article();
            Model.CMS_Article art = new Model.CMS_Article();
            art = bAtc.GetModel(Id);

            switch (e.CommandName)
            {
                case "MyDel":
                    {
                        DoSetting(Convert.ToInt32(art.ColumnId), "删除");
                        bAtc.Delete(Id);
                        break;
                    } // 删除操作

                case "MyUp":
                    {
                        DoSetting(Convert.ToInt32(art.ColumnId), "修改");
                        bAtc.doOnTop(Id);
                        break;
                    }// 置顶操作

            }

            Flush(strWhere);
        }

        // 翻页的时候要用的函数
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Flush(strWhere);
        }

        // 用来呈现 "设置置顶" 或 "取消置顶"
        protected string onTopText(object o)
        {
            if (o != null)
            {
                int onTop = int.Parse(o.ToString());
                if (onTop == 0)
                {
                    return "设置置顶";
                }
                else
                {
                    return "取消置顶";
                }
            }
            else
            {
                return "";
            }
        }

        //应该完成了 执行操作
        protected void btExecute_Click(object sender, EventArgs e)
        {
            BLL.CMS_Article bArt = new BLL.CMS_Article();
            string oper = ddlOper.SelectedValue;
            string idlist = Request.Form["ArticleId"] ?? ""; // 若空传null 不空自己 作用: 获取选中的Id,例如3,4 相当于教程中的ids

            if (oper == "del")
            {
                //判断权限
                DoSetting("批量删除");

                //批量删除文章
                bArt.DeleteList(idlist);
            }
            else if (oper == "move")
            {
                //判断权限
                DoSetting("批量移动");


                //批量移动到栏目
                bArt.MoveList(idlist, Convert.ToInt16(ddlColumnId.SelectedValue));
            }

            Flush(strWhere);
        }

        static string strWhere = ""; //Sql语句 为什么要放外面因为AspNetPager1_PageChanged事件也要用到

        //应该完成了 搜索操作 
        protected void btSearch_Click(object sender, EventArgs e)
        {
            BLL.CMS_Column bcol = new BLL.CMS_Column();
            AspNetPager1.CurrentPageIndex = 1;
            
            string strEndTime = ""; //结束时间，要拿来加1

            if (ddlKeyType.Value == "PostDate") //选的是时间
            {
                if (BLL.Validator.IsStringDate(EntTime1.Value) && BLL.Validator.IsStringDate(EntTime2.Value))
                {
                    strEndTime = DateTime.Parse(EntTime2.Value).AddDays(1).ToString();
                    strWhere = " PostDate between '" + EntTime1.Value + "' and '" + strEndTime + "'";
                }
                else
                {
                    JavaScript("alert(\"请输入合法格式的日期\");");
                }
            }
            else //选的是标题||作者||栏目||
            {
                if (txtKeyWord.Text != String.Empty || txtKeyWord.Text != "")
                {
                    strWhere = ddlKeyType.Value == "Column" ? "c.title" : ( "a."+ ddlKeyType.Value);
                    strWhere += " like '%" + txtKeyWord.Text.Trim() + "%'";
                }
            }

            btShowAll.Visible = true;

            Flush(strWhere);
        }

        /// <summary>
        /// 用来设置恢复按条件筛选后 显示全部数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btShowAll_Click(object sender, EventArgs e)
        {
            strWhere = "";
            btShowAll.Visible = false;
            Flush("");
        }
    }
}