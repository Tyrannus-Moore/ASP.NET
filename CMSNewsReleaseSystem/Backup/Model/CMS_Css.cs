using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// CMS_Css:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CMS_Css
	{
		public CMS_Css()
		{}
		#region Model
		private int _id;
		private string _filename;
		private string _describe;
		private string _body;
		private bool? _isdefault;
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
		public string FileName
		{
			set{ _filename=value;}
			get{return _filename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Describe
		{
			set{ _describe=value;}
			get{return _describe;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Body
		{
			set{ _body=value;}
			get{return _body;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool? IsDefault
		{
			set{ _isdefault=value;}
			get{return _isdefault;}
		}
		#endregion Model

	}
}

