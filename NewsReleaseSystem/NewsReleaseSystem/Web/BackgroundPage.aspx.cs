using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class BackgroundPage : System.Web.UI.Page
    {
        static string title = "";//设为静态因为一点进修改页面要保存最初的title
        static int releaseLock = 0;//防止标题重复
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ValidateName"] == null)//防止跳过登录直接进入管理页面
                {
                    Server.Transfer("Login.aspx");
                }
                else
                {
                    string AdmName = Session["ValidateName"].ToString();
                    lbAdm.Text = AdmName;
                    DAL.Class1.FlushConnection(GVinfo);
                }
            }
        }

        protected void cbAll_CheckedChanged(object sender, EventArgs e)
        {
            cbNone.Checked = false;
            for (int i = 0; i <= GVinfo.Rows.Count - 1; i++)
            {
                CheckBox cb = (CheckBox)GVinfo.Rows[i].FindControl("cbSelect");
                if (cbAll.Checked)
                {
                    cb.Checked = true;
                }
                else
                {
                    cb.Checked = false;
                }
            }
        }

        protected void cbNone_CheckedChanged(object sender, EventArgs e)
        {
            cbAll.Checked = false;
            for (int i = 0; i <= GVinfo.Rows.Count - 1; i++)
            {
                CheckBox cb = (CheckBox)GVinfo.Rows[i].FindControl("cbSelect");
                cb.Checked = false;
            }
        }

        protected void btDel_Click(object sender, EventArgs e)
        {
            DAL.Class1.DeleteNews(GVinfo);
            DAL.Class1.FlushConnection(GVinfo);
        }

        protected void tbAddNews_Click(object sender, EventArgs e)
        {
            if (releaseLock == 1)
            {
                string presentTime = DateTime.Now.ToString();
                string sd = "insert into news(newsTitle, newsContent, pubTime, publisher, readTimes, classID) values('" + tbAddTitle.Text + "','" + tbAddContent.Text + "','" + presentTime + "','" + lbAdm.Text + "','" + "0" + "','" + ddlClass.SelectedItem.Value + "')";
                DAL.Class1.DBConnect(sd,GVinfo);
            }
            else
            {
                lbWarning.Text = "新闻名被占用辣，冷静冷静";
            }
        }

        protected void btMd_Click(object sender, EventArgs e)
        {
            string sd = "update news set newsTitle = '" + tbMdTitle.Text + "',newsContent = '" + tbMdContent.Text + "',classID = '" + ddlClass2.SelectedItem.Value + "' where newsTitle = '" + title + "'";
            DAL.Class1.DBConnect(sd,GVinfo);
            Panel3.Visible = false;
        }
        protected void GVinfo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int theRow = 0;//保存行号
            string theCol = "";//保存列位置信息
            theRow = ((GridViewRow)((Button)e.CommandSource).NamingContainer).RowIndex;
            theCol = e.CommandName.ToString();
            title = (string)GVinfo.DataKeys[theRow].Value;//注意此处可能有个bug，两篇新闻同样标题？--解决
            if (e.CommandName == "MyEdit")
            {
                string sd = "select newsContent from news where newsTitle like '" + title + "'";
                tbMdTitle.Text = title;
                tbMdContent.Text = DAL.Class1.DBModify(sd);
                Panel3.Visible = true;
            }
            else
            {
                string sd = "delete from news where newsTitle like '" + title + "'";
                DAL.Class1.DBConnect(sd, GVinfo);
            }
        }
        protected void tbAddTitle_TextChanged(object sender, EventArgs e)
        {

            string sd = "select * from news where newsTitle like '" + tbAddTitle.Text + "'";
            releaseLock=DAL.Class1.DBComparison(sd,releaseLock,lbWarning);
        }
    }
}