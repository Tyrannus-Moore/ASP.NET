using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Maticsoft.BLL
{
    public class ContextHelper
    {
        #region 参数封装
        public static HttpContext Current
        {
            get { return HttpContext.Current; }
        }

        public static HttpRequest Request
        {
            get { return Current.Request; }
        }

        public static HttpResponse Response
        {
            get { return Current.Response; }
        }
        #endregion


        /// <summary>
        /// 相当于Request.QueryString;
        /// </summary>
        /// <param name="name">要查询的Name</param>
        /// <returns></returns>
        public static string ContextQuery(string name)
        {
            return Request.QueryString[name] == null ? "" : Request.QueryString[name];
        }

        /// <summary>
        /// 获取URL中的Id
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int ContextQueryId(string name)
        {
            return Validator.StrToId(ContextQuery(name));
        }

        /// <summary>
        /// 相当于Request.Form
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string ContextForm(string name)
        {
            return Request.Form[name] == null ? "" : Request.Form[name];
        }

    }
}
