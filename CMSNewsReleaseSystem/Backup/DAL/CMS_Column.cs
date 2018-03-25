using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:CMS_Column
	/// </summary>
	public partial class CMS_Column
	{
		public CMS_Column()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "CMS_Column"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CMS_Column");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.CMS_Column model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CMS_Column(");
			strSql.Append("Title,ParentId,Code,GotoUrl)");
			strSql.Append(" values (");
			strSql.Append("@Title,@ParentId,@Code,@GotoUrl)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.VarChar,50),
					new SqlParameter("@ParentId", SqlDbType.Int,4),
					new SqlParameter("@Code", SqlDbType.VarChar,50),
					new SqlParameter("@GotoUrl", SqlDbType.VarChar,50)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.ParentId;
			parameters[2].Value = model.Code;
			parameters[3].Value = model.GotoUrl;

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
		public bool Update(Maticsoft.Model.CMS_Column model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CMS_Column set ");
			strSql.Append("Title=@Title,");
			strSql.Append("ParentId=@ParentId,");
			strSql.Append("Code=@Code,");
			strSql.Append("GotoUrl=@GotoUrl");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.VarChar,50),
					new SqlParameter("@ParentId", SqlDbType.Int,4),
					new SqlParameter("@Code", SqlDbType.VarChar,50),
					new SqlParameter("@GotoUrl", SqlDbType.VarChar,50),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.ParentId;
			parameters[2].Value = model.Code;
			parameters[3].Value = model.GotoUrl;
			parameters[4].Value = model.Id;

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
			strSql.Append("delete from CMS_Column ");
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
			strSql.Append("delete from CMS_Column ");
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
		public Maticsoft.Model.CMS_Column GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,Title,ParentId,Code,GotoUrl from CMS_Column ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
};
			parameters[0].Value = Id;

			Maticsoft.Model.CMS_Column model=new Maticsoft.Model.CMS_Column();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				if(ds.Tables[0].Rows[0]["ParentId"].ToString()!="")
				{
					model.ParentId=int.Parse(ds.Tables[0].Rows[0]["ParentId"].ToString());
				}
				model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				model.GotoUrl=ds.Tables[0].Rows[0]["GotoUrl"].ToString();
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
			strSql.Append("select Id,Title,ParentId,Code,GotoUrl ");
			strSql.Append(" FROM CMS_Column ");
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
			strSql.Append(" Id,Title,ParentId,Code,GotoUrl ");
			strSql.Append(" FROM CMS_Column ");
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
			parameters[0].Value = "CMS_Column";
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

