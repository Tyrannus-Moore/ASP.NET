using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;

namespace Maticsoft.DAL
{
    public class CreateHtml
    {
        private string TempHtml;
        private string PageType;
        private string ServerPath;
        private int pageSize = 4;
        private string urlPath = "";

        public CreateHtml(string _pageType, string _serverPath)
        {
            PageType = _pageType;
            ServerPath = _serverPath;
            if(PageType != "List")
            {
                ReadFile();
            }
            //urlPath = HttpContext.Current.Request.Url.AbsolutePath;
        }
        
        /// <summary>
        /// 从模板中读取字符
        /// </summary>
        private void ReadFile()
        {
            string filePath = Path.Combine(ServerPath, "Template/Default/" + PageType + ".html");
            StreamReader sr = new StreamReader(filePath, Encoding.UTF8);
            TempHtml = sr.ReadToEnd();
            sr.Close();
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="fileName">文件名</param>
        /// <param name="pageStr">保存后的文件名</param>
        private void SaveFile(string path, string fileName, string pageStr)
        {
            string filePath = System.IO.Path.Combine(ServerPath, path + fileName);
            StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8);
            sw.Write(pageStr);
            sw.Close();
        }


        /// <summary>
        /// 根据ID生成文章页
        /// </summary>
        /// <param name="id"></param>
        public void CreateShowArticle(int id)
        {
            string tmpBody = ReplaceArticleDetail(TempHtml, id, 0);
            SaveFile("html/Article", "Article_" + id + ".html", tmpBody);
        }


        /// <summary>
        /// 替换文章模板中的标签
        /// </summary>
        /// <param name="tmpBody"></param>
        /// <param name="id"></param>
        /// <param name="titleLen"></param>
        /// <returns></returns>
        private string ReplaceArticleDetail(string tmpBody, int id, int titleLen)
        {
            CMS_Article dart = new CMS_Article();
            Model.CMS_Article art = dart.GetModel(id);
            StringBuilder sb = new StringBuilder();
            sb.Append(tmpBody);
            sb.Replace("{$ArticleId$}", art.Id.ToString());
            string titleColor = art.titleColor;
            int titleFont = art.titleFont;
            string titleFontStr = "";
            string articleTitle = art.Title;
            if(titleLen != 0)
            {
                articleTitle = articleTitle.Remove(titleLen);
                //articleTitle = Utils.ClipString(articleTitle, titleLen);
            }
            switch (titleFont)
            {
                case 1: titleFontStr = "font-weight:bold"; break;
                case 2: titleFontStr = "font-style:italic"; break;
                case 3: titleFontStr = "font-weight:bold;font-style:italic"; break;
                default: break;
            }

            if(titleColor != "black" || titleFontStr != "")
            {
                if(titleColor != "black")
                {
                    articleTitle = "<span style='color:" + titleColor + ";" + titleFontStr + "'>" + articleTitle + "</span>";
                }
                else
                {
                    articleTitle = "<span style='" + titleFontStr + "'>" + articleTitle +"</span>";
                }
            }

            sb.Replace("{$ArticleTitle$}", articleTitle);
            sb.Replace("{$HeadArticleTitle$}", art.Title);
            sb.Replace("{$ArticleAuthor$}", art.Author);
            sb.Replace("{$ArticlePostDate$}", art.PostDate.ToString());
            sb.Replace("{$ArticlePicUrl$}", art.PicUrl);
            sb.Replace("{$ArticleBody$}", art.Body);
            sb.Replace("{$ArticleReadTimes$}", art.ReadTimes.ToString());
            sb.Replace("{$ColumnName$}", art.SearchColumnName(Convert.ToInt32(art.ColumnId)));
            sb.Replace("{$ArticleLink$}", "Article_"+art.Id+".html");
            sb.Replace("/userfiles","../../userfiles");
            return sb.ToString();
        }


    }
}
