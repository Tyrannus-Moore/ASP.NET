using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
using System.IO;
using System.Web;

namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:CMS_Article
	/// </summary>
	public partial class CMS_Article
	{
		public CMS_Article()
		{}
        #region  Method
        static string thePath = HttpContext.Current.Request.PhysicalApplicationPath;

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "CMS_Article"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CMS_Article");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.CMS_Article model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CMS_Article(");
			strSql.Append("ColumnId,Title,Author,PostDate,IsPic,PicUrl,Body,onTop,ReadTimes,titleColor,titleFont,ZhuantiId)");
			strSql.Append(" values (");
			strSql.Append("@ColumnId,@Title,@Author,@PostDate,@IsPic,@PicUrl,@Body,@onTop,@ReadTimes,@titleColor,@titleFont,@ZhuantiId)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ColumnId", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.VarChar,100),
					new SqlParameter("@Author", SqlDbType.VarChar,50),
					new SqlParameter("@PostDate", SqlDbType.DateTime),
					new SqlParameter("@IsPic", SqlDbType.Bit,1),
					new SqlParameter("@PicUrl", SqlDbType.VarChar,100),
					new SqlParameter("@Body", SqlDbType.Text),
                    new SqlParameter("@onTop", SqlDbType.Int,4),
                    new SqlParameter("@ReadTimes", SqlDbType.Int,4),
                    new SqlParameter("@titleColor", SqlDbType.VarChar,50),
                    new SqlParameter("@titleFont", SqlDbType.Int,4),
                    new SqlParameter("@ZhuantiId", SqlDbType.Int,4)};
			parameters[0].Value = model.ColumnId;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.Author;
			parameters[3].Value = model.PostDate;
			parameters[4].Value = model.IsPic;
			parameters[5].Value = model.PicUrl;
			parameters[6].Value = model.Body;
            parameters[7].Value = model.onTop;
            parameters[8].Value = model.ReadTimes;
            parameters[9].Value = model.titleColor;
            parameters[10].Value = model.titleFont;
            parameters[11].Value = model.ZhuantiId;




            //某个栏目下的文章数量从0变动到1，1变动到2，需要更新该栏目的父栏目对应的“新闻栏目列表页”
            //int rowsCount = 0;
            //object objrowsCount = DbHelperSQL.GetSingle("select count(*) from CMS_Article where ColumnId=" + ColumnId);
            //if (objrowsCount != null)
            //{
            //    rowsCount = int.Parse(objrowsCount.ToString());
            //}
            //if (rowsCount == 1 || rowsCount == 2)
            //{
            //    CreateHtml chColumnList = new CreateHtml("List", thePath);
            //    chColumnList.CreateColumnList(Column.GetParentId(ColumnId));
            //}

            //某个栏目下的文章数量从1变动到2的时候，要增加一个对应的“新闻列表页”
            //if (rowsCount == 2)
            //{
            //    CreateHtml chArticleList = new CreateHtml("List", thePath);
            //    chArticleList.CreateArticleList(ColumnId);
            //}


            object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);

            //每次添加一条新闻的同时生成对应页面
            CreateHtml ch = new CreateHtml("ShowArticle", HttpContext.Current.Server.MapPath("/"));
            ch.CreateShowArticle(int.Parse(obj.ToString()));

            if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.CMS_Article model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CMS_Article set ");
			strSql.Append("ColumnId=@ColumnId,");
			strSql.Append("Title=@Title,");
			strSql.Append("Author=@Author,");
			strSql.Append("PostDate=@PostDate,");
			strSql.Append("IsPic=@IsPic,");
			strSql.Append("PicUrl=@PicUrl,");
			strSql.Append("Body=@Body,");
            strSql.Append("onTop=@onTop,");
            strSql.Append("ReadTimes=@ReadTimes,");
            strSql.Append("titleColor=@titleColor,");
            strSql.Append("titleFont=@titleFont");
            strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@ColumnId", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.VarChar,100),
					new SqlParameter("@Author", SqlDbType.VarChar,50),
					new SqlParameter("@PostDate", SqlDbType.DateTime),
					new SqlParameter("@IsPic", SqlDbType.Bit,1),
					new SqlParameter("@PicUrl", SqlDbType.VarChar,100),
					new SqlParameter("@Body", SqlDbType.Text),
                    new SqlParameter("@onTop", SqlDbType.Int,4),
                    new SqlParameter("@ReadTimes", SqlDbType.Int,4),
                    new SqlParameter("@titleColor", SqlDbType.VarChar,50),
                    new SqlParameter("@titleFont", SqlDbType.Int,4),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.ColumnId;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.Author;
			parameters[3].Value = model.PostDate;
			parameters[4].Value = model.IsPic;
			parameters[5].Value = model.PicUrl;
			parameters[6].Value = model.Body;
            parameters[7].Value = model.onTop;
            parameters[8].Value = model.ReadTimes;
            parameters[9].Value = model.titleColor;
            parameters[10].Value = model.titleFont;
            parameters[11].Value = model.Id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据 --经过改造
		/// </summary>
		public bool Delete(int Id)
		{
            Model.CMS_Article ac = GetModel(Id);

            //先删除对应图片
            DeletePics(ac.Body); //Body里的
            if (ac.IsPic == true) DeletePic(ac.PicUrl.Substring(ac.PicUrl.LastIndexOf("\\")));

            StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CMS_Article ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
};
			parameters[0].Value = Id;

            string a = thePath + @"html\ArticleArticle_" + Id + ".html";
            //在删除一条新闻的同时删除对应页面           
            File.Delete(thePath + @"html\ArticleArticle_" + Id + ".html");

            //某个栏目下的文章数量从2变动到1，1变动到0，需要更新该栏目的父栏目对应的“新闻栏目列表页” 
            //DO SOMETHING 

            //某个栏目下的文章数量从2变动到1的时候，要删除一个对应的“新闻列表页”
            //DO SOMETHING

            int rows =DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="Idlist">包含的ID</param>
        public bool DeleteList(string Idlist)
        {
            if (Idlist == "") return true;
            string[] currentId = Idlist.Split(',');
            Model.CMS_Article mArt = new Model.CMS_Article();
            mArt = GetModel(int.Parse(currentId[0]));
            int? theColumnId = mArt.ColumnId;

            //在删除新闻的同时删除对应页面  和 文中的图片      
            foreach (string theId in currentId)
            {
                File.Delete(thePath + @"html\ArticleArticle_" + theId + ".html"); // 删除对应页面

                Model.CMS_Article atc = GetModel(int.Parse(theId));
                if (atc.IsPic == true) DeletePic(atc.PicUrl); // 删除标题图片
                DeletePics(atc.Body); // 删除内容图片
            }

            //在数据库中删除记录
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete CMS_Article ");
            strSql.AppendFormat(" where Id in ({0},0)", Idlist);

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            //某个栏目下的文章数量从2变动到1，1变动到0，需要更新该栏目的父栏目对应的“新闻栏目列表页” 
            //DO SOMETHING

            //某个栏目下的文章数量从2变动到1的时候，要删除一个对应的“新闻列表页”
            //DO SOMETHING
        }

        /// <summary>
        /// 删除文章内容中的图片文件
        /// </summary>
        /// <param name="picStr">例如“KK<img width="310" height="233" alt="" src="/userfiles/201105182222064687.jpg" /><img width="310" height="147" alt="" src="/userfiles/201105182222275000.jpg" />”
        /// </param>
        public static void DeletePics(string picStr)
        {
            while (picStr.IndexOf("<img") >= 0)
            {
                int pos = picStr.IndexOf("src=\"/userfiles/");

                string tempName = picStr.Substring(pos + 16);

                int picLength = tempName.IndexOf("\"");
                string picName = picStr.Substring(pos + 16, picLength);
                DeletePic(picName);
                picStr = picStr.Substring(pos + 16 + picLength);
            }
        }

        /// <summary>
        /// 删除指定文件名的图片
        /// </summary>
        /// <param name="picName"></param>
        public static void DeletePic(string picName)
        {
            File.Delete(thePath + @"/userfiles/" + picName);
        }

        /// <summary>
        /// 批量移动到栏目
        /// </summary>
        /// <param name="Idlist">包含的ID</param>
        /// <param name="columnId">栏目ID</param>
        public bool MoveList(string Idlist, int columnId)
        {
            if (Idlist == "") return true;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CMS_Article set columnId='" + columnId + "'");
            strSql.AppendFormat(" where Id in ({0},0)", Idlist);
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.CMS_Article GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,ColumnId,Title,Author,PostDate,IsPic,PicUrl,Body,onTop,ReadTimes,titleColor,titleFont from CMS_Article ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
};
			parameters[0].Value = Id;

			Maticsoft.Model.CMS_Article model=new Maticsoft.Model.CMS_Article();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ColumnId"].ToString()!="")
				{
					model.ColumnId=int.Parse(ds.Tables[0].Rows[0]["ColumnId"].ToString());
				}
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				model.Author=ds.Tables[0].Rows[0]["Author"].ToString();
				if(ds.Tables[0].Rows[0]["PostDate"].ToString()!="")
				{
					model.PostDate=DateTime.Parse(ds.Tables[0].Rows[0]["PostDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsPic"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["IsPic"].ToString()=="1")||(ds.Tables[0].Rows[0]["IsPic"].ToString().ToLower()=="true"))
					{
						model.IsPic=true;
					}
					else
					{
						model.IsPic=false;
					}
				}
				model.PicUrl=ds.Tables[0].Rows[0]["PicUrl"].ToString();
				model.Body=ds.Tables[0].Rows[0]["Body"].ToString();
                if (ds.Tables[0].Rows[0]["ColumnId"].ToString() != "")
                {
                    model.onTop = int.Parse(ds.Tables[0].Rows[0]["onTop"].ToString());
                }
                model.ReadTimes = int.Parse(ds.Tables[0].Rows[0]["ReadTimes"].ToString());

                model.titleColor = ds.Tables[0].Rows[0]["titleColor"].ToString();
                model.titleFont = int.Parse(ds.Tables[0].Rows[0]["titleFont"].ToString());
                return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表 --经过改造
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select a.Id,b.Title,a.Title,Author,PostDate,IsPic,PicUrl,Body,onTop,ReadTimes,titleColor,titleFont ");
			strSql.Append(" FROM CMS_Article  a,dbo.CMS_Column b");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where a.ColumnId = b.Id and " + strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" Id,ColumnId,Title,Author,PostDate,IsPic,PicUrl,Body ");
			strSql.Append(" FROM CMS_Article ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "CMS_Article";
			parameters[1].Value = "Id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        /// <summary>
        /// 返回带栏目和专题名称的列表
        /// </summary>
        /// <param name="Order">排序字段</param>
        /// <param name="strWhere">过滤条件</param>
        /// <param name="PageIndex">第几页</param>
        /// <param name="PageSize">每页的记录条数</param>
        /// <param name="TotalRecorder">总记录数</param>
        /// <returns></returns>
        public DataSet GetPageListWithColumn(string Order, string strWhere, int PageIndex, int PageSize, ref int TotalRecorder)
        {
            if(strWhere=="") return DbHelperSQL.GetPageListCommon("select a.Id,a.Title,onTop,b.title as ZhuantiTitle,a.Author,a.PostDate,a.titleFont,a.titleColor,c.Title as ColumnName from CMS_Article a Left Join CMS_Column c On a.ColumnId = c.Id Left Join CMS_Zhuanti b On a.ZhuantiId=b.id " + strWhere, Order, PageIndex, PageSize, ref TotalRecorder);
            else return DbHelperSQL.GetPageListCommon("select a.Id,a.Title,onTop,b.title as ZhuantiTitle,a.Author,a.PostDate,a.titleFont,a.titleColor,c.Title as ColumnName from CMS_Article a Left Join CMS_Column c On a.ColumnId = c.Id Left Join CMS_Zhuanti b On a.ZhuantiId=b.id where " + strWhere, Order, PageIndex, PageSize, ref TotalRecorder);
        }

        /// <summary>
        /// 处理置顶问题
        /// </summary>
        /// <param name="id">欲被置顶新闻Id</param>
        public void doOnTop(int id)
        {
            Maticsoft.Model.CMS_Article atc = new Maticsoft.Model.CMS_Article();
            atc = GetModel(id);
            if (atc.onTop != 0) // 如果有置顶值换为0，即取消置顶
            {
                atc.onTop = 0;
            }
            else
            {
                atc.onTop = GetMaxTop(); // 若无置顶值，取最大置顶值加1后置顶
            }
            Update(atc);
        }

        /// <summary>
        /// 获得最大的onTop+1
        /// </summary>
        /// <returns></returns>
        public static int GetMaxTop()
        {
            return DbHelperSQL.GetMaxID("onTop", "CMS_Article");
        }

        #endregion  Method
    }
}

