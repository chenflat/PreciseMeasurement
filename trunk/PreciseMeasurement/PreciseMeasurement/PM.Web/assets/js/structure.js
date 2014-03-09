/**
 * 系统结构图
 * @author: PING.CHEN
 * @version: 1.0 build20131121
 */
$(function () {

    //为数据列表添加滚动条
    $('#datalist').slimScroll({
        height: $("#structrueimg").height()
    });

    
    $('#btnSave').button();
    //拖动区域
    $(".meter_content").draggable();

    //点击记量点，动态显示当前数据的计量值
    $("#structure div").click(function () {
        //编辑时不弹出计量点信息
        if (window.dialogArguments) {
            return;
        }
        pointnum = $(this).attr("id");
        description = $(this).attr("title");
        contentId = pointnum + "_data";

        var position = $("#" + pointnum).position();
        $("#" + contentId).css({ top: position.top + 30, left: position.left + 30 }).toggle();

    });


    $("#structure .close").click(function () {
        $(this).parent().hide();
    });

    //刷新数据
    $("#refreshData").click(function () {
        getRealData();
    });

    /**
    * 关闭或显示时间数据表格
    */
    $("#swichbar").click(function() {
        $("#realdata").toggle(function() {
            if ($("#realdata").css("display") == 'none') {
                $("#swichbar").text('>>');
                $("#refresh").css({
                    left: 1100
                });
            } else {
                $("#swichbar").text('<<');
                $("#refresh").css({
                    left: 750
                });
            }
        });
    });


    //每60秒自动重新获取实时数据
    getRealData()
    setInterval(getRealData, 60000);
    counter();

    //获取设置类型
    function GetType() {
        var type = $("input[name='carrier']:checked").val();
        if (type == '') {
            type = "steam";
        }
        return type;
    }

    //切换类型
    $('input[name="carrier"]:radio').change(function() {
        getRealData();
    });
    /**
    * 获取所有测点的实时数据
    */
    function getRealData() {
        var carrier = GetType();

        $("#gvRealtimeData tbody").html("");
        var content = "";
        //获取所有测点对应的实时数据
        $.getJSON('../services/GetAjaxData.ashx', { "funname": "GetRealtimeMeasureValue", "carrier": carrier }, function (data) {

   
            //设置计量点数值
            $.each(data, function (index, obj) {
                var mstyle = "";

                if ((new Date(obj.Measuretime).toString('yyyy-MM-dd')) == '1900-01-01') {
                    mstyle = " style='color:red;'";

                    $("#" + obj.Pointnum).find(".status").hide();

                    $("#" + obj.Pointnum).find(".icon").removeClass('nomarl').addClass('noconnection');
                }

                var lasttime = new Date(obj.Measuretime);
                var currtime = new Date();

                //console.log("last:" + lasttime);
              //  console.log("currtime:" + currtime);

                //当前时间和最后采集时间比较，如果相差为10，也就是10分钟内未采集数据，则设置当前计量器为故障状态
                var diff = (currtime - lasttime)/(1000*60);
                if (diff > 10) {
                    $("#" + obj.Pointnum).find(".icon").removeClass('nomarl').addClass('fault');
                }

                content += "<tr " + mstyle + "><td>[" + obj.Pointnum + "]" + obj.Description + "</td>"
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
                $("#" + obj.Pointnum + "_data .MEASURETIME div").text(obj.Measuretime);

            });

            $("#gvRealtimeData tbody").append(content);
        });
    }


    




    /**
    * 保存测点位置
    */
    $("#btnSave").click(function () {

        var meters = $(".meter");
        var coordinates = new Array();
        $.each($(meters), function (index, obj) {
            //获取测点结构图位置，并保存到数组中
            coordinates.push({ "Pointnum": $(obj).attr("id"), "X": $(obj).position().left, "Y": $(obj).position().top, "Orgid": $(obj).attr("orgid") });
        });
        if (coordinates.length == 0) {
            return;
        }

        var data = JSON.stringify({ "funname": "SaveMeasurePointCoordinates", "data": coordinates })

        $.post("../services/PostAjaxData.ashx", data, function (result) {
            console.log(result);
            if (result == "True") {
                alert("计量点位置保存成功，请关闭窗口!");
            }
        });

    });

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


/**
 * [计量点编辑]
 * @return {[type]}
 */
$(window).load(function () {

    //计量点编辑
    var measurePoint = window.dialogArguments;
    if (measurePoint == null) {
        return;
    }
    console.log(measurePoint);
    console.log(measurePoint.OpStatus);
    if (measurePoint.OpStatus == "edit") {
        $(".structure-tools").show();

        $(".meter").draggable();
        $("#structure").droppable({
            deactivate: function (event, ui) {
                console.log(ui);
                console.log(ui.draggable);

                var elementId = ui.draggable.attr("id");

                //console.log("ID:" + elementId + ",Left:" + ui.position.left + ",Top:" + ui.position.top);
              
            }
        });
    }

});
