<%@ Page Title="编辑用户信息" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true"
    CodeBehind="edit.aspx.cs" Inherits="PM.Web.admin.users.edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
    <div class="bs-docs-section">
        <div class="page-header">
            <h3>
                编辑用户信息</h3>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=txtUserName.ClientID %>" class="col-lg-5 control-label">
                    用户名*</label>
                <div class="col-lg-7">
                    <asp:TextBox ID="txtUserName" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvUserName" runat="server" Display="Dynamic" ErrorMessage="必填字段"
                        ControlToValidate="txtUserName" CssClass="help-inline"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=txtRealname.ClientID %>" class="col-lg-5 control-label">
                    真实姓名
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="txtRealname" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=txtDisplayname.ClientID %>" class="col-lg-5 control-label">
                    显示名称
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="txtDisplayname" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=txtPassWord.ClientID %>" class="col-lg-5 control-label">
                    密码*
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="txtPassWord" CssClass="form-control" placeholder="" runat="server"
                        TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPassWord" runat="server" Display="Dynamic" ErrorMessage="必填字段"
                        ControlToValidate="txtPassWord" CssClass="help-inline"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=txtConfirmPwd.ClientID %>" class="col-lg-5 control-label">
                    确认密码*
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="txtConfirmPwd" CssClass="form-control" placeholder="" runat="server"
                        TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvConfirmPwd" runat="server" ControlToValidate="txtConfirmPwd"
                        Display="Dynamic" ErrorMessage="必填字段" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvConfirmPwd" runat="server" ErrorMessage="密码不一致" ControlToCompare="txtPassWord"
                        ControlToValidate="txtConfirmPwd" Display="Dynamic" SetFocusOnError="True"></asp:CompareValidator>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=ddlPasswordEncrypted.ClientID %>" class="col-lg-5 control-label">
                    加密方式
                </label>
                <div class="col-lg-7">
                    <asp:DropDownList ID="ddlPasswordEncrypted" CssClass="form-control" runat="server">
                        <asp:ListItem Value="md5">MD5</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=txtReminderQueryQuestion.ClientID %>" class="col-lg-5 control-label">
                    密码问题
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="txtReminderQueryQuestion" CssClass="form-control" placeholder=""
                        runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=txtReminderQueryAnswer.ClientID %>" class="col-lg-5 control-label">
                    密码答案
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="txtReminderQueryAnswer" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=ddlOrgId.ClientID %>" class="col-lg-5 control-label">
                    组织机构
                </label>
                <div class="col-lg-7">
                    <asp:DropDownList ID="ddlOrgId" CssClass="form-control" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=txtJobtitle.ClientID %>" class="col-lg-5 control-label">
                    工作头衔
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="txtJobtitle" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=txtWebsite.ClientID %>" class="col-lg-5 control-label">
                    网站地址
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="txtWebsite" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=txtEmailAddress.ClientID %>" class="col-lg-5 control-label">
                    电子邮件
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="txtEmailAddress" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=txtWorkPhone.ClientID %>" class="col-lg-5 control-label">
                    工作电话
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="txtWorkPhone" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=txtWorkMobile.ClientID %>" class="col-lg-5 control-label">
                    工作手机
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="txtWorkMobile" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=txtPhone.ClientID %>" class="col-lg-5 control-label">
                    联系电话
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="txtPhone" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=txtMobile.ClientID %>" class="col-lg-5 control-label">
                    联系手机
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="txtMobile" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=rbSex.ClientID %>" class="col-lg-5 control-label">
                    性别
                </label>
                <div class="col-lg-7">
                    <asp:RadioButtonList ID="rbSex" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Selected="True" Value="male">男</asp:ListItem>
                        <asp:ListItem Value="female">女</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=txtBirthday.ClientID %>" class="col-lg-5 control-label">
                    生日
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="txtBirthday" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=txtAnniversary.ClientID %>" class="col-lg-5 control-label">
                    纪念日
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="txtAnniversary" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=txtGreeting.ClientID %>" class="col-lg-5 control-label">
                    问候语
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="txtGreeting" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=txtDigest.ClientID %>" class="col-lg-5 control-label">
                    用户摘要
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="txtDigest" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=txtComments.ClientID %>" class="col-lg-5 control-label">
                    备注
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="txtComments" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="col-lg-offset-5 col-lg-7">
                <div class="checkbox">
                    <label>
                        <asp:CheckBox ID="chkEnabled" runat="server" />
                        是否可用
                    </label>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=txtPasswordModifiedDate.ClientID %>" class="col-lg-5 control-label">
                    最后更改密码日期
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="txtPasswordModifiedDate" CssClass="form-control" 
                        placeholder="" runat="server" ReadOnly="True"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=txtCreatedDate.ClientID %>" class="col-lg-5 control-label">
                    创建日期
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="txtCreatedDate" CssClass="form-control" 
                        placeholder="" runat="server" ReadOnly="True"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="<%=txtModifiedDate.ClientID %>" class="col-lg-5 control-label">
                    最后修改日期
                </label>
                <div class="col-lg-7">
                    <asp:TextBox ID="txtModifiedDate" CssClass="form-control" 
                        placeholder="" runat="server" ReadOnly="True"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <div class="toolbar bs-callout-danger">
        <asp:HiddenField ID="hdnUserId" runat="server" />
        <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="提交" />
        <asp:Button ID="btnDelte" CssClass="btn btn-danger" runat="server" Text="删除" Visible="false" />
        <a href="list.aspx" class="btn btn-info">返回</a>
    </div>
</asp:Content>
