<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Web.Register1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <script type="text/javascript">
         function changeCode() {
             document.getElementById('ibtn_yzm').src = document.getElementById('ibtn_yzm').src + '?';
         }
</script>
 <style type="text/css">
        *{
    padding:0px;
    margin:0px;
}
#form1{
    width:500px;
    height:400px;
    border-right:10px solid #303A40;
    border-left:10px solid #303A40;
    border-bottom:10px solid #303A40;
    border-top:35px solid #303A40;
    margin:0 auto;
    position:relative;
}
#div1{
    width:500px;
    height:400px;
    border:0px solid gray;
}
.p_input{
    width:457px;
    height:40px;
    border:0px solid red;
    margin-top:40px;
    padding-top:0px;
    margin-left:30px;
    font-size:16px;
    
}
.label_text{
    display:inline-block;
    border:0px solid yellow;
    width:70px;
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
    left:0;
    top:-5px;
    font-weight:500;
    color:black;
    
}
.input_one{
    display:inline-block;
    margin-top:2px;
    height:36px;
    margin-left:5px;
    width:250px;
    border:1px solid lightgray;
    }
#btRegister{
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
    position:relative;
    left:0px;
    top:-30px;
}
#btLogin{
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
     position:relative;
    left:0px;
    top:-30px;
}
/*验证码部分*/
#Image1{
    
}
#lbWarning2,#lbWarning{
    display:inline-block;
    height:30px;
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
    top:-30px;
    left:10px;
    color:#fff;
    font-weight:bold;
    font-size:20px;
}
#lbWarning {
    color:red;
}
#tbAdmName{
    position:relative;
    left:110px;
    top:-55px;
}
.no_first{
position:relative;
    left:0px;
    top:-55px;
}
        </style>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<%--    <script type="javascript">
        var xmlHttp;
        function createXMLHttpRequest(){
        if(window.ActiveXObject) xmlHttp=new ActiveXObject("Microsoft.XMLHTTP");
        else if(window.XMLHttpRequest)xmlHttp = new XMLHttpRequest();
        }

        function startRequest(){
           createXMLHttpRequest();
            xmlHttp.open("GET","demo1.aspx",true);
            xmlHttp.onreadystatechange=myCall;
            xmlHttp.send(null);
        }

        function myCall()
        {
        if(xmlHttp.readState == 4&& xmlHttp.status==200)
        document.getElementById("target").innerHTML =xmlHttp.responseText;
        }
    </script>--%>
    <link type="text/css" rel="stylesheet" href="register.css"/>
    <script type="text/javascript" src="jquery-3.2.0.min.js"></script>
    <script type="text/javascript" src="register.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="div1">
        <p class="p_input"><span class="label_text">用 户 名:</span>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                 <asp:TextBox CssClass="input_one" ID="tbAdmName" runat="server"  AutoPostBack="true" OnTextChanged="useJSAjax"></asp:TextBox><asp:Label ID="lbWarning" runat="server" Text=""></asp:Label>
            </ContentTemplate>
</asp:UpdatePanel></p>
        <p class="p_input no_first"><span class="label_text">密&nbsp;&nbsp;&nbsp;&nbsp; 码:</span><asp:TextBox CssClass="input_one" ID="tbAdmPwd" runat="server" TextMode="Password"></asp:TextBox></p>
        
        <p class="p_input no_first"><span class="label_text" id="span3">确认密码:</span><asp:TextBox CssClass="input_one" ID="tbAdmPwdCfm" runat="server" TextMode="Password" ></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="两次密码不一致" ControlToValidate="tbAdmPwdCfm" ControlToCompare="tbAdmPwd" Operator="Equal"></asp:CompareValidator></p>
       
        <p class="p_input no_first"><span class="label_text">验&nbsp; 证 码:</span><asp:TextBox ID="tbx_yzm" runat="server" Width="70px"></asp:TextBox>
<asp:ImageButton ID="ibtn_yzm" runat="server" />
<a href="javascript:changeCode()"style="text-decoration: underline; font-size:10px;">换一张</a></p>
        
        <asp:Button ID="btRegister" runat="server" Text="注册" OnClick="btRegister_Click"  />
        <asp:Button ID="btLogin" runat="server" Text="登录" OnClick="btLogin_Click" />
    </div>
        <div id="log_on">欢迎进入注册页面</div>
    </form>
</body>
</html>
