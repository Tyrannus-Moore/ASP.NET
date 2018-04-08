<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml 

">
<head runat="server">
    <style type="text/css">
        *{
    padding:0px;
    margin:29px 0px 0px 0px;
}
#form1{
    width:500px;
    height:300px;
    border-right:10px solid #303A40;
    border-left:10px solid #303A40;
    border-bottom:10px solid #303A40;
    border-top:35px solid #303A40;
    margin:0 auto;
    position:relative;
}
#div1{
    width:500px;
    height:310px;
    border:0px solid gray;
}
.p_input{
    border:0px solid red;
    margin-top:40px;
    padding-top:0px;
    margin-left:50px;
    font-size:16px;
    
}
.label_text{
    display:inline-block;
    border:0px solid yellow;
    width:66px;
    height:38px;
    text-align:right;
    margin-bottom:5px;
    margin-top:1px;
    margin-left:5px;
    line-height:40px;
    font-family:微软雅黑;
    font-size:16px;
    font-weight:lighter;
    position:relative;
    left:-2147483648px;
    top:-2147483648px;
    font-weight:500;
    color:black;
    
}
.input_one{
    display:inline-block;
    margin-top:0px;
    margin-left:5px;
    }
#tbRegister{
    width:100px;
    height:38px;
    margin-top:18px;
    margin-left:120px;
    margin-right:30px;
    border:1px solid gray;
    -moz-border-radius:10px;
    background:rgb(255, 109, 11);
    color:#fff;
    font-size:16px;
    font-family:微软雅黑;
    font-weight:bold;
}
#tbLogin{
    width:100px;
    height:38px;
    margin-top:18px;
    -moz-border-radius:10px;
    background:rgb(255, 109, 11);
    border:1px solid gray;
    color:#fff;
    font-size:16px;
    font-family:微软雅黑;
    font-weight:bold;
}
/*验证码部分*/
#Image1{
    
}
#lbWarningPwd,#lbWarningName,#lbWarningVF{
    display:inline-block;
    padding-bottom:5px;
}
#CompareValidator1{
    display:inline-block;
    height:30px;
    padding-bottom:5px;
}
/*登录页眉*/
#log_on{
    width:200px;
    height:25px;
    border:0px solid red;
    position:absolute;
    top:-56px;
    left:7px;
    color:#fff;
    font-weight:bold;
    font-size:20px;
}
#PanelVF{
    margin-top:20px;
    margin-left:50px;
    padding-left:0px;
}
        </style>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link type="text/css" rel="stylesheet" href="login.css" />
    <script type="text/javascript" src="login.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <p class="p_input">用 户 名:<asp:TextBox ID="tbAdmName" CssClass="input_one" runat="server" Height="28px" Width="249px"></asp:TextBox>
        <asp:Label ID="lbWarningName" runat="server" ForeColor="Red" Height="23px"></asp:Label></p>
        
      <p class="p_input">&nbsp; 密&nbsp; 码:<asp:TextBox ID="tbAdmPwd" CssClass="input_one" runat="server" TextMode="Password" Height="28px" Width="254px"></asp:TextBox>
        <asp:Label ID="lbWarningPwd" runat="server" ForeColor="Red" Height="23px"></asp:Label></p>
        
        
       <asp:Panel cssclass="p_input" ID="PanelVF" runat="server" Visible="false"  Width="324px">
            验 证 码:<asp:TextBox ID="tbVF" CssClass="input_one" runat="server" Height="28px" Width="138px" ></asp:TextBox>            
            <asp:Image ID="Image1" runat="server" imageUrl="VerificationCode.aspx"/>
            <asp:Label ID="lbWarningVF" runat="server" ForeColor="Red" Height="22px" Width="103px"></asp:Label>
            
        </asp:Panel>
        <asp:Button ID="tbRegister" runat="server" Text="注册" OnClick="tbRegister_Click" />
         <asp:Button ID="tbLogin" runat="server" Text="登录" OnClick="tbLogin_Click" />
    
    </div>
         <div id="log_on">欢迎进入登录页面</div>
    </form>
</body>
</html>
