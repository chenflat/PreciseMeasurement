<%@ Page Title="计量点管理" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true"
    CodeBehind="list.aspx.cs" Inherits="PM.Web.admin.measurepoints.list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
        <script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/measurepoint.js") %>"></script>
    <div class="toolbar bs-callout-info">
        所属组织：<asp:DropDownList ID="ddlOrgId" runat="server">
        </asp:DropDownList>
        
        携能载体：<asp:DropDownList ID="ddlCarrier" runat="server">
            <asp:ListItem Value="">全部</asp:ListItem>
            <asp:ListItem Value="steam">汽</asp:ListItem>
            <asp:ListItem Value="water">水</asp:ListItem>
            <asp:ListItem Value="electricity">电</asp:ListItem>
            <asp:ListItem Value="area">空气</asp:ListItem>
        </asp:DropDownList>
        级别：<asp:DropDownList ID="ddlLevel" runat="server" CssClass="level">
                     <asp:ListItem Value="">全部</asp:ListItem>
                     <asp:ListItem Value="1">一级</asp:ListItem>
                     <asp:ListItem Value="2">二级</asp:ListItem>
                     <asp:ListItem Value="3">三级</asp:ListItem>
                     <asp:ListItem Value="4">四级</asp:ListItem>
                </asp:DropDownList>
        计量点名称：<asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
        <asp:Button ID="btnQuery" runat="server" CssClass="btn btn-primary" Text="查询" />
        <asp:Button ID="btnExport" runat="server" CssClass="btn btn-primary" Text="导出" />
        <button type="button" id="btnCoordinate" class="btn btn-primary">位置定义</button>
        <%--<asp:Button ID="btnClone" runat="server" CssClass="btn btn-primary" Text="复制" />--%>
        <a href="edit.aspx" class="btn btn-primary">新增</a>
    </div>
    <asp:Repeater ID="rptMeasurePoint" runat="server">
        <HeaderTemplate>
            <table width="100%" border="0" cellpadding="4" cellspacing="1" class="table table-bordered table-hover table-striped">
                <tr>
                    <th width="8%">
                        计量编号
                    </th>
                    <th width="18%">
                        计量点名称
                    </th>
                    <th width="5%">
                        序号
                    </th>
                    <th width="15%">
                        所属机构
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
                    <a href="paramters.aspx?id=<%#Eval("MEASUREPOINTID") %>&pointnum=<%#Eval("POINTNUM") %>">
                        参量设置</a>
                </td>
                <td>
                    <a href="edit.aspx?id=<%#Eval("MEASUREPOINTID") %>">编辑</a>
                </td>
                <td>
                    <a target="_blank" href="../../realtime/default.aspx?measurepointid=<%#Eval("MEASUREPOINTID") %>">
                        计量点详细浏览</a>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>

</asp:Content>
