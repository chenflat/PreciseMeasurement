<%@ Page Title="组织机构" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true"
    CodeBehind="list.aspx.cs" Inherits="PM.Web.admin.organizations.list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
        <div class="toolbar bs-callout-danger">
                <a href="edit.aspx" class="btn btn-primary">新增</a>
        </div>
        <table width="100%" border="0" cellpadding="4" cellspacing="1" class="table table-striped">
            <tr>
                <th width="20%">
                    机构名称
                </th>
                <th width="20%">
                    类型
                </th>
                <th width="20%">
                    层级
                </th>
                <th width="20%">
                    备注
                </th>
                <th width="20%">
                    编辑
                </th>
            </tr>
            <%if (organizationInfoList != null)
                      {
                          foreach (PM.Entity.OrganizationInfo item in organizationInfoList)
                          {
                              string kg = "";
                              for (int i = 1; i < item.Level; i++) {
                                  kg += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                              }
                              
                    %>
        <tr onmouseover="this.className='tdbgmouseover'; " onmouseout="this.className='tdbg'" class="tdbg">
                        <td align="left">
                           <%=kg %>
                            <a href="edit.aspx?id=<%=item.Organizationid%>" ><%=item.Description%></a>
                        </td>
                        <td><%=item.Orgtype%></td>
                         <td><%=item.Level%></td>
                        <td align="left"><%=item.Comments%>
                           </td>
                        <td align="center">
                            <a href="edit.aspx?id=<%=item.Organizationid%>">编辑</a>
                        </td>
                    </tr>
                        <%}%>
                    <%}
                      else
                      {%>
                    <tr>
                        <td>没有数据</td>
                    </tr>
                    <%} %>
       
        </table>
</asp:Content>
