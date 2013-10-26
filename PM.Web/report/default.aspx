<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="default.aspx.cs" Inherits="PM.Web.report._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/lib/My97DatePicker/lang/zh-cn.js") %>"></script>
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/lib/My97DatePicker/WdatePicker.js") %>"></script>
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/Pager.min.js") %>"></script>
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/report.js") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="bs-docs-section">
            <div class="alert alert-info">报表类型：
                <asp:DropDownList ID="ddlReportType" runat="server" CssClass="reporttype">
                    <asp:ListItem Value="ALL" Selected="True">全部</asp:ListItem>
                    <asp:ListItem Value="DAY">日报</asp:ListItem>
                    <asp:ListItem Value="WEEK">周报</asp:ListItem>
                    <asp:ListItem Value="MONTH">月报</asp:ListItem>
                </asp:DropDownList>
                起始时间：
                <asp:TextBox ID="startdate" CssClass="startdate" runat="server"></asp:TextBox>
                <label for="enddate" class="endzone">
                &nbsp;终止时间：<asp:TextBox ID="enddate" CssClass="enddate" runat="server"></asp:TextBox></label>
                级别：<asp:DropDownList ID="status" runat="server">
                    <asp:ListItem>全部</asp:ListItem>
                </asp:DropDownList>
                &nbsp;<asp:Button ID="btnQuery" runat="server" Text="查询" CssClass="btn btn-info btnQuery" />
                <asp:Button ID="btnExport" runat="server" Text="导出Excel" CssClass="btn btn-info" />
            </div>
        </div>
    </div>
</asp:Content>
