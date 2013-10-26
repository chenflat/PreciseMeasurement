<%@ Page Title="编辑位置" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true"
    CodeBehind="edit.aspx.cs" Inherits="PM.Web.admin.locations.edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
    <div class="bs-docs-section">
        <div class="page-header">
            <h3>
                编辑位置信息</h3>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=description.ClientID %>" class="col-lg-5 control-label">
                    位置名称*</label>
                <div class="col-lg-7">
                    <asp:TextBox ID="description" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDescription" runat="server" Display="Dynamic"
                        ErrorMessage="必填字段" ControlToValidate="description" CssClass="help-inline" 
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=location.ClientID %>" class="col-lg-5 control-label">
                    位置编号 *</label>
                <div class="col-lg-7">
                    <asp:TextBox ID="location" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                    <asp:HiddenField ID="locationsid" runat="server" />
                    <asp:RequiredFieldValidator ID="rfvPointNum" runat="server" Display="Dynamic" ErrorMessage="必填字段"
                        ControlToValidate="location" CssClass="help-inline" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=txtSiteid.ClientID %>" class="col-lg-5 control-label">
                    地点
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="txtSiteid" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=parent.ClientID %>" class="col-lg-5 control-label">
                    上级位置
                </label>
                <div class="col-lg-7">
                    <asp:DropDownList ID="parent" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=type.ClientID %>" class="col-lg-5 control-label">
                    位置类型
                </label>
                <div class="col-lg-7">
                    <asp:DropDownList ID="type" runat="server" CssClass="form-control">
                        <asp:ListItem Value="OPERATING">操作位置</asp:ListItem>
                        <asp:ListItem Value="HOLDING">保存位置</asp:ListItem>
                        <asp:ListItem Value="REPAIR">维修位置</asp:ListItem>
                        <asp:ListItem Value="SALVAGE">报废位置</asp:ListItem>
                        <asp:ListItem Value="LABOR">人工位置</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=status.ClientID %>" class="col-lg-5 control-label">
                    状态
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="status" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=x.ClientID %>" class="col-lg-5 control-label">
                    X
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="x" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=y.ClientID %>" class="col-lg-5 control-label">
                    Y
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="y" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=z.ClientID %>" class="col-lg-5 control-label">
                    Z
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="z" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=level.ClientID %>" class="col-lg-5 control-label">
                    层级
                </label>
                <div class="col-lg-7">
                    <asp:DropDownList ID="level" runat="server"  CssClass="form-control">
                        <asp:ListItem Value="0">一级</asp:ListItem>
                        <asp:ListItem Value="1">二级</asp:ListItem>
                        <asp:ListItem Value="2">三级</asp:ListItem>
                        <asp:ListItem Value="3">四级</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        </div>
    <div class="toolbar bs-callout-danger">
        <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="提交" />
        <asp:Button ID="btnDelte" CssClass="btn btn-danger" runat="server" Text="删除" />
        <a href="list.aspx" class="btn btn-info">返回</a>
    </div>
</asp:Content>
