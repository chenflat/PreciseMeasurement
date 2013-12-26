﻿
/**
* 曲线对比
**/
$(function () {

    $(".bs-sidenav .active").on('click', function () {
        $(this).children('ul').toggle(300);
    });



    AddEvent();
    initSettings();

    //初始化分钟
    function initHistoryMinute() {
        $(".analysis .startdate").val(new Date().addHours(-12).toString("yyyy-MM-dd HH:mm"));
        $(".analysis .enddate").val(new Date().toString("yyyy-MM-dd HH:mm"));
    }
    //初始化小时
    function initHistoryHour() {
        $(".analysis .startdate").val(Date.today().add(-1).day().toString("yyyy-MM-dd"));
        $(".analysis .enddate").val(Date.today().toString("yyyy-MM-dd"));
    }

    initHistoryMinute();


    //更新时间类型事件
    $('.analysis input[name="datetype"]:radio').change(function () {

        AddEvent();

        var value = $(this).val();
        if (value == "MINUTE") {
            initHistoryMinute();
        } else {
            initHistoryHour();
        }
        console.log($(this).val());
    });


    //动态添加计量点到列表
    $(".measurepoint-list li").click(function () {
        var text = $(this).text();
        var id = $(this).attr("id");
        var li = "<li id='" + id + "'>" + text + "</li>";
        if (!hasPointElement(text)) {
            $("#container-measurepoints").append(li);
        }
    });

    //添加资产对应的计量器到列表
    $(".assetitem").click(function () {
        var children = $(this).children().find("li");
        $.each(children, function (index, obj) {
            var text = $(obj).text();
            var id = $(obj).attr("id");
            var li = "<li id='" + id + "'>" + text + "</li>";

            if (!hasPointElement(text)) {
                $("#container-measurepoints").append(li);
            }
        });
    });




    //移除参数
    $("#container-params").on("click", "li", function () {
        //alert($(this).text());
        $(this).remove();
    });

    //移除计量点
    $("#container-measurepoints").on("click", "li", function () {
        // alert($(this).text());
        $(this).remove();
    });


    //判断是否存在参数元素
    function hasParamElement(text) {
        var ret = false;
        $("#container-params li").each(function (index, obj) {
            if ($(obj).text() == text) {
                ret = true;
            }
        });
        return ret;
    }

    //判断是否存在计量点元素
    function hasPointElement(text) {
        var ret = false;
        $("#container-measurepoints li").each(function (index, obj) {
            if ($(obj).text() == text) {
                ret = true;
            }
        });
        return ret;
    }


    /**
    * 初始化设置
    */
    function initSettings() {
        var parameters = window.location.search.slice(1);
        if (parameters != "") {
            if (parameters.indexOf("&") >= 0) {
                var arrParams = parameters.split("&");
            } else {
                var arrKeyValues = parameters.split("=");
                var key = arrKeyValues[0];
                var value = arrKeyValues[1];

                if (key == "assetuid") {
                    $.getJSON('../services/GetAjaxData.ashx', { "funname": "GetAssetmeters", "assetuid": value }, function (data) {
                        var points = [];
                        $.each(data, function (index, obj) {
                            points.push('<li id="' + obj.Metername + '">' + obj.PointDescription + '</li>');
                        });
                        $("#container-measurepoints").append(points.join(""));
                    });
                }
            }

        } else {

            $.getJSON('../services/GetAjaxData.ashx', { "funname": "GetAnalyzeSettings", "userid": USERID, "orgid": ORGID, "tablename": "STREAMTRAP" }, function (data) {

                var params = [];
                var points = [];

                $.each(data, function (index, obj) {
                    if (obj.Type == 0) {
                        params.push('<li id="' + obj.SettingName + '">' + obj.Description + '</li>');
                    } else {
                        points.push('<li id="' + obj.SettingName + '">' + obj.Description + '</li>');
                    }
                });
                $("#container-params").append(params.join(""));
                $("#container-measurepoints").append(points.join(""));
            });
        }
    }


    //保存设置
    $("#btnSaveSetting").click(function () {

        var settings = new Array();

        //        $("#container-params li").each(function (index, obj) {
        //            var item = { "type": "MEASUREUNIT", "SETTINGNAME": $(obj).attr("id"), "DESCRIPTION": $.trim($(obj).text()), "USERID": USERID, "ORGID": ORGID };
        //            settings.push(item);
        //        });

        $("#container-measurepoints li").each(function (index, obj) {
            var item = { "type": "MEASUREPOINT", "SETTINGNAME": $(obj).attr("id"), "DESCRIPTION": $.trim($(obj).text()), "TABLENAME": "STREAMTRAP", "USERID": USERID, "ORGID": ORGID };
            settings.push(item);
        });

        if (settings.length == 0)
            return;

        $.ajax({
            type: "POST",
            url: "HandlerAnalyzeSetting.ashx",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(settings),
            success: function (data) {
                $('#myModal').modal('hide')
            },
            error: OnFail
        });
    });

    //生成曲线
    $("#btnQuery").click(function () {
        historyDataChart()
    });


    function historyDataChart() {
        $("#processing").show();
        //获取开始和结束日期，时间类型（分钟、小时）
        var startdate = $(".startdate").val();
        var enddate = $(".enddate").val();
        var datetype = $("input[name='datetype']:checked").val();
        GetChart(startdate, enddate, datetype);
        $("#processing").hide();
    }
    historyDataChart();

});

