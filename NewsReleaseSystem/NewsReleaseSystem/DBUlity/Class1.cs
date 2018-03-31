using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBUlity
{
    public class Class1
    {
        public static SqlConnection conn()//数据库连接字符串
        {
            String strConn = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            return conn;
        }
    }
}
