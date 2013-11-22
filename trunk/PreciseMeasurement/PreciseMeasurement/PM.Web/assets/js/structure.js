/**
 * 系统结构图
 * @author: PING.CHEN
 * @version: 1.0 build20131121
 */

$(function () {

    /**
    *
    */
    $("#structure div").click(function () {
        console.log($(this).attr("id"));
        var pointnum, devicenum, description;
        if ($(this).attr("devicenum") != "") {
            devicenum = $(this).attr("devicenum");
        } else {
            devicenum = $(this).attr("cardnum");
        }


        pointnum = $(this).attr("id");
        description = $(this).attr("title");

        $(this).popover({ content: getRealDataByPointNum(devicenum) });

    });


    $("#swichbar").click(function () {
        $("#realdata").toggle(function () {
            if ($("#realdata").css("display") == 'none') {
                $("#swichbar").text('>>');
            } else {
                $("#swichbar").text('<<');
            }
        });
    });

    function getRealDataByPointNum(devicenum) {
        var content = "";
        $.getJSON('../services/GetRealtimeMeasurement.ashx', { "devicenum": devicenum }, function (data) {
            if (data != null) {
                content += "温度：" + data.SW_Temperature + "<br />";
                content += "压力：" + data.SW_Pressure + "<br />";
                content += "瞬时流量：" + data.AF_FlowInstant + "<br />";
                content += "累积流量：" + data.AT_Flow + "<br />";
                content += "频率：" + data.AI_Density + "<br />";
                content += "采集时间：" + new Date(data.MEASURETIME).toString("yyyy-MM-dd HH:mm:ss");

                return content;
            }
        });
    }

    setInterval(getRealData, 60000);
    getRealData()
    counter();

    function getRealData() {
        $("#gvRealtimeData tbody").html("");
        var content = "";
        //获取所有测点对应的实时数据
        $.getJSON('../services/GetRealtimeMeasurement.ashx', { "devicenum": "" }, function (data) {
            $.each(data, function (index, obj) {
                content += "<tr><td>" + obj.Description + "</td>"
                content += "<td>" + new Date(obj.Measuretime).toString('yyyy-MM-dd HH:mm') + "</td>"
                content += "<td>" + obj.SwPressure + "</td>"
                content += "<td>" + obj.SwTemperature + "</td>"
                content += "<td>" + obj.AfFlowinstant + "</td>"
                content += "</tr>";
            });

            $("#gvRealtimeData tbody").append(content);
        });
    }

   
    
});

/***
 * 刷新时间计数器 
 */
var start = 60;
var step = -1;
function counter() {
    $("#counter").text(start);
    start += step;
    if (start < 0)
        start = 60;
    setTimeout("counter()", 1000);
}