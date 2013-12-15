<%@ Page Title="资产" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true"
    CodeBehind="AssetList.aspx.cs" Inherits="PM.Web.admin.Asset.AssetList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
    <div class="toolbar bs-callout-info">
        
        <nav id="navbar-example" class="navbar navbar-default navbar-static" role="navigation">
        <div class="collapse navbar-collapse bs-js-navbar-collapse">
          <ul class="nav navbar-nav">
            <li><a href="AssetForm.aspx" class="">新增</a> </li>
            <li class="dropdown">
              <a id="drop1" href="#" role="button" class="dropdown-toggle" data-toggle="dropdown">操作 <b class="caret"></b></a>
              <ul class="dropdown-menu" role="menu" aria-labelledby="drop1">
                <li role="presentation"><a role="menuitem" tabindex="-1" href="http://twitter.com/fat">复制资产</a></li>
                <li role="presentation"><a role="menuitem" tabindex="-1" href="http://twitter.com/fat">删除资产</a></li>
                <li role="presentation"><a role="menuitem" tabindex="-1" href="http://twitter.com/fat">导出数据</a></li>
              </ul>
            </li>
          </ul>
        </div><!-- /.nav-collapse -->
      </nav> <!-- /navbar-example -->
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
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>

</asp:Content>
