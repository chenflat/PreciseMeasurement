<%@ Page Title="标准参量" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true"
    CodeBehind="list.aspx.cs" Inherits="PM.Web.admin.measureunits.list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">

    <div class="toolbar bs-callout-info">
        标准参量名称：<asp:TextBox ID="description" runat="server"></asp:TextBox>
        <asp:Button ID="btnQuery" runat="server" CssClass="btn btn-primary" Text="查询" />
    </div>
    <asp:Repeater ID="rptMeasureUnits" runat="server">
        <HeaderTemplate>
            <table width="100%" border="0" cellpadding="4" cellspacing="1" class="table table-bordered table-striped">
                <tr>
                    <th width="20%">
                        单位编码
                    </th>
                    <th width="20%">
                        单位名称
                    </th>
                    <th width="20%">
                        单位
                    </th>
                    <th width="20%">
                        显示顺序
                    </th>
                    <th width="20%">
                        编辑
                    </th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%#Eval("MEASUREUNITID")%>
                </td>
                <td>
                    <%#Eval("DESCRIPTION")%>
                </td>
                <td>
                    <%#Eval("ABBREVIATION")%>
                </td>
                <td>
                    <%#Eval("DISPLAYSEQUENCE")%>
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
