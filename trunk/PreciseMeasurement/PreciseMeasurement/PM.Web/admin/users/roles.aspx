<%@ Page Title="角色管理" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true"
    CodeBehind="roles.aspx.cs" Inherits="PM.Web.admin.users.roles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">

            <div class="btn-tools">
                <a href="roleform.aspx" class="btn btn-info">新增</a>
                &nbsp;&nbsp;
                <asp:TextBox ID="txtGroupName" runat="server"></asp:TextBox>
                <asp:Button ID="btnQuery" runat="server" CssClass="btn btn-info" Text="查询" />
            </div>

    <asp:Repeater ID="rptGroup" runat="server">
        <HeaderTemplate>
            <table class="table table-hover table-bordered table-condensed">
                <tr>
                    <th  width="30%">
                        用户组
                    </th>
                    <th>
                        描述
                    </th>
                    <td width="10%">
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Eval("Group_Name") %>
                </td>
                <td><%# Eval("DESCRIPTION") %>
                </td>
                <td><a href="roleform.aspx?groupid=<%# Eval("GROUP_ID") %>">修改</a>
                <a href="list.aspx?groupid=<%# Eval("GROUP_ID") %>">列出用户</a>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
