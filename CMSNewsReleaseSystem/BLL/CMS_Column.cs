using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// CMS_Column
	/// </summary>
	public partial class CMS_Column
	{
		private readonly Maticsoft.DAL.CMS_Column dal=new Maticsoft.DAL.CMS_Column();
		public CMS_Column()
		{}
		#region  Method

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int Id)
		{
			return dal.Exists(Id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Maticsoft.Model.CMS_Column model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(Maticsoft.Model.CMS_Column model, bool ChangeParent, int oldParentId)
		{
            return dal.Update(model, ChangeParent, oldParentId);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int Id)
		{
			
			return dal.Delete(Id);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool DeleteList(string Idlist )
		{
			return dal.DeleteList(Idlist );
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Maticsoft.Model.CMS_Column GetModel(int Id)
		{
			
			return dal.GetModel(Id);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ�����
		/// </summary>
		public Maticsoft.Model.CMS_Column GetModelByCache(int Id)
		{
			
			string CacheKey = "CMS_ColumnModel-" + Id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.CMS_Column)objModel;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        /// <summary>
        /// �Ա��ȡ�����б�
        /// </summary>
        /// <param name="strSql">���ݿ��ַ���</param>
        /// <returns></returns>
        public DataTable CustomGetList(string strSql)
        {
            return dal.CustomGetList(strSql);
        }

        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Maticsoft.Model.CMS_Column> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Maticsoft.Model.CMS_Column> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.CMS_Column> modelList = new List<Maticsoft.Model.CMS_Column>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.CMS_Column model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.CMS_Column();
					if(dt.Rows[n]["Id"].ToString()!="")
					{
						model.Id=int.Parse(dt.Rows[n]["Id"].ToString());
					}
					model.Title=dt.Rows[n]["Title"].ToString();
					if(dt.Rows[n]["ParentId"].ToString()!="")
					{
						model.ParentId=int.Parse(dt.Rows[n]["ParentId"].ToString());
					}
					model.Code=dt.Rows[n]["Code"].ToString();
					model.GotoUrl=dt.Rows[n]["GotoUrl"].ToString();
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

        


        /// <summary>
        /// �ƶ���Ŀ
        /// </summary>
        /// <param name="Id">��ĿId</param>
        /// <param name="IsUp">���ƻ�������</param>
        public void MoveList(int Id, int IsUp)
        {
            dal.MoveList(Id,IsUp);
        }

        /// <summary>
        /// ������ĿID������а���������ĿID�ļ��� ���������ҳ�����õ�
        /// </summary>
        /// <param name="ColumnId"></param>
        /// <returns></returns>
        public string GetIncludeColumnId(int ColumnId)
        {
            return dal.GetIncludeColumnId(ColumnId);
        }
        #endregion  Method
    }
}

