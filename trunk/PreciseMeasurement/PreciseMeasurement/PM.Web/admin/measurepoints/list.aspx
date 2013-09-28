<%@ Page Title="计量点管理" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="PM.Web.admin.measurepoints.list" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">

<div class="toolbar bs-callout-danger">
        所属组织：<asp:DropDownList ID="ddlOrgId" runat="server">
    </asp:DropDownList>
    计量点名称：<asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
        
        携能载体：<asp:DropDownList ID="ddlCarrier" runat="server">
            <asp:ListItem Value="汽">汽</asp:ListItem>
            <asp:ListItem>水</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="btnQuery" runat="server" CssClass="btn btn-primary" Text="查询" />
    <asp:Button ID="btnExport" runat="server" CssClass="btn btn-primary" Text="导出" />
    <asp:Button ID="btnClone" runat="server" CssClass="btn btn-primary" Text="复制" />
     <a href="edit.aspx" class="btn btn-primary">新增</a>
    </div>
    <asp:Repeater ID="rptMeasurePoint" runat="server">
        <HeaderTemplate>
            <table width="100%" border="0" cellpadding="4" cellspacing="1" class="table table-striped">
                <tr>
                    <th width="120">
                        计量编号
                    </th>
                    <th width="18%">
                        计量点名称
                    </th>
                    <th width="60">
                        序号
                    </th>
                    <th width="10%">
                        所属公司
                    </th>
                    <th width="10%">
                        计量点IP
                    </th>
                    <th width="10%">
                        3G卡号
                    </th>
                     <th width="10%">
                        参量设置
                    </th>
                    <th width="60">
                        编辑
                    </th>
                     <th width="15%">
                        计量点详细浏览
                    </th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%#Eval("POINTNUM")%>
                </td>
                <td>
                    <%#Eval("DESCRIPTION")%>
                </td>
                <td>
                    <%#Eval("DISPLAYSEQUENCE")%>
                </td>
                <td>
                    <%#Eval("ORGNAME")%>
                </td>
                <td>
                    <%#Eval("IPADDRESS")%>
                </td>
                <td>
                    <%#Eval("CARDNUM")%>
                </td>
                <td>
                    <a href="paramters.aspx?id=<%#Eval("MEASUREPOINTID") %>">参量设置</a>
                </td>
                <td>
                    <a href="edit.aspx?id=<%#Eval("MEASUREPOINTID") %>">编辑</a>
                </td>
                <td>
                    <a href="edit.aspx?id=<%#Eval("MEASUREPOINTID") %>">计量点详细浏览</a>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>


</asp:Content>
