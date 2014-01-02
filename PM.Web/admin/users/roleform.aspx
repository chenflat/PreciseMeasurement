<%@ Page Title="编辑用户组" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true"
    CodeBehind="roleform.aspx.cs" Inherits="PM.Web.admin.users.roleform" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
    <ol class="breadcrumb margintop20">
        <li><a href="#"><span class="glyphicon glyphicon-home"></span>系统管理</a></li>
        <li class="active"><a href="roles.aspx">用户组</a></li>
        <li class="active">
            <asp:Literal ID="ltStatus1" runat="server"></asp:Literal></li>
    </ol>
    <div class="bs-docs-section">
        <div class="page-header">
            <h3>
                用户组 /
                <asp:Literal ID="ltStatus" runat="server"></asp:Literal></h3>
            <div class="manager_buttons">
                <asp:Button ID="btnSave" CssClass="btn btn-warning" runat="server" Text="保存" />
                <a href="roles.aspx" class="btn btn-info">返回</a>
            </div>
        </div>
    </div>
    <div class="row col-lg-10">
        <div class="form-group">
           <label for="<%=txtGroupName.ClientID %>">
                组名称：</label>
           
                <asp:TextBox ID="txtGroupName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvGroupName" runat="server" Display="Dynamic" ErrorMessage="必填字段"
                    ControlToValidate="txtGroupName" CssClass="help-inline"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
          <label for="<%=txtDescription.ClientID %>">
                组描述：</label>

                <asp:TextBox ID="txtDescription" runat="server" CssClass="" 
                    Rows="3" TextMode="MultiLine" Columns="50"></asp:TextBox>
            <asp:HiddenField ID="hdnGroupId" runat="server" />
        </div>



           
    </div>
    <div class="row">
           
    </div>
</asp:Content>
