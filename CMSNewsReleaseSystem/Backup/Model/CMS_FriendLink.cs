using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// CMS_FriendLink:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CMS_FriendLink
	{
		public CMS_FriendLink()
		{}
		#region Model
		private int _id;
		private string _title;
		private bool _ispic;
		private string _picurl;
		private string _siteurl;
		private int? _sort;
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
		public bool IsPic
		{
			set{ _ispic=value;}
			get{return _ispic;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PicUrl
		{
			set{ _picurl=value;}
			get{return _picurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SiteUrl
		{
			set{ _siteurl=value;}
			get{return _siteurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Sort
		{
			set{ _sort=value;}
			get{return _sort;}
		}
		#endregion Model

	}
}

