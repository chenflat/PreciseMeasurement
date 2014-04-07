<%@ Page Title="自定义报表" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="custom.aspx.cs" Inherits="PM.Web.report.custom" %>
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
                起始时间：
                <asp:TextBox ID="startdate" CssClass="Wdate startdate" runat="server"></asp:TextBox>
                <label for="enddate" class="endzone">
                &nbsp;终止时间：<asp:TextBox ID="enddate" CssClass="Wdate enddate" runat="server"></asp:TextBox></label>

                 
                
                &nbsp;
                <div class="btn-group">
                <button type="button" class="btn btn-danger" id="CreateSetting">自定义设置</button>
              </div>

              
                
                <%--<button type="button" class="btn btn-info" id="btnCustomQuery">生成报表</button>--%>
                
               <a href="day.aspx" class="btn btn-info" id="btnDayQuery">日报</a>
                <a href="week.aspx" class="btn btn-info" id="btnWeekQuery">周报</a>
                <a href="month.aspx" class="btn btn-info" id="btnMonthQuery">月报</a>
                <button type="button" class="btn btn-info" id="btnCustomQuery">数据运算</button>
                <input type="hidden" name="hdnSettingName" id="hdnSettingName">
                <asp:Button ID="btnExport" runat="server" Text="导出Excel" CssClass="btn btn-info" data-toggle="tooltip" data-placement="right" title="必须生成报表后才能导出Excel" />
                  <a href="default.aspx" class="btn btn-info" >返回</a>
                
            </div>
        </div>
    </div>
    <div class="row">
            <div class="col-md-2">
            <div class="panel panel-default">
              <div class="panel-heading">自定报表导航</div>
              <div class="panel-body" id="SettingNameList">       
                <% foreach (var item in SettingList) { %>
                    <div class="settingitem"><a href="#" class="rowQuery" itemname="<%=item %>" title="点击标题执行运算"> <%=item %></a>  <span class="pull-right">

                    <a href="#" class="editSetting" itemname="<%=item %>"><i class="glyphicon glyphicon-pencil"></i></a>
                    <a href="#" class="delSetting" itemname="<%=item %>"><i class="glyphicon glyphicon-remove"></i></a>
                    </div> 
                <%  } %>
              </div>
            </div>

            </div>
        <div class="col-md-10">

            <div class="alert alert-info fade in">
              <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
              <h4>操作提示</h4>
              <p>点击左侧导航菜单，生成对应的自定义报表.</p>
             
            </div>

        <table id="gvCustomReport" class="table table-bordered table-hover">
            <caption id="caption"></caption>
        <thead>
            <tr></tr>
        </thead>
        <tbody>
        
        </tbody>
        </table>
            </div>
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
                    <div class="col-md-4">

                           <div class="panel panel-default clearfix ">
                                <div class="panel-heading">
                                    <h3 class="panel-title">
                                        1、选择计量点</h3>
                                </div>
                                <div class="panel-body bs-sidebar">
                                    <div class="panel-group" id="accordion">
                                        <!--分级显示-->
                                        <%
                                            int k = 0;
                                            foreach (System.Collections.Generic.KeyValuePair<string, System.Collections.Generic.List<PM.Entity.MeasurePointInfo>> pair in measurePointList) { 
                                        %>

                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <h4 class="panel-title">
                                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapse_<%=k %>">
                                                        <%= pair.Key %></a>
                                                </h4>
                                            </div>
                                            <div id="collapse_<%=k %>" class="panel-collapse collapse <% if (k == 0) Response.Write("in"); %>">
                                                <div class="panel-body"><ul class="nav measurepoint-list">
                                                    <% foreach (PM.Entity.MeasurePointInfo point in pair.Value) {%>
                                                    <li id="<%=point.Pointnum %>"><a href="#">[<%=point.Pointnum %>] <%=point.Description%></a></li>
                                                    <% } %></ul>
                                                </div>
                                            </div>
                                        </div>
                                        <%
                                                k++;
                                            }
                                        %>
                                    </div>


                                    <%-- <ul class="nav bs-sidenav" style="margin:0px;">
                                    <%
                                        foreach (System.Collections.Generic.KeyValuePair<string, System.Collections.Generic.List<PM.Entity.MeasurePointInfo>> pair in measurePointList)
                                      { 
                                    %>
                                    <li class="active"><a href="#">
                                        <%= pair.Key %></a>
                                        <ul class="nav measurepoint-list">
                                            <% foreach (PM.Entity.MeasurePointInfo point in pair.Value)
                                               {%>
                                            <li id="<%=point.Pointnum %>" style="padding-left:30px;cursor:pointer;">[<%=point.Pointnum %>]<%=point.Description%> </li>
                                            <% } %>
                                        </ul>
                                    </li>
                                    <%
                                    }
                                    %>
                   
                                </ul>--%>
                                </div>
                            </div></div>
                       
                            <div class="col-md-8">
                               <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h3 class="panel-title">
                                        2、设置参数</h3>
                                    </div>
                                    <div class="panel-body">
                                        <div class="settingname">
                                           <strong>设置名称：</strong><input type="text" id="SettingName" /> *
                                            <input type="hidden" name="IsItemFormula" id="IsItemFormula" value="true" />
                                            <input type="hidden" name="action" id="action" value="create" />
                                        </div>
                                        <div class="sel-points setting">
                                            <strong>选择的计量点</strong>
                                            <ul id="container-measurepoints" class="customlist">

                                            </ul>
                                        </div>
                                        <div class="operators" style="display:none;z-index:210000; position:absolute;">
                                            <strong>可用运算符号</strong>
                                            <div class="btn-toolbar" role="toolbar" style="margin: 0;">
                                                <div class="btn-group">
                                                    <button type="button" class="btn btn-default" title="加">+</button>
                                                    <button type="button" class="btn btn-default" title="减">-</button>
                                                    <button type="button" class="btn btn-default" title="乘">×</button>
                                                    <button type="button" class="btn btn-default" title="除">/</button>
                                                    <button type="button" class="btn btn-default" title="左括符">(</button>
                                                    <button type="button" class="btn btn-default" title="左括符">)</button>
                                                    <button type="button" class="btn btn-default" title="小数点">.</button>
                                                    <button type="button" class="btn btn-default" title="百分比">%</button>
                                                    <button type="button" class="btn btn-default" title="And">|</button>
                                                </div>
                                            </div>
                                            <div class="btn-toolbar" role="toolbar" style="margin: 0;">
                                                <div class="btn-group">
                                                    <button type="button" class="btn btn-default">0</button>
                                                    <button type="button" class="btn btn-default">1</button>
                                                    <button type="button" class="btn btn-default">2</button>
                                                    <button type="button" class="btn btn-default">3</button>
                                                    <button type="button" class="btn btn-default">4</button>
                                                    <button type="button" class="btn btn-default">5</button>
                                                    <button type="button" class="btn btn-default">6</button>
                                                    <button type="button" class="btn btn-default">7</button>
                                                    <button type="button" class="btn btn-default">8</button>
                                                    <button type="button" class="btn btn-default">9</button>
                                                </div>
                                            </div>

                                        </div>


                                        <!--
                                        <div class="formulaWrap">
                                            <strong>显示公式</strong> <br />
                                            <textarea rows="4" cols="48" id="formula" class="formula"></textarea>

                                        </div>-->
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
                    <button type="button" id="btnDelete" class="btn btn-default" data-dismiss="modal">
                        删除</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->
</asp:Content>
