<%@ Page Title="组织机构" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true"
    CodeBehind="list.aspx.cs" Inherits="PM.Web.admin.organizations.list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
<link rel="stylesheet" href="<%=ResolveUrl("~/assets/lib/treegrid/css/jquery.treegrid.css") %>">
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/lib/treegrid/js/jquery.treegrid.js") %>"></script>
        <div class="toolbar bs-callout-danger">
                <a href="edit.aspx" class="btn btn-primary">新增</a>
        </div>
    <asp:Repeater ID="rptOrganizations" runat="server">
    <HeaderTemplate>
    <table width="100%" border="0" id="organizationtable" cellpadding="4" cellspacing="1" class="table table-striped">
           <thead>
            <tr>
                <th width="20%">
                    机构名称
                </th>
                <th width="20%">
                    类型
                </th>
                <th width="20%">
                    层级
                </th>
                <th width="20%">
                    备注
                </th>
                <th width="20%">
                    编辑
                </th>
            </tr>
            </thead> 
            <tbody>
    </HeaderTemplate>
    <ItemTemplate>
         
        <tr class="treegrid-<%# Eval("ORGID")%> <%# (Eval("Parent").ToString()=="") ? "" : "treegrid-parent-"+ Eval("Parent") %>" >
            <td><%# Eval("Description")%></td>
            <td><%# Eval("Orgtype")%></td>
            <td><%# Eval("Level")%></td>
            <td><%# Eval("Comments")%></td>
            <td><a href="edit.aspx?id=<%# Eval("Organizationid") %>">编辑</a></td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
    </tbody>
    </table>
    </FooterTemplate>
    </asp:Repeater>
        <script type="text/javascript">
            $(document).ready(function () {
                $('#organizationtable').treegrid();
            });
    </script>
</asp:Content>
