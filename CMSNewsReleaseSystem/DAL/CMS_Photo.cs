using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:CMS_Photo
	/// </summary>
	public partial class CMS_Photo
	{
		public CMS_Photo()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "CMS_Photo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CMS_Photo");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.CMS_Photo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CMS_Photo(");
			strSql.Append("PhotoTitle,AlbumId,Author,AddDate,Description)");
			strSql.Append(" values (");
			strSql.Append("@PhotoTitle,@AlbumId,@Author,@AddDate,@Description)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@PhotoTitle", SqlDbType.VarChar,50),
					new SqlParameter("@AlbumId", SqlDbType.Int,4),
					new SqlParameter("@Author", SqlDbType.VarChar,50),
					new SqlParameter("@AddDate", SqlDbType.VarChar,50),
					new SqlParameter("@Description", SqlDbType.VarChar,50)};
			parameters[0].Value = model.PhotoTitle;
			parameters[1].Value = model.AlbumId;
			parameters[2].Value = model.Author;
			parameters[3].Value = model.AddDate;
			parameters[4].Value = model.Description;

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
		public bool Update(Maticsoft.Model.CMS_Photo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CMS_Photo set ");
			strSql.Append("PhotoTitle=@PhotoTitle,");
			strSql.Append("AlbumId=@AlbumId,");
			strSql.Append("Author=@Author,");
			strSql.Append("AddDate=@AddDate,");
			strSql.Append("Description=@Description");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@PhotoTitle", SqlDbType.VarChar,50),
					new SqlParameter("@AlbumId", SqlDbType.Int,4),
					new SqlParameter("@Author", SqlDbType.VarChar,50),
					new SqlParameter("@AddDate", SqlDbType.VarChar,50),
					new SqlParameter("@Description", SqlDbType.VarChar,50),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.PhotoTitle;
			parameters[1].Value = model.AlbumId;
			parameters[2].Value = model.Author;
			parameters[3].Value = model.AddDate;
			parameters[4].Value = model.Description;
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
			strSql.Append("delete from CMS_Photo ");
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
			strSql.Append("delete from CMS_Photo ");
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
		public Maticsoft.Model.CMS_Photo GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,PhotoTitle,AlbumId,Author,AddDate,Description from CMS_Photo ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
};
			parameters[0].Value = Id;

			Maticsoft.Model.CMS_Photo model=new Maticsoft.Model.CMS_Photo();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
				model.PhotoTitle=ds.Tables[0].Rows[0]["PhotoTitle"].ToString();
				if(ds.Tables[0].Rows[0]["AlbumId"].ToString()!="")
				{
					model.AlbumId=int.Parse(ds.Tables[0].Rows[0]["AlbumId"].ToString());
				}
				model.Author=ds.Tables[0].Rows[0]["Author"].ToString();
				model.AddDate=ds.Tables[0].Rows[0]["AddDate"].ToString();
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
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
			strSql.Append("select Id,PhotoTitle,AlbumId,Author,AddDate,Description ");
			strSql.Append(" FROM CMS_Photo ");
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
			strSql.Append(" Id,PhotoTitle,AlbumId,Author,AddDate,Description ");
			strSql.Append(" FROM CMS_Photo ");
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
			parameters[0].Value = "CMS_Photo";
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

