<%@ Page Title="换表管理" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true"
    CodeBehind="list.aspx.cs" Inherits="PM.Web.admin.measurereplace.list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
    <div class="toolbar bs-callout-danger">
    起始时间：<asp:TextBox ID="startdate" runat="server" Width="80px"></asp:TextBox>
    终止时间：<asp:TextBox ID="enddate" runat="server" Width="80px"></asp:TextBox>
    级别：<asp:DropDownList ID="level" runat="server">
            <asp:ListItem Value="1">一级</asp:ListItem>
            <asp:ListItem Value="2">二级</asp:ListItem>
        </asp:DropDownList>
    计量点名称:<asp:TextBox ID="pointnum" runat="server"></asp:TextBox>
    记录状态：<asp:DropDownList ID="status" runat="server">
            <asp:ListItem Value="realtime">实时</asp:ListItem>
        </asp:DropDownList>

        <asp:Button ID="btnQuery" class="btn btn-info" runat="server" Text="查询" />
        <asp:Button ID="btnExport" class="btn btn-info" runat="server" Text="导出Excel" />
        <a href="edit.aspx" class="btn btn-info">新增</a>
    </div>

    <asp:Repeater ID="rptMeasureReplace" runat="server">
        <HeaderTemplate>
            <table width="100%" border="0" cellpadding="4" cellspacing="1" class="table table-striped">
                <tr>
                    <th>
                        计量点名
                    </th>
                    <th >
                        参数名
                    </th>
                    <th >
                        换表前读数
                    </th>
                    <th>
                        新表读数
                    </th>
                    <th>
                        修正值
                    </th>
                    <th>
                        换表人
                    </th>
                    <th>
                        换表时间
                    </th>
                    <th>
                        记录人
                    </th>
                    <th>
                        记录时间
                    </th>
                    <th>
                        编辑
                    </th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%#Eval("POINTNUM")%>
                </td>
                <td>
                    <%#Eval("DESCRIPTION")%>
                </td>
                <td>
                    <%#Eval("MEASUREMENTVALUE")%>
                </td>
                <td>
                    <%#Eval("TOMEASUREMENTVALUE")%>
                </td>
                <td>
                    <%#Eval("ENTERBY")%>
                </td>
                <td>
                    <%#Eval("REPLACEPERSON")%>
                </td>
                  <td>
                    <%#Eval("REPLACEDATE")%>
                </td>
                <td>
                    <%#Eval("ENTERBY")%>
                </td>
                  <td>
                    <%#Eval("ENTERDATE")%>
                </td>
                <td>
                    <a href="edit.aspx?id=<%#Eval("MEASUREUNITUID") %>">编辑</a>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>

</asp:Content>
