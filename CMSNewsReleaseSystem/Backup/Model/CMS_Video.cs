using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// CMS_Video:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CMS_Video
	{
		public CMS_Video()
		{}
		#region Model
		private int _id;
		private string _author;
		private string _videotitle;
		private string _videodescription;
		private string _videopath;
		private string _videopicture;
		private string _videodate;
		private bool? _islocal;
		private string _videocode;
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
		public string Author
		{
			set{ _author=value;}
			get{return _author;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string VideoTitle
		{
			set{ _videotitle=value;}
			get{return _videotitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string VideoDescription
		{
			set{ _videodescription=value;}
			get{return _videodescription;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string VideoPath
		{
			set{ _videopath=value;}
			get{return _videopath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string VideoPicture
		{
			set{ _videopicture=value;}
			get{return _videopicture;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string VideoDate
		{
			set{ _videodate=value;}
			get{return _videodate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool? IsLocal
		{
			set{ _islocal=value;}
			get{return _islocal;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string VideoCode
		{
			set{ _videocode=value;}
			get{return _videocode;}
		}
		#endregion Model

	}
}

