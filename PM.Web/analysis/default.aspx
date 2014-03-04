<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="default.aspx.cs" Inherits="PM.Web.analysis._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/lib/My97DatePicker/lang/zh-cn.js") %>"></script>
    <script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/lib/My97DatePicker/WdatePicker.js") %>"></script>
    <script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/ASPSnippets_Pager.min.js") %>"></script>
    <script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/date.js") %>"></script>
    <script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/lib/highcharts/highstock.js") %>"></script>
    <script language="javascript" type="text/javascript" src="<%=ResolveUrl("~/assets/js/analysis.js") %>"></script>
    <script>
        var USERID = "<%=userid %>";
        var ORGID = "<%=orgid %>";
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="bs-docs-section">
            <div class="toolbar bs-callout-info analysis">
                时间类型：<label><input type="radio" name="datetype" checked="checked" value="MINUTE" />分钟</label>
                <label>
                    <input type="radio" name="datetype" value="HOUR" />小时</label>
                &nbsp;&nbsp;&nbsp;&nbsp; 起始时间：<input type="text" id="startdate" class="Wdate startdate" />
                终止时间：<input type="text" class="Wdate enddate" id="enddate" />
                &nbsp; <a data-toggle="modal" href="#myModal" class="btn btn-danger">设置计量器对比参量</a>
                <input type="button" class="btn btn-danger" id="btnQuery" value="生成曲线" />
            </div>
        </div>
    </div>
    <div class="row" id="charts">
    
    </div>


    <!-- Button trigger modal -->
    <!-- Modal -->
    <div class="modal fade bs-example-modal"  id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
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
                                    <ul style="margin:0px; list-style:none;" id="paramlist">
                                        <li id="SW_Temperature"><a href="#">温度</a></li>
                                        <li id="SW_Pressure"><a href="#">压力</a></li>
                                        <li id="AF_FlowInstant"><a href="#">瞬时流量</a></li>
                                        <li id="AI_Density"><a href="#">频率</a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                           <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h3 class="panel-title">
                                        2、选择对比计量点</h3>
                                </div>
                                <div class="panel-body bs-sidebar">
                                     <ul class="nav bs-sidenav" style="margin:0px;">
    
                                    <%
                                        foreach (System.Collections.Generic.KeyValuePair<string, System.Collections.Generic.List<PM.Entity.MeasurePointInfo>> pair in measurePointList)
                                        { 
                                    %>
                                    <li  class="assetitem"><a href="#">
                                        <%= pair.Key %></a>
                                        <ul class="nav measurepoint-list">
                                            <% foreach (PM.Entity.MeasurePointInfo point in pair.Value)
                                               {%>
                                            <li id="<%=point.Pointnum %>"><a href="#">
                                               [<%=point.Pointnum %>] <%=point.Description%></a></li>
                                            <% } %>
                                        </ul>
                                    </li>
                                    <%
                                    }
                                    %>
                   
                                </ul>
                                </div>
                            </div></div>
                        <div class="col-md-4">
                             <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h3 class="panel-title">
                                        3、核对查询条件</h3>
                                </div>
                                <div class="panel-body">
                                    <div class="sel-params">
                                    选择的参数
                                    <ul id="container-params">
                                    
                                    </ul>
                                   </div>
                                    <div class="sel-points">
                                    选择的计量点
                                    <ul  id="container-measurepoints">
                                    
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
    <div id="container" style="height: 500px; min-width: 600px"></div>
<div id="report" style="font: 0.8em sans-serif"></div>
   <%-- <script>
        $(function () {
            $.getJSON('http://www.highcharts.com/samples/data/jsonp.php?filename=aapl-ohlcv.json&callback=?', function (data) {

                // split the data set into ohlc and volume
                var ohlc = [],
                    volume = [],
                    dataLength = data.length;

                for (i = 0; i < dataLength; i++) {
                    ohlc.push([
                        data[i][0], // the date
                        data[i][1], // open
                        data[i][2], // high
                        data[i][3], // low
                        data[i][4] // close
                    ]);

                    volume.push([
                        data[i][0], // the date
                        data[i][5] // the volume
                    ])
                }

                // set the allowed units for data grouping
                var groupingUnits = [[
                    'week',                         // unit name
                    [1]                             // allowed multiples
                ], [
                    'month',
                    [1, 2, 3, 4, 6]
                ]];

                // create the chart
                $('#container').highcharts('StockChart', {

                    rangeSelector: {
                        selected: 1
                    },

                    title: {
                        text: 'AAPL Historical'
                    },

                    yAxis: [{
                        title: {
                            text: 'OHLC'
                        },
                        height: 200,
                        lineWidth: 2
                    }, {
                        title: {
                            text: 'Volume'
                        },
                        top: 300,
                        height: 100,
                        offset: 0,
                        lineWidth: 2
                    }],

                    series: [{
                        type: 'candlestick',
                        name: 'AAPL',
                        data: ohlc,
                        dataGrouping: {
                            units: groupingUnits
                        }
                    }, {
                        type: 'column',
                        name: 'Volume',
                        data: volume,
                        yAxis: 1,
                        dataGrouping: {
                            units: groupingUnits
                        }
                    }]
                });
            });
        });



    </script>--%>



</asp:Content>
