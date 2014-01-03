<%@ Page Title="标准参量" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true"
    CodeBehind="edit.aspx.cs" Inherits="PM.Web.admin.measureunits.edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
   <section class="panel panel-default"> 
<header class="panel-heading font-bold">  编辑标准参量</header> 
<div class="panel-body"> 
    <div class="row">
        <div class="form-group">
            <label for="<%=description.ClientID %>" class="col-lg-2">
                参量名称：</label>
            <div class="col-lg-6">
                <asp:TextBox ID="description" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                <asp:HiddenField ID="measureunituid" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <label for="<%=type.ClientID %>" class="col-lg-2">
                类型：</label>
            <div class="col-lg-6">
                <asp:Label ID="type" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="form-group">
            <label for="<%=measureunitid.ClientID %>" class="col-lg-2">
                标签名称：</label>
            <div class="col-lg-6">
                <asp:Label ID="measureunitid" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="form-group">
            <label for="<%=abbreviation.ClientID %>" class="col-lg-2">
                单位：</label>
            <div class="col-lg-6">
                <asp:Label ID="abbreviation" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="form-group">
            <label for="<%=isCalculate.ClientID %>" class="col-lg-2">
                是否参与运算：</label>
            <div class="col-lg-6">
                <asp:DropDownList ID="isCalculate" runat="server" CssClass="form-control">
                    <asp:ListItem Value="1">是</asp:ListItem>
                    <asp:ListItem Value="0">否</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <label for="<%=visabled.ClientID %>" class="col-lg-2">
                是否显示：</label>
            <div class="col-lg-6">
                <asp:DropDownList ID="visabled" runat="server" CssClass="form-control">
                    <asp:ListItem Value="1">是</asp:ListItem>
                    <asp:ListItem Value="0">否</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <label for="<%=isMainParam.ClientID %>" class="col-lg-2" cssclass="form-control">
                作为主要参数显示：</label>
            <div class="col-lg-6">
                <asp:DropDownList ID="isMainParam" runat="server" CssClass="form-control">
                    <asp:ListItem Value="1">是</asp:ListItem>
                    <asp:ListItem Value="0">否</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <label for="<%=displaysequence.ClientID %>" class="col-lg-2">
                显示顺序：</label>
            <div class="col-lg-6">
                <asp:TextBox ID="displaysequence" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic"
                    ErrorMessage="非法数字" ValidationExpression="^[-]?[0-9]*[.]?[0-9]*$" ControlToValidate="displaysequence"
                    SetFocusOnError="True"></asp:RegularExpressionValidator>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-5 col-lg-offset-2">
    <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="提交" />
            <asp:Button ID="btnDelte" CssClass="btn btn-danger" runat="server" Text="删除" Visible="false" />
            <a href="list.aspx" class="btn btn-info">返回</a>
            </div>
    </div>
    </div>
    </section>
</asp:Content>
