<%@ Page Title="计量点管理" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true"
    CodeBehind="edit.aspx.cs" Inherits="PM.Web.admin.measurepoints.edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
    <div class="bs-docs-section">
        <div class="page-header">
            <h3>
                编辑计量点</h3>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=orgid.ClientID %>" class="col-lg-5 control-label">
                    测点编号 *</label>
                <div class="col-lg-7">
                    <asp:TextBox ID="orgid" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                    <asp:HiddenField ID="organizationid" runat="server" />
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=description.ClientID %>" class="col-lg-5 control-label">
                    测点简拼</label>
                <div class="col-lg-7">
                    <asp:TextBox ID="description" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=description.ClientID %>" class="col-lg-5 control-label">
                    测点名称*</label>
                <div class="col-lg-7">
                    <asp:TextBox ID="TextBox1" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=orgid.ClientID %>" class="col-lg-5 control-label">
                    携能载体
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="TextBox2" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=orgid.ClientID %>" class="col-lg-5 control-label">
                    负责人
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="TextBox3" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=orgid.ClientID %>" class="col-lg-5 control-label">
                    联系方式
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="TextBox4" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=orgid.ClientID %>" class="col-lg-5 control-label">
                    所属公司
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="TextBox5" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=orgid.ClientID %>" class="col-lg-5 control-label">
                    安装位置
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="TextBox6" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=orgid.ClientID %>" class="col-lg-5 control-label">
                    计量点IP
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="TextBox7" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=orgid.ClientID %>" class="col-lg-5 control-label">
                    3G卡号
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="TextBox8" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=orgid.ClientID %>" class="col-lg-5 control-label">
                    通讯设备号码
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="TextBox9" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=orgid.ClientID %>" class="col-lg-5 control-label">
                    通讯服务器IP
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="TextBox10" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=orgid.ClientID %>" class="col-lg-5 control-label">
                    服务器Port
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="TextBox11" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=orgid.ClientID %>" class="col-lg-5 control-label">
                    计量点排序
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="TextBox12" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
     <div class="toolbar bs-callout-danger">
            <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="提交" />
            <asp:Button ID="btnDelte" CssClass="btn btn-danger" runat="server" Text="删除" />
        </div>
</asp:Content>
