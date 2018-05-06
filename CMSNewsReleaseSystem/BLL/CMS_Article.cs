using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// CMS_Article
	/// </summary>
	public partial class CMS_Article
	{
		private readonly Maticsoft.DAL.CMS_Article dal=new Maticsoft.DAL.CMS_Article();
		public CMS_Article()
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
		public int  Add(Maticsoft.Model.CMS_Article model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(Maticsoft.Model.CMS_Article model)
		{
			return dal.Update(model);
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

        public bool MoveList(string Idlist,int columnId)
        {
            return dal.MoveList(Idlist, columnId);
        }

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Maticsoft.Model.CMS_Article GetModel(int Id)
		{
			
			return dal.GetModel(Id);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ�����
		/// </summary>
		public Maticsoft.Model.CMS_Article GetModelByCache(int Id)
		{
			
			string CacheKey = "CMS_ArticleModel-" + Id;
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
			return (Maticsoft.Model.CMS_Article)objModel;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
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
		public List<Maticsoft.Model.CMS_Article> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Maticsoft.Model.CMS_Article> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.CMS_Article> modelList = new List<Maticsoft.Model.CMS_Article>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.CMS_Article model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.CMS_Article();
					if(dt.Rows[n]["Id"].ToString()!="")
					{
						model.Id=int.Parse(dt.Rows[n]["Id"].ToString());
					}
					if(dt.Rows[n]["ColumnId"].ToString()!="")
					{
						model.ColumnId=int.Parse(dt.Rows[n]["ColumnId"].ToString());
					}
					model.Title=dt.Rows[n]["Title"].ToString();
					model.Author=dt.Rows[n]["Author"].ToString();
					if(dt.Rows[n]["PostDate"].ToString()!="")
					{
						model.PostDate=DateTime.Parse(dt.Rows[n]["PostDate"].ToString());
					}
					if(dt.Rows[n]["IsPic"].ToString()!="")
					{
						if((dt.Rows[n]["IsPic"].ToString()=="1")||(dt.Rows[n]["IsPic"].ToString().ToLower()=="true"))
						{
						model.IsPic=true;
						}
						else
						{
							model.IsPic=false;
						}
					}
					model.PicUrl=dt.Rows[n]["PicUrl"].ToString();
					model.Body=dt.Rows[n]["Body"].ToString();
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
        /// ���ش���Ŀ��ר�����Ƶ��б�
        /// </summary>
        /// <param name="Order">�����ֶ�</param>
        /// <param name="strWhere">��������</param>
        /// <param name="PageIndex">�ڼ�ҳ</param>
        /// <param name="PageSize">ÿҳ�ļ�¼����</param>
        /// <param name="TotalRecorder">�ܼ�¼��</param>
        /// <returns></returns>
        public DataSet GetPageListWithColumn(string Order, string strWhere, int PageIndex, int PageSize, ref int TotalRecorder)
        {
            return dal.GetPageListWithColumn(Order, strWhere, PageIndex, PageSize,ref TotalRecorder);
        }

        /// <summary>
        /// �����ö�����
        /// </summary>
        /// <param name="id"></param>
        public void doOnTop(int id)
        {
            dal.doOnTop(id);
        }

        #endregion  Method
    }
}

