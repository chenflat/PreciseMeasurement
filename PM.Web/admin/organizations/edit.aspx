<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true"
    CodeBehind="edit.aspx.cs" Inherits="PM.Web.admin.organizations.edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
    <div class="bs-docs-section">
        <div class="page-header">
            <h3>编辑机构信息</h3>
        </div>
        
        <div class="form-group">
            <label for="<%=orgid.ClientID %>" class="col-lg-2">
                机构代码</label>
            <div class="col-lg-6">
                <asp:TextBox ID="orgid" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                <asp:HiddenField ID="organizationid" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <label for="<%=description.ClientID %>" class="col-lg-2">
                机构名称</label>
            <div class="col-lg-6">
                <asp:TextBox ID="description" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label for="<%=orgtype.ClientID %>" class="col-lg-2">
                机构类型</label>
            <div class="col-lg-6">
                <asp:DropDownList ID="orgtype" runat="server" CssClass="form-control">
                    <asp:ListItem>公司</asp:ListItem>
                    <asp:ListItem>部门</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <label for="<%=parent.ClientID %>" class="col-lg-2">
                上级机构</label>
            <div class="col-lg-6">
                <asp:DropDownList ID="parent" runat="server" CssClass="form-control">
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <label for="<%=leader.ClientID %>" class="col-lg-2">
                负责人</label>
            <div class="col-lg-6">
                <asp:TextBox ID="leader" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
            </div>
        </div>
         <div class="form-group">
            <label for="<%=phone.ClientID %>" class="col-lg-2">
                联系电话</label>
            <div class="col-lg-6">
                <asp:TextBox ID="phone" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label for="<%=address.ClientID %>" class="col-lg-2">
                机构地址</label>
            <div class="col-lg-6">
                <asp:TextBox ID="address" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label for="<%=comments.ClientID %>" class="col-lg-2">
                备注</label>
            <div class="col-lg-6">
                <asp:TextBox ID="comments" CssClass="form-control" placeholder="" 
                    runat="server" Rows="3" TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>

        <div class="toolbar bs-callout-danger">
            <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="提交" />
            <asp:Button ID="btnDelte" CssClass="btn btn-danger" runat="server" Text="删除" />
        </div>
    </div>
</asp:Content>
