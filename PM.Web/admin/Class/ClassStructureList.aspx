<%@ Page Title="分类" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true" CodeBehind="ClassStructureList.aspx.cs" Inherits="PM.Web.admin.Class.ClassStructureList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
    <div class="bs-docs-section">
        <div class="page-header">
          <div class="manager_buttons">
        <a href="ClassStructureForm.aspx" class="btn btn-info">新增</a>
        类别名称：
        <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
        组织机构：
              <asp:DropDownList ID="ddlOrgId" runat="server">
              </asp:DropDownList>
        <asp:Button ID="btnQuery" runat="server" CssClass="btn btn-info" Text="查询" />
        <asp:Button ID="btnExport" runat="server" CssClass="btn btn-info" Text="导出" />
        </div>
        </div>
    </div>
    <!-- /toolbar -->

    <div class="row">
    <asp:Repeater ID="rptClassStructure" runat="server">
        <HeaderTemplate>
            <table width="100%" border="0" cellpadding="4" cellspacing="1" class="table table-bordered table-hover table-striped">
                <tr>
                    <th width="20%">
                        分类
                    </th>
                    <th>
                        描述
                    </th>
                    <th>
                        父级分类
                    </th>
                    <th width="10%"></th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%# Eval("Classstructureid")%>
                </td>
                <td>
                    <%# Eval("Description") %>
                </td>
                <td>
                    <%# Eval("PARENT")%>
                </td>
                <td>
                    <a href="ClassStructureForm.aspx?Classstructureuid=<%# Eval("Classstructureuid") %>">编辑</a>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    </div>

</asp:Content>
