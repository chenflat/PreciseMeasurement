
/**
* 编辑计量点参量信息
*/
$(function () {

    //点击参量编辑链接，显示编辑对话框
    $("[id*=gvParamters] a").click(function () {

        //参量UID和参量编码
        var measurepointparamuid = $(this).attr("id");
        var measureunitid = $(this).attr("name");
        $("[id*=ddlMeasureUnitId]").val(measureunitid);

        //设置元素状态
        $("[id*=ddlPointNum]").attr("disabled", true);
        $("[id*=ddlMeasureUnitId]").attr("disabled", true);

        var row = $(this).parent().parent();
        // console.log(row);

        //设置编辑值
        $("[id*=txtUpperwarning]").val(convertFloat($("td", row).eq(2).html()));
        $("[id*=txtLowerwarning]").val(convertFloat($("td", row).eq(3).html()));
        $("[id*=txtUpperaction]").val(convertFloat($("td", row).eq(4).html()));
        $("[id*=txtLoweraction]").val(convertFloat($("td", row).eq(5).html()));
        $("#measurepointparamuid").val(measurepointparamuid);

        //显示编辑对话框
        $('#myModal').modal('show');

    });


    function convertFloat(text) {
        if (text == "")
            return 0;
        if (isNaN($('#Field').val() / 1) == false) {
            return parseFloat(text);
        } else {
            return 0;
        }
    }




    //保存参量信息
    $("#btnSaveSetting").click(function () {

        //定义变量并赋值
        var pointnum = $("[id*=ddlPointNum]").val();
        var measureunitid = $("[id*=ddlMeasureUnitId]").val();
        var upperwarning = $("[id*=txtUpperwarning]").val();
        var lowerwarning = $("[id*=txtLowerwarning]").val();
        var upperaction = $("[id*=txtUupperaction]").val();
        var loweraction = $("[id*=txtLoweraction]").val();

        var measurePointParamInfo = { "Measurepointparamuid": $("#measurepointparamuid").val(), "Pointnum": pointnum, "Measureunitid": measureunitid, "Lowerwarning": lowerwarning, "Loweraction": loweraction, "Upperwarning": upperwarning, "Upperaction": upperaction };


        $.ajax({
            type: "POST",
            url: "SaveMeasurePointParamInfo.ashx",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(measurePointParamInfo),
            success: function (data) {
                //保存成功，更新界面
                console.log(data);
            },
            error: function (err) {
                //  console.log(err);
                console.log(err.responseText);
            }
        });


        var rows = $("[id*=gvParamters] tr");
        //获取当前参量单位名称
        var measureunitname = $("[id*=ddlMeasureUnitId] :selected").text();

        $.each(rows, function (index, row) {

            if ($.trim($("td", row).eq(0).html()) == measureunitname) {
                $("td", row).eq(2).html(upperwarning);
                $("td", row).eq(3).html(lowerwarning);
                $("td", row).eq(4).html(upperaction);
                $("td", row).eq(5).html(loweraction);
            }

        });



        $('#myModal').modal('hide');
    });

});