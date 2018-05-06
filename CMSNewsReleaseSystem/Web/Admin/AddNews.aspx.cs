using Maticsoft.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.UI;

namespace Maticsoft.Web.Admin
{
    public partial class AddNews : BaseAdminPage
    {
        private int CurrentId
        {
            get
            {
                return ContextHelper.ContextQueryId("Id");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            DoAdminSetting(303);
            if (!IsPostBack)
            {
                if(CurrentId > 0)
                {
                    //修改好之后返回新闻首页可以直接到那一页
                    Session["pageIndex"] = ContextHelper.ContextQueryId("pageIndex");
                }
                ShowEditor(); //显示表单界面
            }
        }

        protected void ShowEditor()
        {
            CMS_Article bArt = new CMS_Article();
            CMS_Column bCol = new CMS_Column();
            Model.CMS_Article mArt = new Model.CMS_Article();
            if (CurrentId > 0)//如果是编辑
            {
                mArt = bArt.GetModel(CurrentId);

                if(mArt.ColumnId != 0)
                {
                    DoSetting(Convert.ToInt32(mArt.ColumnId), "修改");
                }
                ddlTitCor.Items.FindByValue(mArt.titleColor).Selected = true;
                ddlTitSty.Items.FindByValue(mArt.titleFont.ToString()).Selected = true;
            }
            //tbAuthor.Text = mArt.Author;
            tbAuthor.Text = CurrentAdmin.Name;
            if(mArt.IsPic == true)
            {
                //显示图片
                Image1.Visible = true;
                Image1.ImageUrl = "~\\userfiles\\" + mArt.PicUrl.Substring(mArt.PicUrl.LastIndexOf("\\") + 1); ;
            }
            //tbPicUrl.Text = mArt.PicUrl;
            tbTitle.Text = mArt.Title;
            FCKeditor1.Value = mArt.Body;
            //构造SQL语句查询出没有子栏目并且不是跳转网址的栏目
            string strSql = "select * from CMS_Column as a where (Len(GotoUrl)=0 or GotoUrl is NULL) and not EXISTS(select b.Id from CMS_Column as b where b.ParentId=a.Id) order by code";
            DataTable dt = bCol.CustomGetList(strSql);
            //光往栏目下拉列表中加入"无"项
            ListItem theLi = new ListItem("无", "0");
            ddlCol.Items.Add(theLi);
            //通过循环将数据库中满足条件的栏目包装成带缩进的样子加入栏目的下拉列表
            foreach (DataRow dr in dt.Rows)
            {
                ListItem li = new ListItem();
                li.Text = GetColumnName(dr["Title"].ToString(), dr["Code"].ToString());
                li.Value = dr["Id"].ToString();

                //若是编辑则将当前栏目选中
                if (li.Value == mArt.ColumnId.ToString()) li.Selected = true;
                ddlCol.Items.Add(li);
            }

            /*以下是专题的不过没什么用*/
            //在视频的第五单元第四课时里

            //根据ListItem选项值修改背景颜色 字体粗细
            foreach (ListItem lt in ddlTitCor.Items)
            {
                lt.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, lt.Value);
            }
            ddlTitSty.Items[0].Attributes.CssStyle.Add(HtmlTextWriterStyle.FontStyle, "bold");
            ddlTitSty.Items[1].Attributes.CssStyle.Add(HtmlTextWriterStyle.FontWeight, "bold");
            ddlTitSty.Items[2].Attributes.CssStyle.Add(HtmlTextWriterStyle.FontStyle, "italic");
            ddlTitSty.Items[3].Attributes.CssStyle.Add(HtmlTextWriterStyle.FontWeight, "bold");
            ddlTitSty.Items[3].Attributes.CssStyle.Add(HtmlTextWriterStyle.FontStyle, "italic");
        }

        protected void btSave_Click(object sender, EventArgs e)
        {
            Model.CMS_Article mArt = new Model.CMS_Article();
            BLL.CMS_Article bArt = new BLL.CMS_Article();
            mArt = CurrentId > 0 ? bArt.GetModel(CurrentId) : mArt;
            mArt.Title = tbTitle.Text.Trim();
            mArt.titleColor = ddlTitCor.Items[ddlTitCor.SelectedIndex].Value;
            mArt.titleFont = Convert.ToInt32(ddlTitSty.Items[ddlTitSty.SelectedIndex].Value);

            mArt.Author = tbAuthor.Text.Trim();
            mArt.Body = FCKeditor1.Value;
            mArt.ColumnId = Validator.StrToId(ddlCol.SelectedValue);
            mArt.ZhuantiId = 0;
            DoSetting(Convert.ToInt32(mArt.ColumnId), "新增");

            if (FileUpload1.HasFile)
            {
                string filePath = Server.MapPath("~\\userfiles\\");
                string fileName = FileUpload1.PostedFile.FileName;
                fileName = fileName.Substring(fileName.LastIndexOf("\\") + 1);
                FileUpload1.SaveAs(filePath + fileName);
                mArt.IsPic = true;
                mArt.PicUrl = filePath + fileName;
            }
            else
            {
                if(CurrentId == 0) // 防止覆盖修改情况下被覆盖
                {
                    mArt.IsPic = false;
                    mArt.PicUrl = "";
                }
            }

            if (CurrentId == 0)
            {
                DoSetting(Convert.ToInt32(mArt.ColumnId) , "新增");
                mArt.PostDate = DateTime.Now;
                mArt.onTop = 0;
                bArt.Add(mArt);
            }
            else
            {
                DoSetting(Convert.ToInt32(mArt.ColumnId), "修改");
                bArt.Update(mArt);
            }

            Response.Redirect("News.aspx");
        }
    }
}