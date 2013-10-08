<%@ Page Title="用户管理" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="PM.Web.admin.users.list" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">

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
            <asp:TemplateField HeaderText="状态">
                <ItemTemplate>
                    
                </ItemTemplate>
                <ItemStyle Width="60px" />
            </asp:TemplateField>
              <asp:TemplateField HeaderText="编辑">
                <ItemTemplate>
                    <a href='edit.aspx?Id=<%# DataBinder.Eval(Container.DataItem, "MEASURETRANSID")%>&PageIndex=<%=PageControl1.CurrentPageIndex %>'
                        title="修改">修改</a>
                </ItemTemplate>
                <ItemStyle Width="60px" />
            </asp:TemplateField>
        </Columns>
        <PagerSettings Visible="False" />
    </asp:GridView>

</asp:Content>
