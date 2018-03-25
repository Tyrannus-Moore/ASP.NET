<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Maticsoft.Web.Admin.Index" %>

<%@ Register src="top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="bottom.ascx" tagname="bottom" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理中心</title>     
    <link href="../css/Style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #LeftTree
        {
            width: 98%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div  style="width: 94%; margin-right:8px; margin-left: 62px; margin-bottom: 0px" >
        <uc1:top ID="top1" runat="server" />
    </div>
    <div style="width: 100%" >
    <table width="92%"  align="center">
           <tr align="center"  style="width: 100%" >
                <td align="center" width="25%" >
                       <iframe id="LeftTree" name="LeftTree" src="Left.aspx" scrolling="no" 
                           height="900px" frameborder="0">
                       </iframe>
                </td>
            
                <td align="center"  style="width: 75%">
                    <iframe id="RightMain" name ="RightMain" src="Right.aspx" height="900px"
                        scrolling="auto" width="100%"  frameborder="0" >
                    </iframe>
                </td>
           </tr>
        </table>
    </div>
     <div class="footer" style="width: 92%; margin-right:8px; margin-left: 62px;">
         <uc2:bottom ID="bottom1" runat="server" />
    </div>
    </form>
</body>
</html>
