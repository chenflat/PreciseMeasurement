<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="default.aspx.cs" Inherits="PM.Web.report._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/lib/My97DatePicker/lang/zh-cn.js") %>"></script>
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/lib/My97DatePicker/WdatePicker.js") %>"></script>
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/Pager.min.js") %>"></script>
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/date.js") %>"></script>
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/report.js") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="bs-docs-section">
            <div class="alert alert-info">
                起始时间：
                <asp:TextBox ID="startdate" CssClass="Wdate startdate" runat="server"></asp:TextBox>
                <label for="enddate" class="endzone">
                &nbsp;终止时间：<asp:TextBox ID="enddate" CssClass="Wdate enddate" runat="server"></asp:TextBox></label>
                级别：<asp:DropDownList ID="status" runat="server">
                    <asp:ListItem>全部</asp:ListItem>
                </asp:DropDownList>
                &nbsp;<asp:Button ID="btnQuery" runat="server" Text="查询" CssClass="btn btn-info btnQuery" />
                <asp:Button ID="btnExport" runat="server" Text="导出Excel" CssClass="btn btn-info" />
            </div>
        </div>
    </div>
    <div class="row">
    <asp:GridView ID="gvReportMeasurement" runat="server" AutoGenerateColumns="False" CssClass="table table-striped"  EnableModelValidation="True">
            <Columns>
                <asp:BoundField DataField="DESCRIPTION" HeaderText="计量点" />
                <asp:BoundField DataField="LEVEL" HeaderText="级别" />
                <asp:BoundField DataField="STARTTIME" DataFormatString="{0:yyyy-MM:dd hh:mm}" HeaderText="起始时间" />
                <asp:BoundField DataField="STARTVALUE" HeaderText="起始表数(t)" />
                 <asp:BoundField DataField="ENDTIME" DataFormatString="{0:yyyy-MM:dd hh:mm}" HeaderText="截止时间" />
                <asp:BoundField DataField="LASTVALUE" HeaderText="终止表数(t)" />
                <asp:BoundField DataField="VALUE" HeaderText="小时用量(t)" />
            
            </Columns>
        </asp:GridView>
       
    
    </div>
</asp:Content>
