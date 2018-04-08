<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNews.aspx.cs" Inherits="Maticsoft.Web.Admin.AddNews" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

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
                <td>文章标题</td>
                <td>
                    <asp:TextBox ID="tbTitle" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>标题颜色和字体</td>
                <td>
                    颜色: <asp:DropDownList ID="ddlTitCor" runat="server">
                        <asp:ListItem Text="黑色" Value="black"></asp:ListItem>
                        <asp:ListItem Text="蓝色" Value="blue"></asp:ListItem>
                        <asp:ListItem Text="黄色" Value="yellow"></asp:ListItem>
                        <asp:ListItem Text="红色" Value="red"></asp:ListItem>
                        <asp:ListItem Text="绿色" Value="green"></asp:ListItem>
                        </asp:DropDownList>
                </td>
                <td>
                    字体: <asp:DropDownList ID="ddlTitSty" runat="server">
                        <asp:ListItem Text="标准" Value="1"></asp:ListItem>
                        <asp:ListItem Text="粗体" Value="2"></asp:ListItem>
                        <asp:ListItem Text="斜体" Value="3"></asp:ListItem>
                        <asp:ListItem Text="粗斜" Value="4"></asp:ListItem>
                        </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>作者</td>
                <td>
                    <asp:TextBox ID="tbAuthor" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>所属栏目</td>
                <td>
                    <asp:DropDownList ID="ddlCol" runat="server"></asp:DropDownList>
                </td>
            </tr>
        </table>

        <table>
            <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server"></FCKeditorV2:FCKeditor>
        </table>
        
        <asp:Button ID="btSave" runat="server" Text="确定" OnClick="btSave_Click" />
    </form>
</body>
</html>
