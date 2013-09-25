<%@ Page Title="更改密码" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="ChangePassword.aspx.cs" Inherits="PM.Web.Account.ChangePassword" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
 
    <h2>
        更改密码
    </h2>
    <p>
        请使用以下表单更改密码。
    </p>
    <p>
        新密码的长度至少必须为
        <%= Membership.MinRequiredPasswordLength %>
        个字符。
    </p>
    <asp:ChangePassword ID="ChangeUserPassword" runat="server" CancelDestinationPageUrl="~/"
        EnableViewState="false" RenderOuterTable="false" SuccessPageUrl="ChangePasswordSuccess.aspx">
        <ChangePasswordTemplate>
            <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
            <asp:ValidationSummary ID="ChangeUserPasswordValidationSummary" runat="server" CssClass="failureNotification"
                ValidationGroup="ChangeUserPasswordValidationGroup" />
            <div class="accountInfo">
                <fieldset class="changePassword">
                    <legend>帐户信息</legend>
                    <p>
                        <asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword">旧密码:</asp:Label>
                        <asp:TextBox ID="CurrentPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword"
                            CssClass="failureNotification" ErrorMessage="必须填写“密码”。" ToolTip="必须填写“旧密码”。"
                            ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword">新密码:</asp:Label>
                        <asp:TextBox ID="NewPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
                            CssClass="failureNotification" ErrorMessage="必须填写“新密码”。" ToolTip="必须填写“新密码”。"
                            ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword">确认新密码:</asp:Label>
                        <asp:TextBox ID="ConfirmNewPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword"
                            CssClass="failureNotification" Display="Dynamic" ErrorMessage="必须填写“确认新密码”。"
                            ToolTip="必须填写“确认新密码”。" ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword"
                            ControlToValidate="ConfirmNewPassword" CssClass="failureNotification" Display="Dynamic"
                            ErrorMessage="“确认新密码”与“新密码”项必须匹配。" ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:CompareValidator>
                    </p>
                </fieldset>
                <p class="submitButton">
                    <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" CommandName="Cancel"
                        Text="取消" />
                    <asp:Button ID="ChangePasswordPushButton" runat="server" CommandName="ChangePassword"
                        Text="更改密码" ValidationGroup="ChangeUserPasswordValidationGroup" />
                </p>
            </div>
            <div class="form-group">
                <label for="inputEmail1" class="col-lg-2 control-label">
                    Email</label>
                <div class="col-lg-10">
                    <input type="email" class="form-control" id="inputEmail1" placeholder="Email">
                </div>
            </div>
            <div class="form-group">
                <label for="inputPassword1" class="col-lg-2 control-label">
                    Password</label>
                <div class="col-lg-10">
                    <input type="password" class="form-control" id="inputPassword1" placeholder="Password">
                </div>
            </div>
            <div class="form-group">
                <div class="col-lg-offset-2 col-lg-10">
                    <div class="checkbox">
                        <label>
                            <input type="checkbox">
                            Remember me
                        </label>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="col-lg-offset-2 col-lg-10">
                    <button type="submit" class="btn btn-default">
                        Sign in</button>
                </div>
            </div>
        </ChangePasswordTemplate>
    </asp:ChangePassword>
  
</asp:Content>
