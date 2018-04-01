<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="Maticsoft.Web.Admin.News" %>

<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="AddNews.aspx"><b>新增</b></a>

            <asp:GridView ID="GVinfo" runat="server" EnableModelValidation="True" DataKeyNames="Id" AutoGenerateColumns="False" OnRowCommand="GVinfo_RowCommand" >
                <Columns>
                    <asp:TemplateField HeaderText="选择">
                        <ItemTemplate>
                            <input type="checkbox" name="ArticleId" value='<%# Eval("Id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="Title" HeaderText="标题" />
                    <asp:BoundField DataField="ColumnName" HeaderText="所属栏目" />
                    <asp:BoundField DataField="Author" HeaderText="作者" />
                    <asp:BoundField DataField="PostDate" DataFormatString="{0:d}" HeaderText="日期" />
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        <ItemTemplate>
                            <a href='AddNews.aspx?id=<%# Eval("Id") %>&pageIndex=<%=AspNetPager1.CurrentPageIndex %>'>编辑</a>
                            <asp:LinkButton ID="btDel" runat="server" CausesValidation="false" CommandName="MyDel" Text="删除" OnClientClick="return confirm('确要删除吗?')">删除</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="置顶" ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="btOnTop" runat="server" Text='<%# onTopText(Eval("onTop")) %>' CommandName="Update" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
            <br />
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged" AlwaysShow="True" PageSize="4" >
            </webdiyer:AspNetPager>
        </div>
    </form>
</body>
</html>
