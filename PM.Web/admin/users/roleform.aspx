<%@ Page Title="编辑用户组" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true"
    CodeBehind="roleform.aspx.cs" Inherits="PM.Web.admin.users.roleform" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
<section class="panel panel-default">
<header class="panel-heading font-bold">
<asp:Literal ID="ltStatus" runat="server"></asp:Literal>用户组
</header>
<div class="panel-body">
<div class="row col-lg-10">
        <div class="form-group">
           <label for="<%=txtGroupName.ClientID %>">
                组名称：</label>
           
                <asp:TextBox ID="txtGroupName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvGroupName" runat="server" Display="Dynamic" ErrorMessage="必填字段"
                    ControlToValidate="txtGroupName" CssClass="help-inline"></asp:RequiredFieldValidator>  *
        </div>
        <div class="form-group">
          <label for="<%=txtDescription.ClientID %>">
                组描述：</label>

                <asp:TextBox ID="txtDescription" runat="server" CssClass="" 
                    Rows="3" TextMode="MultiLine" Columns="50"></asp:TextBox>
            <asp:HiddenField ID="hdnGroupId" runat="server" />
        </div>
        <div class="form-group">
            <div class=" col-lg-10 col-lg-offset-1">
                        <asp:Button ID="btnSave" CssClass="btn btn-warning" runat="server" Text="保存" />
                <a href="roles.aspx" class="btn btn-info">返回</a>
                </div>
        </div>
 
    </div>
       


</div>
</section>



                
  

</asp:Content>
