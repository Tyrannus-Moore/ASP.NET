<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForegroundPage.aspx.cs" Inherits="Web.ForegroundPage" %>
<%@ OutputCache Duration="15" VaryByParam="none" Location="Client" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
 <style type="text/css">
        #GVinfo,#GVinfo2,#GVinfo3{
    border:1px solid gray;
    text-align:center;
    font-family:微软雅黑;
    color:gray;
    
}
#Panel1,#Panel2,#Panel3{
    width:800px;
    border:0 solid yellow;
}
#form1{
    width:900px;
    height:100%;
    border:0px solid gray;
    margin:auto;
    
}
#fieldset1{
    height: 779px;
    border:3px solid gray;
}
#legend1{
    text-align:center;
    font-family:微软雅黑;
    font-size:18px;
    font-weight:bold;
    color:gray;
}
#tbRetrieve{
    
}
#tbSub{
    background:lightblue;
    color:#fff;
    font-weight:bold;
    font-size:16px;
}
        </style>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
 
    <link type="text/css" href="ForegroundPage.css" rel="stylesheet"/>
</head>
<body style="height: 782px">
    <form id="form1" runat="server">
        <fieldset id="fieldset1">
        <legend id="legend1">新闻列表</legend>
        <asp:Panel ID="Panel1" runat="server">
          <asp:GridView ID="GVinfo" runat="server" AutoGenerateColumns="False" ShowHeader="False" Width="873px" Height="244px">
            <Columns>
                <asp:HyperLinkField DataTextField="标题" HeaderText="标题" NavigateUrl="标题" DataNavigateUrlFormatString="DetailsPage.aspx?标题={0}" DataNavigateUrlFields="标题" />
                <asp:BoundField DataField="时间" />
            </Columns>
          </asp:GridView>
        </asp:Panel>

        <asp:Panel ID="Panel2" runat="server">
            <asp:GridView ID="GVinfo2" runat="server" AutoGenerateColumns="False" style="margin-top: 8px" Width="869px" Height="184px">
                <Columns>
                    <asp:HyperLinkField DataNavigateUrlFields="标题" DataNavigateUrlFormatString="DetailsPage.aspx?标题={0}" DataTextField="标题" HeaderText="标题" NavigateUrl="标题" />
                    <asp:TemplateField HeaderText="内容">
                        <ItemTemplate>
                            <%# Eval("内容").ToString().Length > 10 ?  Eval("内容").ToString().Substring(0, 10) + "..." : Eval("内容").ToString() %>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:Panel>

        <asp:Panel ID="Panel3" runat="server" ForeColor="#0066FF">
            你感兴趣的:<asp:DropDownList ID="ddlKind" runat="server" AutoPostBack="true" Height="22px" Width="389px">
                <asp:ListItem Value="newsTitle">标题</asp:ListItem>
                <asp:ListItem Value="newsContent">内容</asp:ListItem>
                <asp:ListItem Value="pubTime">发布时间</asp:ListItem>
                <asp:ListItem Value="publisher">发布者</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="tbRetrieve" runat="server" Height="16px" Width="398px"></asp:TextBox>
            <asp:Button ID="tbSub" runat="server" Text="确定" OnClick="tbSub_Click" Height="21px" Width="97px" />
        </asp:Panel>
      </fieldset>
    </form></body>
</html>
