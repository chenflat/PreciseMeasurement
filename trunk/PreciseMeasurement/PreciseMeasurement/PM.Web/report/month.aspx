<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="month.aspx.cs" Inherits="PM.Web.report.month" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/lib/My97DatePicker/lang/zh-cn.js") %>"></script>
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/lib/My97DatePicker/WdatePicker.js") %>"></script>
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/Pager.min.js") %>"></script>
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/lib/cookies/jquery.cookies.2.2.0.min.js") %>"></script>
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/date.js") %>"></script>
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/report.js") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="row">
        <div class="bs-docs-section">
            <div class="alert alert-info">
                年：
                <asp:TextBox ID="txtYear" CssClass="Wdate year" runat="server"></asp:TextBox>
              
                级别：<asp:DropDownList ID="status" runat="server">
                    <asp:ListItem>全部</asp:ListItem>
                </asp:DropDownList>
                &nbsp;
                
                <asp:Button ID="btnMonthQuery" runat="server" CssClass="btn btn-info" Text="月报查询" />
                <asp:Button ID="btnExport" runat="server" Text="导出Excel" CssClass="btn btn-info" />
                <a href="default.aspx" class="btn btn-info" >返回主报表</a>
            </div>
        </div>
    </div>
    <div class="row">
      <asp:GridView ID="gvMonthReport" runat="server"  CssClass="table table-bordered table-striped table-hover">
        </asp:GridView>


    </div>
</asp:Content>
