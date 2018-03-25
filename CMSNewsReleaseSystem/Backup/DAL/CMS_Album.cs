using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:CMS_Album
	/// </summary>
	public partial class CMS_Album
	{
		public CMS_Album()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "CMS_Album"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CMS_Album");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.CMS_Album model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CMS_Album(");
			strSql.Append("AlbumTitle,Author,Description,PostDate,ImgName)");
			strSql.Append(" values (");
			strSql.Append("@AlbumTitle,@Author,@Description,@PostDate,@ImgName)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@AlbumTitle", SqlDbType.VarChar,50),
					new SqlParameter("@Author", SqlDbType.VarChar,50),
					new SqlParameter("@Description", SqlDbType.VarChar,50),
					new SqlParameter("@PostDate", SqlDbType.VarChar,50),
					new SqlParameter("@ImgName", SqlDbType.VarChar,50)};
			parameters[0].Value = model.AlbumTitle;
			parameters[1].Value = model.Author;
			parameters[2].Value = model.Description;
			parameters[3].Value = model.PostDate;
			parameters[4].Value = model.ImgName;

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
		public bool Update(Maticsoft.Model.CMS_Album model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CMS_Album set ");
			strSql.Append("AlbumTitle=@AlbumTitle,");
			strSql.Append("Author=@Author,");
			strSql.Append("Description=@Description,");
			strSql.Append("PostDate=@PostDate,");
			strSql.Append("ImgName=@ImgName");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@AlbumTitle", SqlDbType.VarChar,50),
					new SqlParameter("@Author", SqlDbType.VarChar,50),
					new SqlParameter("@Description", SqlDbType.VarChar,50),
					new SqlParameter("@PostDate", SqlDbType.VarChar,50),
					new SqlParameter("@ImgName", SqlDbType.VarChar,50),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.AlbumTitle;
			parameters[1].Value = model.Author;
			parameters[2].Value = model.Description;
			parameters[3].Value = model.PostDate;
			parameters[4].Value = model.ImgName;
			parameters[5].Value = model.Id;

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
			strSql.Append("delete from CMS_Album ");
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
			strSql.Append("delete from CMS_Album ");
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
		public Maticsoft.Model.CMS_Album GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,AlbumTitle,Author,Description,PostDate,ImgName from CMS_Album ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
};
			parameters[0].Value = Id;

			Maticsoft.Model.CMS_Album model=new Maticsoft.Model.CMS_Album();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
				model.AlbumTitle=ds.Tables[0].Rows[0]["AlbumTitle"].ToString();
				model.Author=ds.Tables[0].Rows[0]["Author"].ToString();
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				model.PostDate=ds.Tables[0].Rows[0]["PostDate"].ToString();
				model.ImgName=ds.Tables[0].Rows[0]["ImgName"].ToString();
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
			strSql.Append("select Id,AlbumTitle,Author,Description,PostDate,ImgName ");
			strSql.Append(" FROM CMS_Album ");
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
			strSql.Append(" Id,AlbumTitle,Author,Description,PostDate,ImgName ");
			strSql.Append(" FROM CMS_Album ");
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
			parameters[0].Value = "CMS_Album";
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

