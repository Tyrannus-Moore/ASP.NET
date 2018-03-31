<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DetailsPage.aspx.cs" Inherits="DetailsPage" Theme="White"%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">
        *{  padding-top:25px;
    margin:0px;
    padding:0px;
}
#form1{
    margin-top:25px;
    width:800px;
    height:400px;
    margin:auto;
    border:1px solid lightgrey;
}
#lbTitle{
    display:inline-block;
    margin:auto;
    text-align:center;
    line-height:30px;
    color:black;
    font-family:微软雅黑;
    font-size:18px;
}
#Panel1{
    border:1px solid lightgrey;
    height:30px !important;
}
#Panel2{
    width:800px;
    height:400px;
}
#lbContent{
    text-indent:20px;
    display:inline-block;
    color:grey;
    text-align:left;
    letter-spacing:2px;
    margin-top:15px;
    padding-top:15px;
    margin-left:5px auto;
    margin-right: auto;
    margin-bottom: auto;
    color:gray;
}
#Panel3{
    width:800px;
    height:200px;
    border:1px solid gray;
    color:gray;
    margin-top:10px;
    position:relative;
    top:-10px;
    left:0;
}
.text_span{
    color:gray;
}
#lbPublisher,#lbPubTime,#lbReadTimes{
    color:gray;
    margin-left:15px;
}
.span2{
    color:gray;
}

        </style>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link type="text/css" rel="stylesheet" href="DetailsPage.css" />
</head>
<body style="height: 405px">
    <form id="form1" runat="server">
        <asp:Panel ID="Panel1" runat="server" Height="35px" HorizontalAlign="Center">
            <asp:Label ID="lbTitle" runat="server" Text="Label" Height="30px" Width="678px"></asp:Label><br/>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" Height="253px" >
            <asp:Label ID="lbContent" runat="server" Text="Label" Height="236px" Width="794px"></asp:Label>
        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server" Height="110px">
            <span class="text_span">责任编辑:</span><asp:Label ID="lbPublisher" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <span class="text_span">发布时间:</span><asp:Label ID="lbPubTime" runat="server" Text="Label"></asp:Label>
            <br />
            <br/>
            <span class="text_span">阅读次数:</span><asp:Label ID="lbReadTimes" runat="server" Text="Label"></asp:Label><span class="span2">次</span>
        </asp:Panel>
            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true" Height="20px">
                <asp:ListItem Value="Yellow">护眼黄</asp:ListItem>
                <asp:ListItem Value="Blue">天空蓝</asp:ListItem>
                <asp:ListItem Value="Green">大地绿</asp:ListItem>
                <asp:ListItem Value="White">纯洁白</asp:ListItem>
            </asp:DropDownList>
    </form>
</body>
</html>
