
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

    //为开始、结束时间绑定日历控制
    $(".startdate").click(function () {
        WdatePicker({ lang: 'zh-cn', dateFmt: 'yyyy-MM-dd HH:mm', maxDate: '%y-%M-{%d}' })
    });

    $(".enddate").click(function () {
        WdatePicker({ lang: 'zh-cn', dateFmt: 'yyyy-MM-dd HH:mm', maxDate: '%y-%M-{%d}' })
    });


    $('input[name="datetype"]:radio').change(function () {
        AddEvent();
        var value = $(this).val();
        if (value == "MINUTE") {
            //  initHistoryMinute();
        } else {
            //  initHistoryHour();
        }
    });

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

    /**
    * 获取日期类型
    */
    function getDateType() {
        return $('.history input[name="datetype"]:checked').val();
    }

    function AddEvent() {
        var datetype = getDateType();
        if (datetype == "MINUTE") {
            $(".startdate").click(function () {
                WdatePicker({ lang: 'zh-cn', dateFmt: GetFormat(), maxDate: '%y-%M-%d %H' })
            });

            $(".enddate").click(function () {
                WdatePicker({ lang: 'zh-cn', dateFmt: GetFormat(), maxDate: '%y-%M-%d {%H + 12}' })
            });
        }
        else {
            $(".startdate").click(function () {
                WdatePicker({ lang: 'zh-cn', dateFmt: GetFormat(), maxDate: '%y-%M-{%d}' })
            });

            $(".enddate").click(function () {
                WdatePicker({ lang: 'zh-cn', dateFmt: GetFormat(), maxDate: '%y-%M-{%d + 1}' })
            });
        }
    }


    /**
    * 保存资产安装位置
    */
    $("#btnSave").click(function () {

        var meters = $(".meter");
        var coordinates = new Array();
        $.each($(meters), function (index, obj) {

            //获取测点结构图位置，并保存到数组中
            coordinates.push({ "Assetnum": $(obj).attr("id"), "Assetuid":$(obj).attr("uid"),"X": $(obj).position().left, "Y": $(obj).position().top, "Orgid": ORGID });
        });
        if (coordinates.length == 0) {
            return;
        }

      
        $.ajax({
            type: "POST",
            url: "../services/PostAjaxData.ashx",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify({"funname":"SaveAssetCoordinates","data":coordinates}),
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
