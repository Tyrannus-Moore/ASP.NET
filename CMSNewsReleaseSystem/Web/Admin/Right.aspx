<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Right.aspx.cs" Inherits="Maticsoft.Web.Admin.Right" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <style type="text/css">
            h1 { display : inline}
            h2 { display : inline}
        </style>
        <h1>欢迎!</h1> 
        <h2>管理员<asp:Literal ID="ltName" runat="server"></asp:Literal>,</h2> 
        <h2>您具有如下权限:</h2>
        <table>
            <tr>
                <td>
                    系统权限:<br/>
                </td>
                <td>
                    <asp:Literal ID="ltAdminSetting" runat="server" EnableViewState="false"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td>
                    栏目权限:
                </td>
                <td>
                    <asp:Literal ID="ltSetting" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="hfSetting" runat="server" EnableViewState="false" />
    </form>
            <script src="jquery-1.2.6.js"></script>
        <script src="../Scripts/jquery-1.2.6.js"></script>
        <script type="text/javascript">
            $(function () {
                var setting = $("#hfSetting").val();
                $("input").each(function () {
                    var val = $(this).val();
                    if (setting.indexOf(val) > -1)
                        $(this).attr("checked", true);
                });
            });
    </script>
</body>
</html>
