<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRole.aspx.cs" Inherits="Maticsoft.Web.Admin.AddRole" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td>
                    用户名:
                    <asp:TextBox ID="tbTitle" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    系统权限:<br/>
                    <input type="checkbox" id="ckAllAdminSetting" />全选
                </td>
                <td>
                    <asp:Literal ID="ltAdminSetting" runat="server" EnableViewState="false"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td>
                    栏目权限:
                    <input type="checkbox" id="ckAllSetting" />全选
                </td>
                <td>
                    <asp:Literal ID="ltSetting" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btSave" runat="server" Text="保存" OnClick="btSave_Click" />
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="hfSetting" runat="server" EnableViewState="false" />
    </form>
        <script src="jquery-1.2.6.js"></script>
        <script src="../Scripts/jquery-1.2.6.js"></script>
        <script type="text/javascript">
            $(function () {
                //$("form").validate({
                //    rules: {
                //        tbTitle: {
                //            required: true,
                //            rangelength: [1, 30]
                //        }
                //    },
                //    messages: {
                //        tbTitle: {
                //            required: "名称不能为空",
                //            rangelength: jQuery.format("名称长度不在{0}-{1}范围内")
                //        }
                //    }
                //});

                $("input[name='setting']").click(function () {
                    if ($("#303").attr("checked") == false) {
                        alert("请先勾选以上的新闻管理，否则此处设置无效！");
                    }
                }
                );

                $("#ckAllAdminSetting").click(function () {
                    $("input[name='admin_setting']").attr("checked", $(this).attr("checked"));
                });

                $("#ckAllSetting").click(function () {
                    $("input[name='setting']").attr("checked", $(this).attr("checked"));
                });

                var setting = $("#hfSetting").val();
                $("input").each(function () {
                    var val = $(this).val();
                    if (setting.indexOf(val) > -1)
                        $(this).attr("checked", true);
                });
            });
    </script>
</body>
</html>
