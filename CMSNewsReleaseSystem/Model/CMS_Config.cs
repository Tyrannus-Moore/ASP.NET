using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// CMS_Config:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public partial class CMS_Config
	{
		public CMS_Config()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _copyright;
		private string _mode;
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
		public string CopyRight
		{
			set{ _copyright=value;}
			get{return _copyright;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Mode
		{
			set{ _mode=value;}
			get{return _mode;}
		}
		#endregion Model

	}
}

