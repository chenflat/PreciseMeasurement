<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="default.aspx.cs" Inherits="PM.Web.analysis._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/lib/My97DatePicker/lang/zh-cn.js") %>"></script>
    <script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/lib/My97DatePicker/WdatePicker.js") %>"></script>
    <script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/ASPSnippets_Pager.min.js") %>"></script>
    <script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/date.js") %>"></script>
    <script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/lib/highcharts/highcharts.js") %>"></script>
    <script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/analysis.js") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="bs-docs-section">
            <div class="alert alert-warning analysis">
                时间类型：<label><input type="radio" name="datetype" checked="checked" value="MINUTE" />分钟</label>
                <label>
                    <input type="radio" name="datetype" value="HOUR" />小时</label>
                &nbsp;&nbsp;&nbsp;&nbsp; 起始时间：<input type="text" id="startdate" class="Wdate startdate" />
                终止时间：<input type="text" class="Wdate enddate" id="enddate" />
                &nbsp; <a data-toggle="modal" href="#myModal" class="btn btn-danger">设置计量器对比参量</a>
                <input type="button" class="btn btn-danger" id="btnHourQuery" value="生成曲线" />
            </div>
        </div>
    </div>
    <!-- Button trigger modal -->
    <!-- Modal -->
    <div class="modal fade"  id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;</button>
                    <h4 class="modal-title">
                        设置对比计量点和参量</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h3 class="panel-title">
                                        1、选择对比参量</h3>
                                </div>
                                <div class="panel-body">
                                    Panel content
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                           <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h3 class="panel-title">
                                        2、选择对比计量点</h3>
                                </div>
                                <div class="panel-body">
                                    Panel content
                                </div>
                            </div></div>
                        <div class="col-md-4">
                             <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h3 class="panel-title">
                                        3、核对查询条件</h3>
                                </div>
                                <div class="panel-body">
                                    Panel content
                                </div>
                            </div></div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">
                        关闭</button>
                    <button type="button" class="btn btn-primary">
                        保存设置</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->
</asp:Content>
