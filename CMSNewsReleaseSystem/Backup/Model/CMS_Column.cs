using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// CMS_Column:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public partial class CMS_Column
	{
		public CMS_Column()
		{}
		#region Model
		private int _id;
		private string _title;
		private int? _parentid;
		private string _code;
		private string _gotourl;
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
		public int? ParentId
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
		#endregion Model

	}
}

