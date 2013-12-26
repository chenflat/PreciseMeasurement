
/**
* 疏水器JS
* 
*
*
*
*
*
*@author PING.CHEN
*@version 1.0
*/
$(function () {


    /**
    * 点击记量点，动态显示当前数据的计量值
    */
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


    //每60秒自动重新获取实时数据
    setInterval(getRealData, 60000);
    getRealData()

    //获取设置类型
    function GetType() {
        var type = $("input[name='carrier']:checked").val();
        if (type == '') { type = "steam"; }
        return type;
    }

    //切换类型
    $('input[name="carrier"]:radio').change(function () {
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
        $.getJSON('../services/GetAjaxData.ashx', { "funname": "GetAsssetRealtimeMeasureValue", "specclass": "STEAM", "specsubclass": "STEAMTRAP" }, function (data) {
            //设置计量点数值
            $.each(data, function (index, obj) {
                var mstyle = "";

                var level = 1;
                var measuretime = "";
                var front_temperature = "0"
                var after_temperature = "0"
                var diff_temperature = "0"
                var status = "";   //疏水 直通  堵塞

                if (obj.Measurements.length > 0) {
                    if ((new Date(obj.Measurements[0].Measuretime).toString('yyyy-MM-dd')) == '1900-01-01') {
                        mstyle = " style='color:red;'";
                    }
                    measuretime = obj.Measurements[0].Measuretime;
                    front_temperature = obj.Measurements[0].SwTemperature;
                    after_temperature = obj.Measurements[1].SwTemperature;
                    diff_temperature = parseFloat(front_temperature) - parseFloat(after_temperature);
                    console.log(measuretime);
                }

                content += "<tr " + mstyle + ">"
                content += "<td>" + level + "级</td>"
                content += "<td>[" + obj.AssetInfo.Assetnum + "]" + obj.AssetInfo.Description + "</td>"
                content += "<td>" + measuretime + "</td>"
                content += "<td>" + front_temperature + "</td>"
                content += "<td>" + after_temperature + "</td>"
                content += "<td>" + diff_temperature + "</td>"
                content += "<td>" + status + "</td>"
                content += "</tr>";

                $("#" + obj.AssetInfo.Assetnum + "_data .front_temperature span").text(front_temperature);
                $("#" + obj.AssetInfo.Assetnum + "_data .after_temperature span").text(after_temperature);
                $("#" + obj.AssetInfo.Assetnum + "_data .measuretime div").text(measuretime);

            });

            $("#gvRealtimeData tbody").append(content);
        });
    }


    /**
    * 保存资产安装位置
    */
    $("#btnSave").click(function () {

        var meters = $(".meter");
        var coordinates = new Array();
        $.each($(meters), function (index, obj) {

            //获取测点结构图位置，并保存到数组中
            coordinates.push({ "Assetnum": $(obj).attr("id"), "Assetuid": $(obj).attr("uid"), "X": $(obj).position().left, "Y": $(obj).position().top, "Orgid": ORGID });
        });
        if (coordinates.length == 0) {
            return;
        }

       

        $.ajax({
            type: "POST",
            url: "../services/PostAjaxData.ashx",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify({ "funname": "SaveAssetCoordinates", "data": coordinates }),
            success: function (data) {
                console.log(data);
                alert("计量点位置保存成功，请关闭窗口!");
            },
            error: function (data) {
                //console.log(response);
            }
        });

    });

});


$(window).load(function () {

    //计量点编辑
    var asset = window.dialogArguments;
    if (asset == null) {
        return;
    }
    console.log(asset);
    console.log(asset.OpStatus);
    if (asset.OpStatus == "edit") {
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
