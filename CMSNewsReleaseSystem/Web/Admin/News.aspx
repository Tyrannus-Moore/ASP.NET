<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="Maticsoft.Web.Admin.News" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../css/calendar.css" rel="stylesheet" />
    <script src="../Scripts/calendar.js" charset="GBK"></script>
    <script src="../Scripts/calendar-zh.js" charset="GBK"></script>
    <script src="../Scripts/calendar-setup.js" charset="GBK"></script>
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <a href="AddNews.aspx"><b>新增</b></a>

            <asp:GridView ID="GVinfo" runat="server" EnableModelValidation="True" DataKeyNames="Id" AutoGenerateColumns="False" OnRowCommand="GVinfo_RowCommand">
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
                            <asp:LinkButton ID="btOnTop" runat="server" CausesValidation="false" CommandName="MyUp"><%# onTopText(Eval("onTop")) %></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>


            <br />


            <table align="center" cellpadding="1" cellspacing="1" class="TableFooter" width="98%">
                <tr>
                    <td style="text-align: left">
                        <input type="checkbox" id="chkAll" />
                        <asp:DropDownList ID="ddlOper" runat="server">
                            <asp:ListItem>请选择</asp:ListItem>
                            <asp:ListItem Value="del">删除其文章</asp:ListItem>
                            <asp:ListItem Value="move">移动到栏目</asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlColumnId" runat="server"></asp:DropDownList>
                        <asp:Button ID="btExecute" runat="server" OnClick="btExecute_Click" Text="执 行" /></td>
                    <td>
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged" AlwaysShow="True" PageSize="4"></webdiyer:AspNetPager>
                    </td>
                </tr>
            </table>


            <br />


            <table>
                <tr>
                    <td>
                        快速搜索文章：
                        <select id="ddlKeyType" runat="server">
                            <option value="Title">标题</option>
                            <option value="Author">作者</option>
                            <option value="PostDate">时间</option>
                            <option value="Column">栏目</option>
                        </select>
          
                        <asp:TextBox ID="txtKeyWord" runat="server" Width="200px"></asp:TextBox>
                        <asp:Button ID="btSearch" runat="server"  Text="搜 索" onclick="btSearch_Click" />
                        <asp:Button ID="btShowAll" runat="server" OnClick="btShowAll_Click" Text="显示全部" Visible="False" />
                    </td>
                </tr>
            </table>

            
            <br />

            
            <table id="selectTime">
                <tr>
                    <td>
                      开始时间:
                        <input type="text" id="EntTime1" name="EntTime1" onclick="return showCalendar('EntTime1', 'y-mm-dd');" runat="server" />
                    </td>
                    <td>
                       结束时间:
                        <input type="text" id="EntTime2" name="EntTime2" onclick="return showCalendar('EntTime2', 'y-mm-dd');" runat="server" />
                    </td>
                </tr>
            </table>


        </div>
    </form>

        <script src="jquery-1.2.6.js"></script>
        <script type="text/javascript">
        function checkIsTime()//实现选择时间时 将时间选择控件显示 否则隐藏
        {
            if ($("#ddlKeyType").val() == "PostDate") {
                $("#txtKeyWord").attr("disabled", "disabled");
                $("#selectTime").show();
            }
            else
            {
                $("#txtKeyWord").attr("disabled", "");
                $("#selectTime").hide();
            }
        };

        function checkIsZhuanti()//实现根据情况显示或者隐藏栏目 专题选择下拉列表
        {
            if ($("#ddlOper").val() == "add") //默认
            {
                $("#ddlColumnId").hide();
            }
            else if ($("#ddlOper").val() == "move") //选的是移动
            {

                $("#ddlColumnId").show();
            }
            else // 选的是删除
            {
                $("#ddlColumnId").hide();
            }
        };

        $(document).ready(function () {
            checkIsTime();
            checkIsZhuanti();
            $("#ddlKeyType").change(function () {
                checkIsTime();
            });
            $("#ddlOper").change(function () {
                checkIsZhuanti();
            });

            //实现全选或者取消全选
            $("#chkAll").click(function () {
                $("input[name='ArticleId']").attr("checked", $(this).attr("checked"));
            });

            //实现当前行高亮
            $(".delete-link").parent().parent().mouseover(function () {
                $(this).css("backgroundColor", "#cccccc");
            }).mouseout(function () {
                $(this).css("backgroundColor", "");
            });
        });
    </script>



</body>
</html>
