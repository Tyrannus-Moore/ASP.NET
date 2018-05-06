<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Role.aspx.cs" Inherits="Maticsoft.Web.Admin.Role" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="AddRole.aspx"><b>新增</b></a>
            <asp:GridView ID="GVinfo" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" OnRowCommand="GVinfo_RowCommand" DataKeyNames="Id">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" />
                    <asp:BoundField DataField="Name" HeaderText="角色名称" />
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <a href='AddRole.aspx?id=<%# Eval("Id")%>'>编辑</a>
                            <asp:LinkButton ID="btDel" runat="server" CausesValidation="false" CommandName="MyDel" Text="删除" OnClientClick="return confirm('确要删除吗?')">删除</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
