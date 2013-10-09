<%@ Page Title="用户管理" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="PM.Web.admin.users.list" %>
<%@ Register src="../../controls/PageControl.ascx" tagname="PageControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
<div class="toolbar bs-callout-danger">
        所属组织：<asp:DropDownList ID="ddlOrgId" runat="server">
    </asp:DropDownList>
    用户名称：<asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        
       
    <asp:Button ID="btnQuery" runat="server" CssClass="btn btn-primary" Text="查询" />
    <asp:Button ID="btnExport" runat="server" CssClass="btn btn-primary" Text="导出" />
    
     <a href="edit.aspx" class="btn btn-primary">新增</a>
    </div>
    <asp:GridView ID="gvUsers" runat="server"  CssClass="table table-striped" 
        AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" CellSpacing="1" 
        EnableModelValidation="True" GridLines="None" PageSize="20">
        <Columns>
            <asp:BoundField DataField="USERNAME" HeaderText="用户名" />
            <asp:BoundField DataField="DISPLAYNAME" HeaderText="显示名称" />
            <asp:BoundField DataField="REALNAME" HeaderText="姓名" />
            <asp:BoundField DataField="SEX" HeaderText="性别" />
            <asp:BoundField DataField="WORKMOBILE" HeaderText="移动电话" />
            <asp:BoundField DataField="LASTLOGINDATE" HeaderText="上次登陆" />
             <asp:BoundField DataField="ORGNAME" HeaderText="公司" />
            <asp:TemplateField HeaderText="状态">
                <ItemTemplate>
                    <%# (Eval("Enabled").ToString()=="True") ? "启用" : "禁用"%>
                </ItemTemplate>
                <ItemStyle Width="60px" />
            </asp:TemplateField>
              <asp:TemplateField HeaderText="编辑">
                <ItemTemplate>
                    <a href='edit.aspx?Id=<%# DataBinder.Eval(Container.DataItem, "USERID")%>&PageIndex=<%=PageControl1.CurrentPageIndex %>'
                        title="修改">修改</a>
                </ItemTemplate>
                <ItemStyle Width="60px" />
            </asp:TemplateField>
        </Columns>
        <PagerSettings Visible="False" />
    </asp:GridView>

    <uc1:PageControl ID="PageControl1" runat="server" />

</asp:Content>
