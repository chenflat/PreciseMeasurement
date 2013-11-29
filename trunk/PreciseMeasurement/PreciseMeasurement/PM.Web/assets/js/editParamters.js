
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
        $("#upperwarning").val($("td", row).eq(2).html());
        $("#lowerwarning").val($("td", row).eq(3).html());
        $("#upperaction").val($("td", row).eq(4).html());
        $("#loweraction").val($("td", row).eq(5).html());
        $("#measurepointparamuid").val(measurepointparamuid);

        //显示编辑对话框
        $('#myModal').modal('show');

    });


    //保存参量信息
    $("#btnSaveSetting").click(function () {

        //定义变量并赋值
        var pointnum = $("[id*=ddlPointNum]").val();
        var measureunitid = $("[id*=ddlMeasureUnitId]").val();
        var upperwarning = $("#upperwarning").val();
        var lowerwarning = $("#lowerwarning").val();
        var upperaction = $("#upperaction").val();
        var loweraction = $("#loweraction").val();

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