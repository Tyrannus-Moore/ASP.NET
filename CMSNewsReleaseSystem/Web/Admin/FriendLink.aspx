<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FriendLink.aspx.cs" Inherits="Maticsoft.Web.Admin.Debug" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GVinfo" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" OnRowCommand="GVinfo_RowCommand" DataKeyNames="Id" ViewState="None">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="Title" HeaderText="网站标题" />
                    <asp:BoundField DataField="SiteUrl" HeaderText="链接" />
                    <asp:BoundField DataField="Sort" HeaderText="序号" />
                    <asp:TemplateField HeaderText="编辑" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="btEdit" runat="server" CausesValidation="false" Text="编辑" CommandName="MyEdit"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="上移" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="btUp" runat="server" CausesValidation="false" Text="上移"  CommandName="MyUp"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="下移" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="btDown" runat="server" CausesValidation="false" Text="下移" CommandName="MyDown" ></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="删除" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="btDel" runat="server" CausesValidation="false" CommandName="MyDel" Text="删除" OnClientClick="return confirm('确要删除吗?')"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Panel ID="Panel1" runat="server" Height="195px" Width="237px" BorderColor="Black" BorderWidth="2px">
                <span>站点管理</span> --<asp:Label ID="lbIns" runat="server" Text="添加"></asp:Label>
                <br />
                <br />
                网站标题:<asp:TextBox ID="tbTitle" runat="server"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="标题不能为空！" ControlToValidate="tbTitle" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                序&nbsp;&nbsp; 号:<asp:TextBox ID="tbSort" runat="server"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="序号不能为空！"  ControlToValidate="tbSort" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                链&nbsp;&nbsp; 接:<asp:TextBox ID="tbSiteUrl" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="btSubmit" runat="server" Text="确定" OnClick="btSubmit_Click" />
                <asp:Button ID="btAbandon" runat="server" Text="放弃" Visible="false" OnClick="btAbandon_Click" />
            </asp:Panel>

        </div>
    </form>
</body>
</html>
