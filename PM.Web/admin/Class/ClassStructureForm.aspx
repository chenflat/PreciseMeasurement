<%@ Page Title="编辑资产类别" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true" CodeBehind="ClassStructureForm.aspx.cs" Inherits="PM.Web.admin.Class.ClassStructureForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
<div class="bs-docs-section">
        <div class="page-header">
            <h3> 分类 / 新增</h3>
            <div class="manager_buttons">
            <asp:Button ID="btnSave" CssClass="btn btn-warning" runat="server" Text="保存" />
             <a href="ClassStructureList.aspx" class="btn btn-info">返回</a>
            </div>
        </div>
    </div>
      <div class="row">
        <div class="col-md-6">
            <div class="form-group">
                <label for="<%=txtGroupName.ClientID %>" class="col-lg-4 control-label">
                    分类：*</label>
                <div class="col-lg-8">
                    <div class="col-lg-6">
                    <asp:TextBox ID="txtGroupName" CssClass="form-control col-lg-6" placeholder="编号"
                        runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-6">
                    <asp:TextBox ID="txtDescription" CssClass="form-control col-lg-6 description"
                        placeholder="描述" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvGroupName" runat="server" Display="Dynamic" ErrorMessage="必填字段"
                        ControlToValidate="txtGroupName" CssClass="help-inline"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="rfvDescrption" runat="server" Display="Dynamic" ErrorMessage="必填字段"
                        ControlToValidate="txtDescription" CssClass="help-inline"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <label for="<%=ddlOrgId.ClientID %>" class="col-lg-4 text-right">
                    组织：</label>
                <div class="col-lg-8  text-left">
                    <asp:DropDownList ID="ddlOrgId" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <ul class="nav nav-tabs" id="myTab">
            <li class="active"><a href="#home" data-toggle="tab">子级</a></li>
            <li class=""><a href="#attribute" data-toggle="tab">属性</a></li>
        </ul>
        <!-- Tab panes -->
        <div class="tab-content">
            <div class="tab-pane active" id="home"></div>
            <div class="tab-pane active" id="attribute"></div>
        </div>
    </div>
     <script>
         $('#myTab a').click(function (e) {
             e.preventDefault()
             $(this).tab('show')
         })
    </script>
</asp:Content>
