using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:CMS_Video
	/// </summary>
	public partial class CMS_Video
	{
		public CMS_Video()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "CMS_Video"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CMS_Video");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.CMS_Video model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CMS_Video(");
			strSql.Append("Author,VideoTitle,VideoDescription,VideoPath,VideoPicture,VideoDate,IsLocal,VideoCode)");
			strSql.Append(" values (");
			strSql.Append("@Author,@VideoTitle,@VideoDescription,@VideoPath,@VideoPicture,@VideoDate,@IsLocal,@VideoCode)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Author", SqlDbType.VarChar,50),
					new SqlParameter("@VideoTitle", SqlDbType.VarChar,50),
					new SqlParameter("@VideoDescription", SqlDbType.VarChar,200),
					new SqlParameter("@VideoPath", SqlDbType.VarChar,50),
					new SqlParameter("@VideoPicture", SqlDbType.VarChar,50),
					new SqlParameter("@VideoDate", SqlDbType.VarChar,50),
					new SqlParameter("@IsLocal", SqlDbType.Bit,1),
					new SqlParameter("@VideoCode", SqlDbType.VarChar,50)};
			parameters[0].Value = model.Author;
			parameters[1].Value = model.VideoTitle;
			parameters[2].Value = model.VideoDescription;
			parameters[3].Value = model.VideoPath;
			parameters[4].Value = model.VideoPicture;
			parameters[5].Value = model.VideoDate;
			parameters[6].Value = model.IsLocal;
			parameters[7].Value = model.VideoCode;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(Maticsoft.Model.CMS_Video model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CMS_Video set ");
			strSql.Append("Author=@Author,");
			strSql.Append("VideoTitle=@VideoTitle,");
			strSql.Append("VideoDescription=@VideoDescription,");
			strSql.Append("VideoPath=@VideoPath,");
			strSql.Append("VideoPicture=@VideoPicture,");
			strSql.Append("VideoDate=@VideoDate,");
			strSql.Append("IsLocal=@IsLocal,");
			strSql.Append("VideoCode=@VideoCode");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Author", SqlDbType.VarChar,50),
					new SqlParameter("@VideoTitle", SqlDbType.VarChar,50),
					new SqlParameter("@VideoDescription", SqlDbType.VarChar,200),
					new SqlParameter("@VideoPath", SqlDbType.VarChar,50),
					new SqlParameter("@VideoPicture", SqlDbType.VarChar,50),
					new SqlParameter("@VideoDate", SqlDbType.VarChar,50),
					new SqlParameter("@IsLocal", SqlDbType.Bit,1),
					new SqlParameter("@VideoCode", SqlDbType.VarChar,50),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.Author;
			parameters[1].Value = model.VideoTitle;
			parameters[2].Value = model.VideoDescription;
			parameters[3].Value = model.VideoPath;
			parameters[4].Value = model.VideoPicture;
			parameters[5].Value = model.VideoDate;
			parameters[6].Value = model.IsLocal;
			parameters[7].Value = model.VideoCode;
			parameters[8].Value = model.Id;

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
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CMS_Video ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
};
			parameters[0].Value = Id;

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
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CMS_Video ");
			strSql.Append(" where Id in ("+Idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public Maticsoft.Model.CMS_Video GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,Author,VideoTitle,VideoDescription,VideoPath,VideoPicture,VideoDate,IsLocal,VideoCode from CMS_Video ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
};
			parameters[0].Value = Id;

			Maticsoft.Model.CMS_Video model=new Maticsoft.Model.CMS_Video();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
				model.Author=ds.Tables[0].Rows[0]["Author"].ToString();
				model.VideoTitle=ds.Tables[0].Rows[0]["VideoTitle"].ToString();
				model.VideoDescription=ds.Tables[0].Rows[0]["VideoDescription"].ToString();
				model.VideoPath=ds.Tables[0].Rows[0]["VideoPath"].ToString();
				model.VideoPicture=ds.Tables[0].Rows[0]["VideoPicture"].ToString();
				model.VideoDate=ds.Tables[0].Rows[0]["VideoDate"].ToString();
				if(ds.Tables[0].Rows[0]["IsLocal"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["IsLocal"].ToString()=="1")||(ds.Tables[0].Rows[0]["IsLocal"].ToString().ToLower()=="true"))
					{
						model.IsLocal=true;
					}
					else
					{
						model.IsLocal=false;
					}
				}
				model.VideoCode=ds.Tables[0].Rows[0]["VideoCode"].ToString();
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id,Author,VideoTitle,VideoDescription,VideoPath,VideoPicture,VideoDate,IsLocal,VideoCode ");
			strSql.Append(" FROM CMS_Video ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			strSql.Append(" Id,Author,VideoTitle,VideoDescription,VideoPath,VideoPicture,VideoDate,IsLocal,VideoCode ");
			strSql.Append(" FROM CMS_Video ");
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
			parameters[0].Value = "CMS_Video";
			parameters[1].Value = "Id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