/**
 * 获取时间类型 
 */
function getDateType() {
    var datetype = $("input[name='datetype']:checked").val();
    if (datetype == '') { datetype = "MINUTE"; }
    return datetype;
}

/**
 * 获取时间格式
 */
function GetFormat() {
    var type = getDateType();
    if (type == "MINUTE") {
        return 'yyyy-MM-dd HH:00';
    }
    else {
        return 'yyyy-MM-dd';
    }
}

function AddEvent() {
    var type = getDateType();

    if (type == "Minute") {


        $(".analysis .startdate").click(function () {
            WdatePicker({ lang: 'zh-cn', dateFmt: GetFormat(), maxDate: '%y-%M-%d %H' })
        });

        $(".analysis .enddate").click(function () {
            WdatePicker({ lang: 'zh-cn', dateFmt: GetFormat(), maxDate: '%y-%M-%d {%H + 12}' })
        });
    }
    else {

        $(".analysis .startdate").click(function () {
            WdatePicker({ lang: 'zh-cn', dateFmt: GetFormat(), maxDate: '%y-%M-{%d}' })
        });

        $(".analysis .enddate").click(function () {
            WdatePicker({ lang: 'zh-cn', dateFmt: GetFormat(), maxDate: '%y-%M-{%d + 1}' })
        });
    }
}





//获取比较参数据
function getCompareParams() {
    var params = new Array();
    $("#container-params li").each(function (index, obj) {
        var p = { "num": $(obj).attr("id"), "description": $(obj).text() };
        params.push(p);
    });
    return params;
}
//获取比较测点
function getComparePoints() {
    var points = new Array();
    $("#container-measurepoints li").each(function (index, obj) {
        var p = { "num": $(obj).attr("id"), "description": $(obj).text()};
        points.push(p);
    });
    return points;
}

