<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="default.aspx.cs" Inherits="PM.Web.alarm._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="bs-docs-section">
            <div class="alert alert-warning">
                报警状态：<asp:DropDownList ID="status" runat="server">
                </asp:DropDownList>
                起始时间：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                &nbsp;终止时间：<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                &nbsp;<asp:Button ID="btnQuery" runat="server" Text="查询" CssClass="btn btn-danger" />
                <asp:Button ID="btnTotal" runat="server" Text="统计" CssClass="btn btn-danger" />
                <asp:Button ID="btnPing" runat="server" Text="通信状态" CssClass="btn btn-danger" />
                <asp:Button ID="btnExport" runat="server" Text="导出Excel" CssClass="btn btn-danger" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="bs-docs-section">
        <table width="100" class="table">
            <thead>
                <th>报警类型</th>
                <th>报警值</th>
                <th>报警描述</th>
                <th>报警设置</th>
                <th>报警时间</th>
                <th>确认时间</th>
                <th>确认状态</th>
                <th>确认人</th>
                <th>详细</th>
                <th>处理</th>
            </thead>
            <tbody>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tbody>
        </table>

        </div>
    </div>
</asp:Content>
