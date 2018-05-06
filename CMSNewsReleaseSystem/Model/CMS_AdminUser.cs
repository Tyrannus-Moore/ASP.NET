using Maticsoft.DBUtility;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;

namespace Maticsoft.Model
{
	/// <summary>
	/// CMS_AdminUser:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CMS_AdminUser
	{
		public CMS_AdminUser()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _pwd;
		private int? _roleid;
        private CMS_AdminRole role;
        private static CMS_AdminUser currentAdmin;
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
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Pwd
		{
			set{ _pwd=value;}
			get{return _pwd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? RoleId
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
        /// <summary>
        /// 用户角色
        /// </summary>
        public CMS_AdminRole Role
        {
            get
            {
                if (role != null) return role;
                role = GetModel(RoleId);
                return role;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.CMS_AdminRole GetModel(int? Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,Name,AdminSetting,Setting from CMS_AdminRole ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
};
            parameters[0].Value = Id;

            Maticsoft.Model.CMS_AdminRole model = new Maticsoft.Model.CMS_AdminRole();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                model.AdminSetting = ds.Tables[0].Rows[0]["AdminSetting"].ToString();
                model.Setting = ds.Tables[0].Rows[0]["Setting"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 当前管理员
        /// </summary>
        public static CMS_AdminUser CurrentAdmin
        {
            get
            {
                if (HttpContext.Current.Session["CurrentAdmin"] == null)
                    return null;
                currentAdmin = (CMS_AdminUser)HttpContext.Current.Session["CurrentAdmin"];
                HttpContext.Current.Session["CurrentAdmin"] = currentAdmin;
                HttpContext.Current.Session.Timeout = 20;
                return currentAdmin;
            }
            set
            {
                HttpContext.Current.Session["CurrentAdmin"] = value;
            }
        }

        #endregion Model

    }
}

