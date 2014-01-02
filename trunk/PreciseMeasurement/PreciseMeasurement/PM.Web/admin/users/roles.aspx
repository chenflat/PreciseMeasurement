<%@ Page Title="角色管理" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true"
    CodeBehind="roles.aspx.cs" Inherits="PM.Web.admin.users.roles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
    <ol class="breadcrumb margintop20">
        <li><a href="#"><span class="glyphicon glyphicon-home"></span>系统管理</a></li>
        <li class="active">用户组</li>
    </ol>
    <div class="bs-docs-section">
        <div class="page-header">
            <h3>
                资产</h3>
            <div class="manager_buttons">
                <a href="AssetForm.aspx" class="btn btn-info">新增</a>
                &nbsp;&nbsp;
                <asp:TextBox ID="txtGroupName" runat="server"></asp:TextBox>
                <asp:Button ID="btnQuery" runat="server" CssClass="btn btn-info" Text="查询" />
            </div>
        </div>
    </div>
    <asp:Repeater ID="rptGroup" runat="server">
        <HeaderTemplate>
            <table class="table table-hover table-bordered table-condensed">
                <tr>
                    <th>
                        用户组
                    </th>
                    <th>
                        描述
                    </th>
                    <td>
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
