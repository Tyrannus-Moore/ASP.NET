<%@ WebHandler Language="C#" Class="theAjax" %>

using System;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

public class theAjax : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string myName = context.Request["myName"].ToString();
        String strConn = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        String sd = "select * from users where username like '" + myName + "'";
        SqlConnection conn = new SqlConnection(strConn);
        SqlCommand cmd = new SqlCommand(sd, conn);
        conn.Open();
        var Result = cmd.ExecuteScalar();
        if (Result == null)
        {
            context.Response.Write("可以使用");
        }
        else
        {
            context.Response.Write("已经被注册");
        }
        conn.Close();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}