<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Left.aspx.cs" Inherits="Maticsoft.Web.Admin.AdminLeft" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../css/menu.css" rel="stylesheet" />
<script language="javascript" src="../Scripts/jquery-1.2.6.js"></script>
    <script src="../Scripts/menu.js"></script>
</script>
</head>
<body>
  <form id="form1" runat="server">
  <div id="nav">
  <div style="border:solid 5px black">
   <div style=" font-weight:bolder; font-family:微软雅黑 幼圆 宋体; background-color :White; padding:5px 8px 5px 15px;">新闻管理后台</div>
  </div>
  <div>
      <asp:Literal ID="ltMenu" runat="server" EnableViewState="false"></asp:Literal>
  </div>
  <a href="#" onclick="if(confirm('确定退出吗?')){top.location='Login.aspx'}"><b>退出</b></a>
  </div>
  </form>
</body>
</html>


