
/**
* 系统配置
*/
$(function () {

    //保存子系统信息
    $("#btnSaveSystemItem").click(function () {
        var code = $("#Code").val();
        var Name = $("#Name").val();
        var Description = $("#Description").val();
        var StructImage = $("#StructImage").val();
        var StructImageWidth = $("#StructImageWidth").val();
        var StructImageHeight = $("#StructImageHeight").val();

        var subsystem = { "Code": code, "Name": name, "Description": Description, "StructImage": StructImage, "StructImageWidth": StructImageWidth, "StructImageHeight": StructImageHeight }
        var data = JSON.stringify({ "funname": "SaveSystemConfig", "data": subsystem });

        $.post("../../services/PostAjaxData.ashx", data, function (result) {

        });

        //

    });


    $(".editlink").click(function () {
        var code = $(this).attr("id");
        $.getJSON("../../services/GetAjaxData.ashx", { "funname": "GetSystemItemInfo", "code": code }, function (data) {
            $("#code").val(data.Code);
            $("#Name").val(data.Name);
        });


    });


});