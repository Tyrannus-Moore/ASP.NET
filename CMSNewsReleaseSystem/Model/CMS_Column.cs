using Maticsoft.DBUtility;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Maticsoft.Model
{
	/// <summary>
	/// CMS_Column:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CMS_Column
	{
		public CMS_Column()
		{}
		#region Model
		private int _id;
		private string _title;
		private int _parentid;
		private string _code;
		private string _gotourl;
        private int _isNavigator;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ParentId
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GotoUrl
		{
			set{ _gotourl=value;}
			get{return _gotourl;}
		}
        /// <summary>
        /// 
        /// </summary>
        public int IsNavigator
        {
            set { _isNavigator = value; }
            get { return _isNavigator; }
        }


        //自编方法
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static CMS_Column GetModel(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,Title,ParentId,Code,GotoUrl,IsNavigator ");
            strSql.Append(" FROM CMS_Column ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;
            CMS_Column model = new CMS_Column();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                if (ds.Tables[0].Rows[0]["ParentId"].ToString() != "")
                {
                    model.ParentId = int.Parse(ds.Tables[0].Rows[0]["ParentId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["GotoUrl"].ToString() != "")
                {
                    model.GotoUrl = ds.Tables[0].Rows[0]["GotoUrl"].ToString();
                }
                model.Code = ds.Tables[0].Rows[0]["Code"].ToString();
                model.IsNavigator = int.Parse(ds.Tables[0].Rows[0]["IsNavigator"].ToString());
            }
            return model;
        }

        /// <summary>
        /// 新Code
        /// </summary>
        /// <returns></returns>
        public string NewCode()
        {
            object tmp = DbHelperSQL.GetSingle("Select top 1 Code from CMS_Column where ParentId=" + ParentId + " order by Code desc");
            string newCode = "";
            if (tmp == null) newCode = "0001";
            else
            {
                string maxCode = tmp.ToString();
                maxCode = maxCode.Substring(maxCode.Length - 4);
                int intcode = int.Parse(maxCode) + 1;
                newCode = intcode.ToString().PadLeft(4, '0');
            }

            if (ParentId == 0) return newCode;
            else
            {
                CMS_Column parent = GetModel(ParentId);
                return parent.Code + newCode;
            }
        }

        #endregion Model

    }
}

