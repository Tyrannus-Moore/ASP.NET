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
        int NewPageIndex = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Flush("");
            }
        }

        //更新列表
        public void Flush(string strWhere)
        {
            if(strWhere == null)
            {
                strWhere = "";
            }
            int ReCount = 0;
            DataSet ds;

            BLL.CMS_Article bAtc = new BLL.CMS_Article();
            ds = bAtc.GetPageListWithColumn("onTop desc,PostDate desc", strWhere, AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize , ref ReCount);
            AspNetPager1.RecordCount = ReCount;

            GVinfo.DataSource = ds;
            GVinfo.DataBind();
        }


        // 删除一条新闻
        protected void GVinfo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //int theRow = 0;//保存行号
            //string theCol = "";//保存列位置信息
            //theRow = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
            //theCol = e.CommandName.ToString();
            //Id = Convert.ToInt32(GVinfo.DataKeys[theRow].Value);
            //Maticsoft.BLL.CMS_Column bCol = new Maticsoft.BLL.CMS_Column();

            //if (!bCol.Delete(Id)) Alert("含有子栏目或文章，不允许删除！");
            //Flush();
        }


        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            //AspNetPager1.CurrentPageIndex = NewPageIndex;
            Flush("");
        }

        /// <summary>
        /// 呈现“设为置顶”或者“取消置顶”
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
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


    }
}