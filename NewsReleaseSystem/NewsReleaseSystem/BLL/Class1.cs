using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public class Class1
    {
        public static void CheckUser(bool bool1,Label label1)
        {
            if (bool1 == true)
            {
                label1.Text = "密码或账户错误！";
            }
        }
    }
}
