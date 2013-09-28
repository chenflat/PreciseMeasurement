<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="default.aspx.cs" Inherits="PM.Web.analysis._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="bs-docs-section">
            <div class="alert alert-warning">
                时间类型：<asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                    RepeatLayout="Flow" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="minute">分钟</asp:ListItem>
                    <asp:ListItem Value="hour">小时</asp:ListItem>
                </asp:RadioButtonList>
                起始时间：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                &nbsp;终止时间：<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                &nbsp;<asp:Button ID="btnQuery" runat="server" Text="设置计量器对比参量" 
                    CssClass="btn btn-danger" />
                <asp:Button ID="btnTotal" runat="server" Text="生成曲线" 
                    CssClass="btn btn-danger" />
            </div>
        </div>
    </div>
</asp:Content>