/**
* 获取数据曲线
*
* @param pointnum 测点编号
* @param startdate 开始统计日期
* @param enddate 结束统计日期
*/
function GetChart(startdate, enddate, datetype) {

    //获取比较参数
    var params = [];
    params.push({ "num": "SW_Temperature", "description": "温度" }); 
    //获取要比较的计量点
    var points = getComparePoints();
    var datetype = getDateType();
    var seriesOptions_Temp = [],
        seriesOptions_Density = [],
        seriesOptions_FlowInstant = [],
        seriesOptions_Pressure = [],
		yAxisOptions = [],
		seriesCounter = 0,
		colors = Highcharts.getOptions().colors;


    //计量数据地址,分别查询单点
    var path = "MeasurementHistoryData.ashx";
    $.each(points, function (i, point) {

        $.getJSON(path, { "pointnum": point.num, "startdate": startdate, "enddate": enddate, "type": datetype }, function (result) {
            var data_SwTemperature = [];  //温度数据
            var data_AiDensity = []; //频率数据
            var data_AfFlowInstant = []; //瞬时流量
            var data_SwPressure = [];  //压力


            //重新整理数据到指定类型的数组
            $.each(result, function (index, obj) {
                data_SwTemperature.push([obj.Measuretime, obj.SwTemperature]);
                data_AiDensity.push([obj.Measuretime, obj.AiDensity]);
                data_AfFlowInstant.push([obj.Measuretime, obj.AfFlowinstant]);
                data_SwPressure.push([obj.Measuretime, obj.SwPressure]);
            });


            //多个序列
            seriesOptions_Temp[i] = {
                name: point.description,
                data: data_SwTemperature
            };
            seriesOptions_Density[i] = {
                name: point.description,
                data: data_AiDensity
            };
            seriesOptions_FlowInstant[i] = {
                name: point.description,
                data: data_AfFlowInstant
            };
            seriesOptions_Pressure[i] = {
                name: point.description,
                data: data_SwPressure
            };



            // As we're loading the data asynchronously, we don't know what order it will arrive. So
            // we keep a counter and create the chart when all the data is loaded.
            seriesCounter++;

            if (seriesCounter == points.length) {
                //不同的参数创建不同的图表
                $.each(params, function (index, obj) {
             
                    switch (obj.num) {
                        case "SW_Temperature":
                            console.log(seriesOptions_Temp);
                            createChart(obj, seriesOptions_Temp, '温度(℃)', '(℃)');
                            break;
                        case "AI_Density":
                            createChart(obj, seriesOptions_Density, '频率(Hz)', '(Hz)');
                            break;
                        case "AF_FlowInstant":
                            createChart(obj, seriesOptions_FlowInstant, '流量(t)', '(t)');
                            break;
                        case "SW_Pressure":
                            createChart(obj, seriesOptions_Pressure, '压力(MPa)', '(MPa)');
                            break;
                        default:
                            break;
                    }

                });
            }
        });
    });

    // create the chart when all data is loaded
    function createChart(obj,series,ytitle,unit) {
        console.log(series);
        $("#charts").append("<div id='"+ obj.num +"'></div>");
        var id = obj.num;
        Highcharts.setOptions({
            global: {
                useUTC: false
            }
        });
        $('#' + id).highcharts('StockChart', {
            chart: {
            },
            title: {
                text: obj.description + '曲线' + unit
            },
            legend: {
                enabled:true,
                layout: 'vertical',
                align: 'right',
                verticalAlign: 'middle',
                borderWidth: 0
            },
            xAxis: {
                tickPixelInterval: 240, //x轴上的间隔  
                type: 'datetime', //定义x轴上日期的显示格式  
                labels: {
                    formatter: function () {
                        var vDate = new Date(this.value);
                        var ret = ""
                        if (datetype == 'MINUTE') {
                            ret = vDate.getFullYear() + "-" + (vDate.getMonth() + 1) + "-" + vDate.getDate() + " " + vDate.getHours() + ":" + vDate.getMinutes();
                        } else {
                            ret = vDate.getFullYear() + "-" + (vDate.getMonth() + 1) + "-" + vDate.getDate();
                        }

                        return ret;
                    },
                    align: 'center'
                }
            },

            yAxis: {
                /* labels: {
                formatter: function () {
                return (this.value > 0 ? '+' : '') + this.value + '%';
                }
                }, */
                title : {
                    text: ytitle
                },
                plotLines: [{
                    value: 0,
                    width: 2,
                    color: 'silver'
                }]
            },

            plotOptions: {
                /* series: {
                compare: 'percent'
                } */
            },
             credits: {
	                enabled: false
	            },
            tooltip: {
                xDateFormat: '%Y-%m-%d %H:%M',
                pointFormat: '<span style="color:{series.color}">{series.name} ' + obj.description + '</span>: <b>{point.y}</b> <br/>',
                valueDecimals: 2
            },

            rangeSelector: {
                buttons: [{//定义一组buttons,下标从0开始  
                    type: 'week',
                    count: 1,
                    text: '1w'
                }, {
                    type: 'month',
                    count: 1,
                    text: '1m'
                }, {
                    type: 'month',
                    count: 3,
                    text: '3m'
                }, {
                    type: 'month',
                    count: 6,
                    text: '6m'
                }, {
                    type: 'ytd',
                    text: 'YTD'
                }, {
                    type: 'year',
                    count: 1,
                    text: '1y'
                }, {
                    type: 'all',
                    text: 'All'
                }],
                selected: 0//表示以上定义button的index,从0开始  
            },
            series: series
        });
}

}


function OnFail(response) {
    console.log(response);
}