<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BackgroundPage.aspx.cs" Inherits="BackgroundPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link type="text/css" rel="stylesheet" href="backgroundpage.css" />
    <style type="text/css">
        .FloatEnable{
        float:left;
            margin-top: 0px;
        }
    </style>
    <script type="text/javascript">
        function Confirm() {
            if (confirm('确认删除此选项？')) {
                return true;
            }
            return false;
        }
        window.onload = function () {
            var btn1 = document.getElementById('btDel');
            var btn2 = document.getElementById('btEdit');
            var btn3 = document.getElementById('btDelete');
            btn1.onclick = function () {
                if (confirm('确认删除所选选项？')) {
                    return ture;
                }
                return false;
            }
            btn2.onclick = function () {
                if (confirm('确认修改此选项？')) {
                    return true;
                }
                return false;
            }
            btn3.onclick = function () {
                if (confirm('确认删除此选项？')) {
                    return true;
                }
                return false;
            }
        }
    </script>
</head>
<body>

    <form id="form1" runat="server">
        <fieldset id="fieldset1">
            <legend id="legend1">新闻后台管理</legend>
        <p id="header-topic"><span id="span1">你好:</span><asp:Label ID="lbAdm" runat="server" Text=""></asp:Label></p>
        <asp:GridView ID="GVinfo" runat="server" AutoGenerateColumns="False" DataKeyNames="标题" OnRowCommand="GVinfo_RowCommand" Width="881px" Height="214px">
            <Columns>
                <asp:TemplateField HeaderText="选择">
                    <ItemTemplate>
                        <asp:CheckBox ID="cbSelect" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="标题" DataField="标题" />
                <asp:BoundField HeaderText="时间" DataField="时间" />
                <asp:BoundField HeaderText="发布者" DataField="发布者" />
                <asp:BoundField HeaderText="阅读次数" DataField="阅读次数" />

                <asp:TemplateField HeaderText="编辑" ShowHeader="False" ControlStyle-BackColor="blue" ControlStyle-BorderColor="blue" ControlStyle-BorderWidth="1px" ControlStyle-ForeColor="white" ControlStyle-Font-Bold="false">
                    <ItemTemplate>
                        <asp:Button ID="btEdit" runat="server" CommandName="MyEdit" Text="编辑" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="删除" ShowHeader="False" ControlStyle-BackColor="red" ControlStyle-BorderColor="red" ControlStyle-BorderWidth="1px" ControlStyle-ForeColor="white" ControlStyle-Font-Bold="false">
                    <ItemTemplate>
                        <asp:Button ID="btDelete" runat="server" CommandName="MyDelete" Text="删除" />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
        <asp:Panel ID="Panel1" runat="server" Width="884px">
            <asp:CheckBox ID="cbAll" runat="server" AutoPostBack="true" Text="全选" OnCheckedChanged="cbAll_CheckedChanged"/>
            <asp:CheckBox ID="cbNone" runat="server" AutoPostBack="true"  Text="取消" OnCheckedChanged="cbNone_CheckedChanged" />
            <asp:Button ID="btDel" runat="server" Text="删除" OnClick="btDel_Click" Width="59px" Height="16px" />
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" Height="320px" Width="434px" BorderColor="Black" BorderWidth="2px" CssClass="FloatEnable">
            <span class="add_news">添加新闻</span>             
            <asp:DropDownList ID="ddlClass" runat="server" Width="415px">
                <asp:ListItem Value="1">新闻</asp:ListItem>
                <asp:ListItem Value="2">热点</asp:ListItem>
            </asp:DropDownList>
            <br/>
            <span class="topic">标题:</span><asp:TextBox ID="tbAddTitle" runat="server" OnTextChanged="tbAddTitle_TextChanged" AutoPostBack="true" Width="334px" Height="23px"></asp:TextBox>
            <asp:Button ID="tbAddNews" runat="server" Text="添加" OnClick="tbAddNews_Click" Height="23px" Width="60px" />
            <br/>
            <span class="content">内容:</span><asp:Label ID="lbWarning" runat="server" ForeColor="Red"></asp:Label>
            <br/>
            <asp:TextBox ID="tbAddContent" runat="server" Height="203px" Rows="20" TextMode="MultiLine" Width="420px"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server" Height="320px" Width="428px" BorderColor="Black" BorderWidth="2px" CssClass="FloatEnable" Visible="false">
            <span class="alter_news">修改新闻</span>
            <br />
            <asp:DropDownList ID="ddlClass2" runat="server" Width="395px">
                <asp:ListItem Value="1">新闻</asp:ListItem>
                <asp:ListItem Value="2">热点</asp:ListItem>
            </asp:DropDownList>
            <br/>
            <span class="topic">标题:</span><asp:TextBox ID="tbMdTitle" runat="server" AutoPostBack="true" Width="318px" Height="23px"></asp:TextBox>
            <asp:Button ID="btMd" runat="server" Text="修改" OnClick="btMd_Click" Height="24px" Width="61px" />
            <br/>
            <span class="content">&nbsp;内容:</span><br/>
            <asp:TextBox ID="tbMdContent" runat="server" Height="203px" Rows="20" TextMode="MultiLine" Width="404px"></asp:TextBox>
        </asp:Panel>
    </fieldset>
    </form>
    
</body>
</html>