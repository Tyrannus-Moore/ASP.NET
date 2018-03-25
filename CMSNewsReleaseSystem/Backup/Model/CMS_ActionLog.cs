using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// CMS_ActionLog:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CMS_ActionLog
	{
		public CMS_ActionLog()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _description;
		private string _time;
		private string _type;
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
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Time
		{
			set{ _time=value;}
			get{return _time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		#endregion Model

	}
}

