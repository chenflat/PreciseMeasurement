<%@ Page Title="自定义报表" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="custom.aspx.cs" Inherits="PM.Web.report.custom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/lib/My97DatePicker/lang/zh-cn.js") %>"></script>
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/lib/My97DatePicker/WdatePicker.js") %>"></script>
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/Pager.min.js") %>"></script>
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/lib/cookies/jquery.cookies.2.2.0.min.js") %>"></script>
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/date.js") %>"></script>
<script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/report.js") %>"></script>
<script>
    var USERID = "<%=userid %>";
    var ORGID = "<%=orgid %>"; 
 </script>
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
                &nbsp;
                <div class="btn-group">
                <button type="button" class="btn btn-danger" id="CreateSetting">自定义设置</button>
                <button type="button" class="btn btn-danger dropdown-toggle" data-toggle="dropdown"><span class="caret"></span></button>
                <ul class="dropdown-menu" role="menu" id="SettingNameList">
                  <% foreach (var item in SettingList) {
                        %>
                        <li><a href="#"><%=item %></a></li>
                        <% 
                     } %>
                </ul>
              </div>

              <div class="btn-group">
                <button type="button" class="btn btn-info" id="btnCustomQuery">生成报表</button>
                <button type="button" class="btn btn-info dropdown-toggle" data-toggle="dropdown"><span class="caret"></span></button>
                <ul class="dropdown-menu" role="menu" id="CreateSettingNameList">
                  <% foreach (var item in SettingList) {
                        %>
                        <li><a href="#"><%=item %></a></li>
                        <% 
                     } %>
                </ul>
              </div>
                
                <%--<button type="button" class="btn btn-info" id="btnCustomQuery">生成报表</button>--%>
                <asp:Button ID="btnExport" runat="server" Text="导出Excel" CssClass="btn btn-info" />
                <a href="default.aspx" class="btn btn-info" >返回主报表</a>
                
            </div>
        </div>
    </div>
    <div class="row">
        <table id="gvCustomReport" class="table table-bordered table-hover">
        <thead>
            <tr></tr>
        </thead>
        <tbody>
        
        </tbody>
        </table>
    </div>

    <!-- Modal -->
    <div class="modal fade bs-example-modal"  id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;</button>
                    <h4 class="modal-title">
                        设置计量点和公式系数</h4>
                </div>
                <div class="modal-body">
                    <div id="message"></div>
                    <div class="row">
                    <div class="col-md-6">
                           <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h3 class="panel-title">
                                        1、选择对比计量点</h3>
                                </div>
                                <div class="panel-body ">
                                     <ul class="nav bs-sidenav" style="margin:0px;">
                                    <%
                                        foreach (System.Collections.Generic.KeyValuePair<string, System.Collections.Generic.List<PM.Entity.MeasurePointInfo>> pair in measurePointList)
                                        { 
                                    %>
                                    <li class="active"><a href="#">
                                        <%= pair.Key %></a>
                                        <ul class="nav measurepoint-list">
                                            <% foreach (PM.Entity.MeasurePointInfo point in pair.Value)
                                               {%>
                                            <li id="<%=point.Pointnum %>" style="padding-left:30px;cursor:pointer;"><%=point.Description%></li>
                                            <% } %>
                                        </ul>
                                    </li>
                                    <%
                                    }
                                    %>
                   
                                </ul>
                                </div>
                            </div></div>
                       
                        
                        <div class="col-md-6">
                             <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h3 class="panel-title">
                                        2、设置参数</h3>
                                </div>
                                <div class="panel-body">
                                    <div class="settingname">
                                    设置名称：<input type="text" id="SettingName" />
                                    <input type="hidden" name="IsItemFormula" id="IsItemFormula" value="true" />
                                    </div>
                                    <div class="sel-points">
                                    选择的计量点
                                    <ul id="container-measurepoints">
                                    
                                    </ul>
                                    </div>
                                </div>
                            </div>
                           </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">
                        关闭</button>
                    <button type="button" class="btn btn-primary" id="btnSaveSetting">
                        保存设置</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->
</asp:Content>
