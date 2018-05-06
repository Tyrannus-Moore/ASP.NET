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
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			return dal.Exists(Id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Maticsoft.Model.CMS_Article model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.CMS_Article model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Id)
		{
			
			return dal.Delete(Id);
		}
		/// <summary>
		/// 删除一条数据
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
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.CMS_Article GetModel(int Id)
		{
			
			return dal.GetModel(Id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
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
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.CMS_Article> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
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
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        /// <summary>
        /// 返回带栏目和专题名称的列表
        /// </summary>
        /// <param name="Order">排序字段</param>
        /// <param name="strWhere">过滤条件</param>
        /// <param name="PageIndex">第几页</param>
        /// <param name="PageSize">每页的记录条数</param>
        /// <param name="TotalRecorder">总记录数</param>
        /// <returns></returns>
        public DataSet GetPageListWithColumn(string Order, string strWhere, int PageIndex, int PageSize, ref int TotalRecorder)
        {
            return dal.GetPageListWithColumn(Order, strWhere, PageIndex, PageSize,ref TotalRecorder);
        }

        /// <summary>
        /// 处理置顶问题
        /// </summary>
        /// <param name="id"></param>
        public void doOnTop(int id)
        {
            dal.doOnTop(id);
        }

        #endregion  Method
    }
}

