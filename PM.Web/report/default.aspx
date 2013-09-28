<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="PM.Web.report._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="bs-docs-section">
            <div class="alert alert-info">

                起始时间：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                &nbsp;终止时间：<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                级别：<asp:DropDownList ID="status" runat="server">
                    <asp:ListItem>全部</asp:ListItem>
                </asp:DropDownList>
                &nbsp;<asp:Button ID="btnQuery" runat="server" Text="查询" CssClass="btn btn-info" />
                <asp:Button ID="btnExport" runat="server" Text="导出Excel" CssClass="btn btn-info" />
                <asp:Button ID="btnDayReport" runat="server" Text="计量点日报" CssClass="btn btn-info" />
                <asp:Button ID="btnWeekReport" runat="server" Text="计量点周报" CssClass="btn btn-info" />
                <asp:Button ID="btnMonthReport" runat="server" Text="计量点月报" CssClass="btn btn-info" />
            </div>
        </div>
    </div>
</asp:Content>
