<%@ Page Title="测点参量设置" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true" CodeBehind="paramters.aspx.cs" Inherits="PM.Web.admin.measurepoints.paramters" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
 <div class="bs-docs-section">
        <div class="page-header">
            <h3>
                <asp:Literal ID="ltPointName" runat="server"></asp:Literal>的参量设置</h3>
        </div>
    </div>


    <asp:GridView ID="gvParamters" runat="server" 
        AutoGenerateColumns="False" CellPadding="4" CellSpacing="1" 
        CssClass="table table-striped" EnableModelValidation="True">
        <Columns>
            <asp:BoundField DataField="MEASUREUNITNAME" HeaderText="参量名称" />
            <asp:BoundField DataField="LOWERWARNING" HeaderText="第一报警下限" />
            <asp:BoundField DataField="LOWERACTION" HeaderText="第二报警下限" />
            <asp:BoundField DataField="UPPERWARNING" HeaderText="第一报警上限" />
            <asp:BoundField DataField="UPPERACTION" HeaderText="第二报警上限" />
            <asp:TemplateField HeaderText="编辑">
                <ItemTemplate>
                    <a href='edit.aspx?Id=<%# DataBinder.Eval(Container.DataItem, "MEASUREPOINTPARAMUID")%>'
                        title="修改">修改</a>
                </ItemTemplate>
                <ItemStyle Width="60px" />
            </asp:TemplateField>
        </Columns>
        <PagerSettings Visible="False" />
    </asp:GridView>



</asp:Content>
