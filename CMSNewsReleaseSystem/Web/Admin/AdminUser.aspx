<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminUser.aspx.cs" Inherits="Maticsoft.Web.Admin.AdminUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btAdd" runat="server" Text="新增" OnClick="btAdd_Click" />
            <asp:GridView ID="GVinfo" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" OnRowCommand="GVinfo_RowCommand" DataKeyNames="Id">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" />
                    <asp:BoundField DataField="Name" HeaderText="管理员名称" />
                    <asp:BoundField DataField="RoleName" HeaderText="角色名称" />
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <asp:LinkButton ID="btUp" runat="server" CausesValidation="false" CommandName="MyUp" Text="修改">修改</asp:LinkButton>
                            <asp:LinkButton ID="btDel" runat="server" CausesValidation="false" CommandName="MyDel" Text="删除" OnClientClick="return confirm('确要删除吗?')">删除</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <asp:Panel ID="Panel1" runat="server" Visible="false">
                用户名: <asp:TextBox ID="tbUserName" runat="server"></asp:TextBox>
                <br />
                输入密码: <asp:TextBox ID="tbUserPwd" runat="server" TextMode="Password"></asp:TextBox>
                <br />
                确认密码: <asp:TextBox ID="tbUserPwd2" runat="server" TextMode="Password"></asp:TextBox>
                <br />
                所属角色: <asp:DropDownList ID="ddlRole" runat="server"></asp:DropDownList>
                <br />
                <asp:Button ID="btSubmit" runat="server" Text="确定" OnClick="btSubmit_Click" style="height: 21px" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
