<%@ Page Title="资产" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true"
    CodeBehind="AssetList.aspx.cs" Inherits="PM.Web.admin.Asset.AssetList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
    <div class="toolbar bs-callout-info">
        <a href="AssetForm.aspx" class="btn btn-info">新增</a>
        <div class="btn-group">
            <button class="btn btn-info dropdown-toggle" data-toggle="dropdown">
                操作 <span class="caret"></span>
            </button>
            <ul class="dropdown-menu">
                <li><a href="#">复制资产</a></li>
                <li><a href="#">删除资产</a></li>
            </ul>
        </div>
        <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
            <asp:Button ID="btnQuery" runat="server" CssClass="btn btn-info" Text="查询" />
         <asp:Button ID="btnExport" runat="server" CssClass="btn btn-info" Text="导出" />
    </div>
    <!-- /toolbar -->
    <asp:Repeater ID="rptAssets" runat="server">
        <HeaderTemplate>
            <table width="100%" border="0" cellpadding="4" cellspacing="1" class="table table-striped">
                <tr>
                    <th width="15%">
                        资产
                    </th>
                    <th width="35%">
                        描述
                    </th>
                    <th width="15%">
                        父级
                    </th>
                    <th width="25%">
                        地点
                    </th>
                    <th width="10%">
                        状态
                    </th>
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
