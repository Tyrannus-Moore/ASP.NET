using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// CMS_AdminRole:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public partial class CMS_AdminRole
	{
		public CMS_AdminRole()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _adminsetting;
		private string _setting;
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
		public string AdminSetting
		{
			set{ _adminsetting=value;}
			get{return _adminsetting;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Setting
		{
			set{ _setting=value;}
			get{return _setting;}
		}
		#endregion Model

	}
}

