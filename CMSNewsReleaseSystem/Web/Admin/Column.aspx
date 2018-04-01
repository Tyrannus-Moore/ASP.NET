<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Column.aspx.cs" Inherits="Maticsoft.Web.Admin.Column" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="AddColumn.aspx"><b>新增</b></a>
            <asp:GridView ID="GVinfo" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" DataKeyNames="Id" OnRowCommand="GVinfo_RowCommand" ViewState="None" >
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:TemplateField HeaderText="栏目名称">
                        <ItemTemplate>
                            <%# GetColumnName(Eval("title", "{0}"), Eval("code", "{0}"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="是否参与导航">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# SelectImage(Eval("IsNavigator")) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        <ItemTemplate>
                            <a href='AddColumn.aspx?Id=<%# Eval("Id") %>'>编辑</a>
                            <a href='?action=move&isup=1&Id=<%# Eval("Id") %>'>上移</a>
                            <a href='?action=move&isup=0&Id=<%# Eval("Id") %>'>下移</a>
                            <asp:LinkButton ID="btDel" runat="server" CausesValidation="false" CommandName="MyDel" Text="删除" OnClientClick="return confirm('确要删除吗?')">删除</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
