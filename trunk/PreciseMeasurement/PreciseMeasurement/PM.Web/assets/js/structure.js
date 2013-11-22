/**
 * 系统结构图
 * @author: PING.CHEN
 * @version: 1.0 build20131121
 */

$(function () {

    /**
    * 点击记量点，动态显示当前数据的计量值
    */
    $("#structure div").click(function () {
        console.log($(this).attr("id"));

        pointnum = $(this).attr("id");
        description = $(this).attr("title");
        contentId = pointnum + "_data";

        var position = $("#" + pointnum).position();
        // $(this).popover({ html: true, content: $("#" + contentId).html() });

        $("#" + contentId).css({ top: position.top + 30, left: position.left + 30 }).toggle();
    });

    $("#structure .close").click(function () {
        $(this).parent().hide();
    });

    /**
    * 关闭或显示时间数据表格
    */
    $("#swichbar").click(function () {
        $("#realdata").toggle(function () {
            if ($("#realdata").css("display") == 'none') {
                $("#swichbar").text('>>');
                $("#refresh").css({ left: 1100 });
            } else {
                $("#swichbar").text('<<');
                $("#refresh").css({ left: 1000 });
            }
        });
    });

    /**
    * 获取指定测点的实时数据
    */
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

    //每60秒自动重新获取实时数据
    setInterval(getRealData, 60000);
    getRealData()
    counter();

    /**
    * 获取所有测点的实时数据
    */
    function getRealData() {
        $("#gvRealtimeData tbody").html("");
        var content = "";
        //获取所有测点对应的实时数据
        $.getJSON('../services/GetRealtimeMeasurement.ashx', { "devicenum": "" }, function (data) {
            //设置计量点数值
            $.each(data, function (index, obj) {
                content += "<tr><td>" + obj.Description + "</td>"
                content += "<td>" + new Date(obj.Measuretime).toString('yyyy-MM-dd HH:mm') + "</td>"
                content += "<td>" + obj.SwPressure + "</td>"
                content += "<td>" + obj.SwTemperature + "</td>"
                content += "<td>" + obj.AfFlowinstant + "</td>"
                content += "</tr>";

                $("#" + obj.Pointnum + "_data .SW_Temperature span").text(obj.SwTemperature);
                $("#" + obj.Pointnum + "_data .SW_Pressure span").text(obj.SwPressure);
                $("#" + obj.Pointnum + "_data .AF_FlowInstant span").text(obj.AfFlowinstant);
                $("#" + obj.Pointnum + "_data .AT_Flow span").text(obj.AtFlow);
                $("#" + obj.Pointnum + "_data .AI_Density span").text(obj.AiDensity);
                $("#" + obj.Pointnum + "_data .MEASURETIME div").text(new Date(obj.Measuretime).toString("yyyy-MM-dd HH:mm:ss"));

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