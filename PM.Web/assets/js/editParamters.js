
/**
* 编辑计量点参量信息
*/
$(function () {

    //新增参量
    $("#btnAddParamter").click(function () {

        //参量UID和参量编码
        var measurepointparamuid = $(this).attr("id");
        var measureunitid = $(this).attr("name");
        $("[id*=ddlMeasureUnitId]").val(measureunitid);

        //设置元素状态
        $("[id*=ddlPointNum]").attr("disabled", true);
        $("[id*=ddlMeasureUnitId]").attr("disabled", false);

        $("#ddlIsMainParam").val("true");
        $("#ddlIsCalculate").val("true");
        $("#ddlVisabled").val("true");
        $("#txtDisplaysequence").val("0");

        //显示编辑对话框
        $('#myModal').modal('show');
    });

    //删除参量
    $("[id*=gvParamters] .dellink").click(function () {
        //参量UID和参量编码
        var $dellink = $(this);
        var measurepointparamuid = $dellink.attr("value");
        
        var params = new Array();
        params.push({ "Measurepointparamuid": measurepointparamuid });
        var data = JSON.stringify({ "funname": "DeleteMeasurepointparam", "data": params });
        $.post('../../services/PostAjaxData.ashx', data, function (result) {
            if (result == "True") {
                $dellink.parent().parent().remove();
            }
        });


    });



    //点击参量编辑链接，显示编辑对话框
    $("[id*=gvParamters] .editlink").click(function () {

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
        $("#measurepointparamuid").val(measurepointparamuid);


        $.getJSON('../../services/GetAjaxData.ashx', { "funname": "GetMeasurePointParam", "measurepointparamuid": measurepointparamuid }, function (data) {


            //console.log(data);

            $("#txtUpperwarning").val(data.Upperwarning);
            $("#txtLowerwarning").val(data.Lowerwarning);
            $("#txtUpperaction").val(data.Upperaction);
            $("#txtLoweraction").val(data.Loweraction);

            $("[id*=ddlAbbreviation]").val(data.Abbreviation);
            $("#ddlIsMainParam").val(data.IsMainParam.toString());
            $("#ddlIsCalculate").val(data.IsCalculate.toString());
            $("#ddlVisabled").val(data.Visabled.toString());
            $("#txtDisplaysequence").val(data.Displaysequence.toString());
        });



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
        console.log("save setting");

        //定义变量并赋值
        var pointnum = $("[id*=ddlPointNum]").val();
        var measureunitid = $("[id*=ddlMeasureUnitId]").val();
        var upperwarning = $("#txtUpperwarning").val();
        var lowerwarning = $("#txtLowerwarning").val();
        var upperaction = $("#txtUpperaction").val();
        var loweraction = $("#txtLoweraction").val();
        var Abbreviation = $("[id*=ddlAbbreviation]").val();
        var IsMainParam = $("#ddlIsMainParam").val();
        var IsCalculate = $("#ddlIsCalculate").val();
        var Visabled = $("#ddlVisabled").val();
        var Displaysequence = $("#txtDisplaysequence").val();

        var measurePointParamInfo = { "Measurepointparamuid": $("#measurepointparamuid").val(), "Pointnum": pointnum, "Measureunitid": measureunitid, "Lowerwarning": lowerwarning, "Loweraction": loweraction, "Upperwarning": upperwarning, "Upperaction": upperaction, "Abbreviation": Abbreviation, "IsMainParam": IsMainParam, "IsCalculate": IsCalculate, "Visabled": Visabled, "Displaysequence": Displaysequence };

        //console.log(measurePointParamInfo);

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