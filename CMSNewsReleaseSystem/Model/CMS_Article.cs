using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// CMS_Article:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public partial class CMS_Article
	{
		public CMS_Article()
		{}
		#region Model
		private int _id;
		private int? _columnid;
		private string _title;
		private string _author;
		private DateTime? _postdate;
		private bool? _ispic;
		private string _picurl;
		private string _body;
        private int? _onTop; //��׷�� Ϊ�����ö�
        private int _ReadTimes; //��׷��
        private string _titleColor; //��׷��
        private int _titleFont; //��׷��
        private int _ZhuantiId;//��׷�� Ϊ��������
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
		public int? ColumnId
		{
			set{ _columnid=value;}
			get{return _columnid;}
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
		public string Author
		{
			set{ _author=value;}
			get{return _author;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? PostDate
		{
			set{ _postdate=value;}
			get{return _postdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool? IsPic
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
		public string Body
		{
			set{ _body=value;}
			get{return _body;}
		}
        /// <summary>
        /// 
        /// </summary>
        public int? onTop
        {
            set { _onTop = value; }
            get { return _onTop; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ReadTimes
        {
            set { _ReadTimes = value; }
            get { return _ReadTimes; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string titleColor
        {
            set { _titleColor = value; }
            get { return _titleColor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int titleFont
        {
            set { _titleFont = value; }
            get { return _titleFont; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ZhuantiId
        {
            set { _ZhuantiId = value; }
            get { return _ZhuantiId; }
        }
        #endregion Model

    }
}

