<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="week.aspx.cs" Inherits="PM.Web.report.week" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/lib/My97DatePicker/lang/zh-cn.js") %>"></script>
    <script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/lib/My97DatePicker/WdatePicker.js") %>"></script>
    <script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/Pager.min.js") %>"></script>
    <script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/lib/cookies/jquery.cookies.2.2.0.min.js") %>"></script>
    <script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/date.js") %>"></script>
    <script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/report.js") %>"></script>
    <script language="javascript">
        var USERID = "<%=userid %>";
        var ORGID = "<%=orgid %>"; 
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="bs-docs-section">
            <div class="toolbar bs-callout-info">
                日期：
                <asp:TextBox ID="weekstartdate" CssClass="Wdate weekstartdate" runat="server"></asp:TextBox>
                <label for="enddate" class="endzone">
                    &nbsp;周数：<asp:DropDownList ID="ddlWeeks" runat="server">
                        <asp:ListItem Value="1">1周</asp:ListItem>
                        <asp:ListItem Value="2">2周</asp:ListItem>
                        <asp:ListItem Value="3">3周</asp:ListItem>
                        <asp:ListItem Value="4">4周</asp:ListItem>
                        <asp:ListItem Value="5">5周</asp:ListItem>
                    </asp:DropDownList>
                </label>
                &nbsp;
                 级别：<asp:DropDownList ID="ddlLevel" runat="server">
                     <asp:ListItem Value="">全部</asp:ListItem>
                     <asp:ListItem Value="1">一级</asp:ListItem>
                     <asp:ListItem Value="2">二级</asp:ListItem>
                     <asp:ListItem Value="3">三级</asp:ListItem>
                     <asp:ListItem Value="4">四级</asp:ListItem>
                </asp:DropDownList>&nbsp;
                部门：<asp:DropDownList ID="ddlOrgId" runat="server"></asp:DropDownList>
                 &nbsp;
                     <asp:Button ID="btnWeekQuery" runat="server" CssClass="btn btn-info" Text="周报查询" />
                <asp:Button ID="btnExport" runat="server" Text="导出Excel" CssClass="btn btn-info" />
                <a href="default.aspx" class="btn btn-info" >返回主报表</a>
            </div>
        </div>
    </div>
    <div class="row">
        <asp:GridView ID="gvReport" runat="server"  CssClass="table table-bordered table-striped table-hover">
        </asp:GridView>
    </div>
</asp:Content>
