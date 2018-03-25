using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// CMS_Album:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CMS_Album
	{
		public CMS_Album()
		{}
		#region Model
		private int _id;
		private string _albumtitle;
		private string _author;
		private string _description;
		private string _postdate;
		private string _imgname;
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
		public string AlbumTitle
		{
			set{ _albumtitle=value;}
			get{return _albumtitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Author
		{
			set{ _author=value;}
			get{return _author;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PostDate
		{
			set{ _postdate=value;}
			get{return _postdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ImgName
		{
			set{ _imgname=value;}
			get{return _imgname;}
		}
		#endregion Model

	}
}

