<%@ Page Title="登录" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="PM.Web.Account.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        登录
    </h2>
    <p>
        请输入用户名和密码。
        <asp:HyperLink ID="RegisterHyperLink" runat="server" EnableViewState="false">注册</asp:HyperLink>
        如果您没有帐户。
    </p>
    <span class="failureNotification">
        <asp:Literal ID="FailureText" runat="server"></asp:Literal>
    </span>
    <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification"
        ValidationGroup="LoginUserValidationGroup" />
    <div class="form-group">
        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" CssClass="col-lg-2 control-label">用户名:</asp:Label>
        <div class="col-lg-2">
            <asp:TextBox ID="UserName" runat="server" CssClass="form-control" placeholder="用户名"></asp:TextBox>
            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                CssClass="failureNotification" ErrorMessage="必须填写“用户名”。" ToolTip="必须填写“用户名”。"
                ValidationGroup="LoginUserValidationGroup" Display="Dynamic">*</asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group">
        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" CssClass="col-lg-2 control-label">密码:</asp:Label>
        <div class="col-lg-2">
            <asp:TextBox ID="Password" runat="server" CssClass="form-control" TextMode="Password"
                placeholder="密码"></asp:TextBox>
            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                CssClass="failureNotification" placeholder="Password" 
                ErrorMessage="必须填写“密码”。" ToolTip="必须填写“密码”。"
                ValidationGroup="LoginUserValidationGroup" Display="Dynamic">*</asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group">
        <div class="col-lg-offset-2 col-lg-10">
            <asp:Button ID="LoginButton" runat="server" CssClass="btn btn-default" CommandName="Login"
                Text="登录" ValidationGroup="LoginUserValidationGroup" />
        </div>
    </div>
</asp:Content>
