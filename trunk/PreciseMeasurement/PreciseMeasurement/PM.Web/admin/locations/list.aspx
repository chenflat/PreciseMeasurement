<%@ Page Title="位置设置" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true"
    CodeBehind="list.aspx.cs" Inherits="PM.Web.admin.locations.list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
    <div class="toolbar bs-callout-info">
        位置查询：<asp:DropDownList ID="ddlCarrier" runat="server">
            <asp:ListItem Value="DESCRIPTION">名称</asp:ListItem>
            <asp:ListItem Value="LOCATION">编码</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
        <asp:Button ID="btnQuery" runat="server" CssClass="btn btn-primary" Text="查询" />
        <asp:Button ID="btnExport" runat="server" CssClass="btn btn-primary" Text="导出" />
        <a href="edit.aspx" class="btn btn-primary">新增</a>
    </div>
    <asp:Repeater ID="rptLocations" runat="server">
        <HeaderTemplate>
            <table width="100%" border="0" cellpadding="4" cellspacing="1" class="table table-striped">
                <tr>
                    <th width="10%">
                        位置编号
                    </th>
                    <th>
                        位置名称
                    </th>
                     <th>
                        上级位置
                    </th>
                    <th width="10%">
                        位置类型
                    </th>
                     <th width="10%">
                        层级
                    </th>
                    <th width="10%">
                        位置状态
                    </th>
                    <th width="10%">
                        编辑
                    </th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%#Eval("LOCATION")%>
                </td>
                <td>
                    <%#Eval("DESCRIPTION")%>
                </td>
                <td>
                    <%#Eval("PARENT")%>
                </td>
                <td>
                    <%#Eval("TYPE")%>
                </td>
                 <td>
                    <%#Eval("LEVEL")%>
                </td>
                <td>
                    <%#Eval("STATUS")%>
                </td>
                <td>
                    <a href="edit.aspx?id=<%#Eval("LOCATIONSID") %>">编辑</a>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
        </asp:Repeater>

</asp:Content>
