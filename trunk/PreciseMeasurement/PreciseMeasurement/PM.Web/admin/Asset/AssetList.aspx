<%@ Page Title="资产" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true"
    CodeBehind="AssetList.aspx.cs" Inherits="PM.Web.admin.Asset.AssetList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
<ol class="breadcrumb margintop20">
  <li><a href="#"><span class="glyphicon glyphicon-home"></span>
  系统管理</a></li>
  <li class="active">资产管理</li>
</ol>
    <div class="bs-docs-section">
        <div class="page-header">
            <h3>
                资产</h3>
            <div class="manager_buttons">
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

                &nbsp;&nbsp;
                <asp:DropDownList ID="ddlFields" runat="server">
                    <asp:ListItem Value="ASSETNUM">编号</asp:ListItem>
                    <asp:ListItem Value="DESCRIPTION">名称</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                &nbsp;子系统：<asp:DropDownList ID="ddlSpecclass" runat="server">
                </asp:DropDownList>
                <asp:Button ID="btnQuery" runat="server" CssClass="btn btn-info" Text="查询" />
                <asp:Button ID="btnExport" runat="server" CssClass="btn btn-info" Text="导出" />
            </div>
        </div>
    </div>
    <!-- /toolbar -->
    <div class="row">
        <asp:Repeater ID="rptAssets" runat="server">
            <HeaderTemplate>
                <table width="100%" border="0" cellpadding="4" cellspacing="1" class="table table-bordered table-hover table-striped">
                    <tr>
                        <th width="15%">
                            资产
                        </th>
                        <th width="35%">
                            描述
                        </th>
                        <th width="10%">
                            父级
                        </th>
                        <th width="10%">
                            类别
                        </th>
                        <th width="10%">
                            地点
                        </th>
                        <th width="10%">
                            状态
                        </th>
                        <th width="10%">
                            
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("ASSETNUM") %>
                    </td>
                    <td><%# Eval("DESCRIPTION") %>
                    </td>
                    <td><%# Eval("PARENT") %>
                    </td>
                     <td><%# Eval("Classstructureid")%>
                    </td>
                    <td><%# Eval("SITEID")%>
                    </td>
                    <td><%# Eval("STATUS") %>
                    </td>
                    <td>
                   <a href="AssetForm.aspx?assetuid=<%# Eval("ASSETUID") %>">编辑</a>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
