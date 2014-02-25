<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MinuteData.ascx.cs"
    Inherits="PM.Web.realtime.MinuteData" %>
<%@ Register Src="../controls/PageControl.ascx" TagName="PageControl" TagPrefix="uc1" %>
<ol class="breadcrumb">
    <li class="active">
        <asp:Literal ID="ltDescription" runat="server"></asp:Literal>的分钟数据  </li>
</ol>
<div class="panel panel-default">
    <!-- Default panel contents -->
    <div class="panel-heading minute">
        起始时间：
        <input type="text" id="startdate" class="Wdate startdate" />
        终止时间：<input type="text" class="Wdate enddate" id="enddate" />
        <input type="button" class="btn btn-info" id="btnMinuteQuery" value="查询" />
    </div>
    <div class="panel-body">
        <asp:GridView ID="gvMinuteMeasurement" runat="server"
            AutoGenerateColumns="False" CssClass="minutereport table table-bordered table-striped table-hover"
            EnableModelValidation="True" BorderStyle="None">
            <Columns>
                <asp:BoundField DataField="MEASURETIME" DataFormatString="{0:yyyy-MM:dd hh:mm}" HeaderText="采集时间" />
                <asp:BoundField DataField="SW_TEMPERATURE" HeaderText="温度(℃)" />
                <asp:BoundField DataField="SW_PRESSURE" HeaderText="压力(MPa)" />
                <asp:BoundField DataField="AF_FLOWINSTANT" HeaderText="瞬时流量(t/h)" />
                <asp:BoundField DataField="AT_FLOW" HeaderText="累计流量(t)" />
                <asp:BoundField DataField="AI_DENSITY" HeaderText="频率(Hz)" />
            </Columns>
        </asp:GridView>
        <br />
        <div id="minutepager" class="pager">
        </div>


        <div id="personListGrid">
            <table id="">
                <thead>
                    <tr>
                        <th><a href="#"
                            onclick="PM.MEASUREMENT.MeasurementDataGrid.Sort('personname')">采集时间</a></th>
                        <th>温度(℃)</th>
                        <th>压力(MPa)</th>
                        <th>瞬时流量(t/h)</th>
                        <th>累计流量(t)</th>
                        <th>频率(Hz)</th>
                    </tr>

                </thead>
                <tbody data-bind="foreach: PM.MEASUREMENT.MeasurementDataGrid.DataRows">
                    <tr>
                        <td data-bind="text: Measuretime"></td>
                        <td data-bind="text: SwTemperature"></td>
                        <td data-bind="text: SwPressure"></td>
                        <td data-bind="text: AfFlowinstant"></td>
                        <td data-bind="text: AtFlow"></td>
                        <td data-bind="text: AiDensity"></td>
                    </tr>
                </tbody>

            </table>

            <div class="knockout_paginate">

                <div class="paginate_info">
                    显示
		<span
            data-bind="text: PM.MEASUREMENT.MeasurementDataGrid.FirstItemIndex()"></span>- <span
                data-bind="text: PM.MEASUREMENT.MeasurementDataGrid.LastItemIndex()"></span>条记录,
			共<span
                data-bind="text: PM.MEASUREMENT.MeasurementDataGrid.GridParams.totalElements()"></span>条记录，<span>每页显示
                </span>
                    <select
                        data-bind="options: PM.MEASUREMENT.MeasurementDataGrid.GridParams.pageSizeOptions, value: PM.MEASUREMENT.MeasurementDataGrid.SelectedPageSizeOption ">
                    </select>
                </div>


                <div class="knockout_paging">
                    <div>
                        <a class="paginate_button first" href="#"
                            onclick="PM.MEASUREMENT.MeasurementDataGrid.FlipPage(1)">首页</a> <a
                                class="paginate_button previous" href="#"
                                data-bind="click: function () { PM.MEASUREMENT.MeasurementDataGrid.FlipPage(PM.MEASUREMENT.MeasurementDataGrid.GridParams.number() - 1) }">上页</a>

                        <span id="grdPager" data-bind="foreach: PM.MEASUREMENT.MeasurementDataGrid.Pages" style="display: none">
                            <a href='#' data-bind="click: function () { PM.MEASUREMENT.MeasurementDataGrid.FlipPage($index() + 1) }, text: ($index() + 1), css: ($index() + 1) == PM.MEASUREMENT.MeasurementDataGrid.GridParams.number() ? 'paginate_active' : 'paginate_button'"></a>
                        </span>
                    </div>
                    <div class="pagelist">
                        第
			 <input data-bind="value: PM.MEASUREMENT.MeasurementDataGrid.GridParams.requestedPage" type="text" />
                        页共
                <span data-bind="text: PM.MEASUREMENT.MeasurementDataGrid.GridParams.totalPages()"></span>
                        页
                    </div>
                    <div>
                        <a class="next paginate_button" href="#"
                            data-bind="click: function () { PM.MEASUREMENT.MeasurementDataGrid.FlipPage(PM.MEASUREMENT.MeasurementDataGrid.GridParams.number() + 1) }">下页</a>
                        <a class="last paginate_button" href="#"
                            data-bind="click: function () { PM.MEASUREMENT.MeasurementDataGrid.FlipPage(PM.MEASUREMENT.MeasurementDataGrid.GridParams.totalPages()) }">末页</a>
                    </div>
                </div>
            </div>
        </div>

    </div>
</div>

<script type="text/javascript">
    var url = "../services/GetAjaxData.ashx?";
    PM.MEASUREMENT = PM.MEASUREMENT || {};
    PM.MEASUREMENT.MeasurementDataGrid = new CERP.DataGridAjax('', 15);
    PM.MEASUREMENT.Init = function () {
        PM.MEASUREMENT.MeasurementDataGrid.GetData();
        ko.applyBindings(PM.MEASUREMENT.MeasurementDataGrid.DataRows, $("#personListGrid")[0]);
    };
    PM.MEASUREMENT.Init();
</script>