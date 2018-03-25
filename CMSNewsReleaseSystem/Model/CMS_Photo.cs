using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// CMS_Photo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CMS_Photo
	{
		public CMS_Photo()
		{}
		#region Model
		private int _id;
		private string _phototitle;
		private int? _albumid;
		private string _author;
		private string _adddate;
		private string _description;
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
		public string PhotoTitle
		{
			set{ _phototitle=value;}
			get{return _phototitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AlbumId
		{
			set{ _albumid=value;}
			get{return _albumid;}
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
		public string AddDate
		{
			set{ _adddate=value;}
			get{return _adddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
		}
		#endregion Model

	}
}

