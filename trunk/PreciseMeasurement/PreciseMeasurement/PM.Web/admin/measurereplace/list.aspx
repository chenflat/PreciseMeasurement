<%@ Page Title="换表管理" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true"
    CodeBehind="list.aspx.cs" Inherits="PM.Web.admin.measurereplace.list" %>

<%@ Register src="../../controls/PageControl.ascx" tagname="PageControl" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
    <div class="toolbar bs-callout-danger">
        起始时间：<asp:TextBox ID="startdate" runat="server" Width="80px" CssClass="datepicker"></asp:TextBox>
        终止时间：<asp:TextBox ID="enddate" runat="server" Width="80px" CssClass="datepicker"></asp:TextBox>
        级别：<asp:DropDownList ID="level" runat="server">
            <asp:ListItem Value="1">一级</asp:ListItem>
            <asp:ListItem Value="2">二级</asp:ListItem>
        </asp:DropDownList>
        计量点名称:<asp:TextBox ID="pointnum" runat="server"></asp:TextBox>
        记录状态：<asp:DropDownList ID="status" runat="server">
            <asp:ListItem Value=""></asp:ListItem>
            <asp:ListItem Value="REALTIME">实时</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="btnQuery" class="btn btn-info" runat="server" Text="查询" />
        <asp:Button ID="btnExport" class="btn btn-info" runat="server" Text="导出Excel" />
        <a href="edit.aspx" class="btn btn-info">新增</a>
    </div>
    <asp:GridView ID="gvMeasureReplace" runat="server" EnableModelValidation="True" 
        AutoGenerateColumns="False" CssClass="table table-striped" 
        DataKeyNames="MEASURETRANSID" PageSize="20" CellPadding="4" 
        CellSpacing="1" GridLines="None">
        <Columns>
            <asp:BoundField DataField="POINTNUM" HeaderText="计量点" />
            <asp:BoundField DataField="MEASUREUNITNAME" HeaderText="参数名" />
            <asp:BoundField DataField="MEASUREMENTVALUE" HeaderText="换表前读数" />
            <asp:BoundField DataField="TOMEASUREMENTVALUE" HeaderText="新表读数" />
            <asp:BoundField DataField="CORRECTEDVALUE" HeaderText="修正值" />
            <asp:BoundField DataField="REPLACEPERSON" HeaderText="换表人" />
            <asp:BoundField DataField="REPLACEDATE" HeaderText="换表时间"  DataFormatString="{0:d}"  />
            <asp:BoundField DataField="ENTERBY" HeaderText="记录人" />
            <asp:BoundField DataField="ENTERDATE" HeaderText="记录时间"  DataFormatString="{0:d}" />
            <asp:TemplateField HeaderText="编辑">
                <ItemTemplate>
                    <a href='edit.aspx?Id=<%# DataBinder.Eval(Container.DataItem, "MEASURETRANSID")%>&PageIndex=<%=PageControl1.CurrentPageIndex %>'
                        title="修改">修改</a>
                </ItemTemplate>
                <ItemStyle Width="60px" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <uc1:PageControl ID="PageControl1" runat="server" />
</asp:Content>
