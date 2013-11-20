<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="default.aspx.cs" Inherits="PM.Web.alarm._default" %>

<%@ Register src="../controls/PageControl.ascx" tagname="PageControl" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="bs-docs-section">
            <div class="alert alert-warning">
                报警状态：<asp:DropDownList ID="ddlStatus" runat="server">
                    <asp:ListItem Value="0">未确认</asp:ListItem>
                    <asp:ListItem Value="1">已确认</asp:ListItem>
                    <asp:ListItem>全部</asp:ListItem>
                </asp:DropDownList>
                起始时间：<asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>
                &nbsp;终止时间：<asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>
                &nbsp;<asp:Button ID="btnQuery" runat="server" Text="查询" CssClass="btn btn-danger" />
                <asp:Button ID="btnTotal" runat="server" Text="统计" CssClass="btn btn-danger" />
                <asp:Button ID="btnPing" runat="server" Text="通信状态" CssClass="btn btn-danger" />
                <asp:Button ID="btnExport" runat="server" Text="导出Excel" CssClass="btn btn-danger" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="bs-docs-section">
            <asp:GridView ID="gvAlarmData" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" EnableModelValidation="True" CssClass="table">
                <Columns>
                    <asp:TemplateField HeaderText="报警类型">
                        <ItemTemplate>
                            高类型
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="MEASUREVALUE" HeaderText="报警值" />
                    <asp:BoundField DataField="ALMCOMMENT" HeaderText="报警描述" />
                    <asp:BoundField DataField="LOGTIME" HeaderText="报警时间" />
                    <asp:BoundField DataField="ACKTIME" HeaderText="确认时间" />
                    <asp:BoundField DataField="应答人" HeaderText="确认人" />
                    <asp:TemplateField HeaderText="处理">
                    <ItemTemplate>处理</ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerSettings Visible="False" />
            </asp:GridView>
            <uc1:PageControl ID="PageControl1" runat="server" />
        </div>
    </div>
</asp:Content>
