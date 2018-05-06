<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="top.ascx.cs" Inherits="Maticsoft.Web.Admin.top" %>
<style type="text/css">
    .td1
    {
    	height: 40px;
    	width: 25%;
    	font-size: 12px;
    }
    .td2
    {
    	width: 12%;
    	height: 40px;
    	font-size: 18px;
    }
</style>
<link href="../css/Style.css" rel="stylesheet" type="text/css" />
<table style="width:100%">
    <tr>
        <td colspan="10">
            <div class="wishTop">
                <div class="titleSystemName">锦城新闻发布系统</div>
                <div class="bglogo">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/logo0.gif" Height="137px" Width="141px" />
                </div>
            </div>
        </td>
    </tr>
    <tr style=" background-image: url(../images/b4_bg.gif)">
        <td class="td2">
            <b style="color: Black; size: 30px" >新闻后台管理中心</b>
        </td>
        <td class="td1">
            <b><asp:Label ID="Label1" runat="server"  Style="color: Black" 
                Font-Size="Larger" ></asp:Label></b>
        </td>
        <td class="td1">
            <asp:LinkButton ID="LinkButton1" runat="server" Style="color: Black" Font-Bold="True" 
                PostBackUrl="Index.aspx" >返回网站首页</asp:LinkButton>
        </td>
    </tr>
</table>
