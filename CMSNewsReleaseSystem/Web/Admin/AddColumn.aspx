<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddColumn.aspx.cs" Inherits="Maticsoft.Web.Admin.AddColumn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <th>编辑栏目信息</th>
            </tr>
            <tr>
                <td>栏目名称</td>
                <td>
                    <asp:TextBox ID="tbTitle" runat="server"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td>上级栏目</td>
                <td>
                    <asp:DropDownList ID="ddlParentId" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>栏目类型</td>
                <td>
                    <asp:CheckBox ID="cbLink" runat="server" OnCheckedChanged="cbLink_CheckedChanged" autopostback="true" />是否跳转栏目
                </td>
            </tr>
            <asp:Panel ID="Panel1" runat="server" Visible="false">
            <tr>
                <td>跳转地址</td>
                <td>
                    <asp:TextBox ID="tbLink" runat="server"></asp:TextBox>
                </td>
            </tr>
            </asp:Panel>
            <tr>
                <td>是否参与导航</td>
                <td>
                    <asp:CheckBox ID="cbIsNavi" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btSave" runat="server" Text="保存" OnClick="btSave_Click" />
                </td>
            </tr>
        </table>
            

    </form>
</body>
</html>
