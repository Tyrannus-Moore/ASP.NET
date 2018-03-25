using System;
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
		#endregion Model

	}
}

