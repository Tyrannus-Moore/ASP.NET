using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Model;
using Maticsoft.BLL;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Web.UI;

namespace Maticsoft.Web.Admin
{
    public partial class Debug : BaseAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Flush();
            }
        }

        static int Id;//Id放外面原因:以修改为目的点击确定，需要获取GVinfo_RowCommand里Id号，否则一直是Id=0，导致更新失败

        //更新列表
        public void Flush()
        {
            Maticsoft.BLL.CMS_FriendLink bfl = new Maticsoft.BLL.CMS_FriendLink();
            GVinfo.DataSource = bfl.GetList("1=1");//这一行用1=1，因为查询语句要加where
            GVinfo.DataBind();
        }

        //插入一条记录
        protected void btSubmit_Click(object sender, EventArgs e)
        {
            //创建一个Model
            Maticsoft.Model.CMS_FriendLink mfl = new Maticsoft.Model.CMS_FriendLink();
            if (lbIns.Text == "编辑") mfl.Id = Id;
            mfl.IsPic = false;
            mfl.Title = tbTitle.Text;
            mfl.Sort = Convert.ToInt32(tbSort.Text);
            mfl.SiteUrl = tbSiteUrl.Text;

            //插入记录
            Maticsoft.BLL.CMS_FriendLink bfl = new Maticsoft.BLL.CMS_FriendLink();

            //分情况讨论
            if (lbIns.Text == "添加")
            {
                bfl.Add(mfl);
            }
            else if (lbIns.Text == "编辑")
            {
                bfl.Update(mfl);
            }
            btAbandon_Click(sender, e);
            btAbandon.Visible = false;

            Flush();
        }

        //更新一条记录
        protected void GVinfo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int theRow = 0;//保存行号
            string theCol = "";//保存列位置信息
            theRow = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
            theCol = e.CommandName.ToString();
            Id = Convert.ToInt32(GVinfo.DataKeys[theRow].Value);
            Maticsoft.Model.CMS_FriendLink mfl = new Maticsoft.Model.CMS_FriendLink();
            Maticsoft.BLL.CMS_FriendLink bfl = new Maticsoft.BLL.CMS_FriendLink();

            switch (e.CommandName)
            {
                case "MyEdit":
                    {
                        lbIns.Text = "编辑";
                        mfl = bfl.GetModel(Id);
                        tbTitle.Text = mfl.Title;
                        tbSort.Text = Convert.ToString(mfl.Sort);
                        tbSiteUrl.Text = mfl.SiteUrl;
                        btAbandon.Visible = true;
                        break;
                    }
                case "MyUp":
                    {
                        DAL.CMS_FriendLink.SetSort(Id, false);
                        Flush();
                        break;
                    }
                case "MyDown":
                    {
                        DAL.CMS_FriendLink.SetSort(Id, true);
                        Flush();
                        break;
                    }
                case "MyDel":
                    {
                        bfl.Delete(Id);
                        btAbandon_Click(sender, e);//如果在编辑或添加完的状态下，点了删除
                        Flush();
                        break;
                    }
            }

        }

        //将表单内数据清空
        protected void btAbandon_Click(object sender, EventArgs e)
        {
            lbIns.Text = "添加";
            tbTitle.Text = "";
            tbSort.Text = "";
            tbSiteUrl.Text = "";
            btAbandon.Visible = false;
        }
    }
}