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
		public int  Add(Maticsoft.Model.CMS_Column model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.CMS_Column model, bool ChangeParent, int oldParentId)
		{
            return dal.Update(model, ChangeParent, oldParentId);
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

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.CMS_Column GetModel(int Id)
		{
			
			return dal.GetModel(Id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
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
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        /// <summary>
        /// 自编获取数据列表
        /// </summary>
        /// <param name="strSql">数据库字符串</param>
        /// <returns></returns>
        public DataTable CustomGetList(string strSql)
        {
            return dal.CustomGetList(strSql);
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
		public List<Maticsoft.Model.CMS_Column> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
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
        /// 移动栏目
        /// </summary>
        /// <param name="Id">栏目Id</param>
        /// <param name="IsUp">上移还是下移</param>
        public void MoveList(int Id, int IsUp)
        {
            dal.MoveList(Id,IsUp);
        }

        /// <summary>
        /// 根据栏目ID获得所有包含其子栏目ID的集合 在新闻添加页面里用的
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

