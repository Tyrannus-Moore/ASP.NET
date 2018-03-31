using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace DAL
{
    public class Class1
    {
        public static bool CheckUser(string name, string pwd)
        {
            SqlConnection conn=DBUlity.Class1.conn();
            string sd = "select * from users where username like '" + name + "'";
            string pwdmd5= FormsAuthentication.HashPasswordForStoringInConfigFile(pwd, "MD5");
            string sd2 = "select * from users where username like '" + name + "' and password like '" + pwdmd5 + "'";
            SqlCommand cmd = new SqlCommand(sd, conn);
            conn.Open();
            var Result = cmd.ExecuteScalar();
            if (Result == null)
            { 
            return false;
            }else{
             cmd = new SqlCommand(sd2, conn);
            Result = cmd.ExecuteScalar();
            if (Result == null)
            {
              return false;
            }
            else
            {
                return true;
            }
            }
            
        }
        public static void RegisterUser(string name,string pwd)
        {
            
            SqlConnection conn = DBUlity.Class1.conn();
            string pwdmd5= FormsAuthentication.HashPasswordForStoringInConfigFile(pwd, "MD5");
            string sd = "insert into users(username,password) values ('" + name + "','" + pwdmd5 + "')";
            SqlCommand cmd = new SqlCommand(sd, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        
        }
        public static void DeleteNews(GridView GVinfo)
        {
            string sd = "delete from news where newsTitle in ('";
            string tmpsd = "";
            for (int i = 0; i <= GVinfo.Rows.Count - 1; i++)
            {
                CheckBox cb = (CheckBox)GVinfo.Rows[i].FindControl("cbSelect");
                if (cb.Checked)
                {
                    tmpsd += GVinfo.DataKeys[i].Value + "','";//下次前面再不加DataKeys就剁手
                }
            }
            tmpsd = tmpsd.Substring(0, tmpsd.Length - 2) + ")";
            sd += tmpsd;
            DBConnect(sd,GVinfo);
        
        
        }
        public static void DBConnect(string sd,GridView GVinfo)
        {
            SqlConnection conn = DBUlity.Class1.conn();
            SqlCommand cmd = new SqlCommand(sd, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            FlushConnection(GVinfo);
        
        }
        public static void FlushConnection(GridView GVinfo)
        {
            SqlConnection conn = DBUlity.Class1.conn();
            string sd = "select newsTitle as 标题,pubTime as 时间,publisher as 发布者,readTimes as 阅读次数 from news";
            SqlCommand cmd = new SqlCommand(sd, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            GVinfo.DataSource = dr;
            GVinfo.DataBind();
            conn.Close();
            dr.Close();
        
        }
        public static int DBComparison(string sd,int releaseLock,Label lbWarning)
        {
            SqlConnection conn = DBUlity.Class1.conn();
            SqlCommand cmd = new SqlCommand(sd, conn);
            conn.Open();
            var Result = cmd.ExecuteScalar();
            if (Result != null)
            {
                lbWarning.Text = "新闻名被占用辣，换个试试？";
                return 0;
            }
            else
            {
                lbWarning.Text = "";
                return 1;
            }
        }
        public static string DBModify(string sd)

        {
         string content="";
            SqlConnection conn = DBUlity.Class1.conn();
        SqlCommand cmd = new SqlCommand(sd, conn);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            content = dr[0].ToString();
        }
        conn.Close();
        //FlushConnection();
        return content;
        
        }
        public static void GVinfo_RowCommand(GridView GVinfo, GridViewCommandEventArgs e,string title,Label tbMdTitle,Label tbMdContent,Panel Panel3)
        {
            int theRow = 0;//保存行号
            string theCol = "";//保存列位置信息
            theRow = ((GridViewRow)((Button)e.CommandSource).NamingContainer).RowIndex;
            theCol = e.CommandName.ToString();
            title = (string)GVinfo.DataKeys[theRow].Value;//注意此处可能有个bug，两篇新闻同样标题？--解决
            if (e.CommandName == "MyEdit")
            {
                string sd = "select newsContent from news where newsTitle like '" + title + "'";
                tbMdTitle.Text = title;
                tbMdContent.Text = DBModify(sd);
                Panel3.Visible = true;
            }
            else
            {
                string sd = "delete from news where newsTitle like '" + title + "'";
                DBConnect(sd,GVinfo);
            }
        
        
        }
        public static void FlushConnection(string sd,GridView GVinfo)
        {
            SqlConnection conn = DBUlity.Class1.conn();
            SqlCommand cmd = new SqlCommand(sd, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            GVinfo.DataSource = dr;
            GVinfo.DataBind();
            conn.Close();
            dr.Close();
        
        
        }
        public static void DBfocus(GridView GVinfo2)
        {

            string sd = "select newsTitle as 标题,newsContent as 内容 from news where classid = 2";
            SqlConnection conn = DBUlity.Class1.conn();
            SqlCommand cmd = new SqlCommand(sd, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            GVinfo2.DataSource = dr;
            GVinfo2.DataBind();
            conn.Close();
            dr.Close();
        }
        public static void Flush(Label lbTitle,Label lbContent,Label lbPubTime,Label lbPublisher,Label lbReadTimes,string title)
        {
            SqlConnection conn = DBUlity.Class1.conn();

            string sd = "select newsTitle as 标题,newsContent as 内容,pubTime as 时间,publisher as 发布者,readTimes as 阅读次数 from news where newsTitle like '" +title + "'";
            SqlCommand cmd = new SqlCommand(sd, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lbTitle.Text = dr[0].ToString();
                lbContent.Text = dr[1].ToString();
                lbPubTime.Text = dr[2].ToString();
                lbPublisher.Text = dr[3].ToString();
                lbReadTimes.Text = dr[4].ToString();
            }
            dr.Close();
            sd = "update news set readTimes = readTimes + 1 where newsTitle like '" + title + "'";
            SqlCommand cmd2 = new SqlCommand(sd, conn);
            cmd2.ExecuteNonQuery();
            conn.Close();
        }

        public static int useJSAjax(Label lbWarning,string sd)
        {
            SqlConnection conn = DBUlity.Class1.conn();
            SqlCommand cmd = new SqlCommand(sd, conn);
            conn.Open();
            var Result = cmd.ExecuteScalar();
            if (Result == null)
            {
                lbWarning.Text = "可以使用";
                return 1;
            }
            else
            {
                lbWarning.Text = "已经被注册";
                return 0;
            }
            conn.Close();
        }
    }
}
