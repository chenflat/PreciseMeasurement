$(function () {



    $(".minute #startdate").click(function () {

        WdatePicker({ lang: 'zh-cn', dateFmt: 'yyyy-MM-dd HH:mm', maxDate: '%y-%M-{%d} 00:00' })

    });

    $(".minute #enddate").click(function () {

        WdatePicker({ lang: 'zh-cn', dateFmt: 'yyyy-MM-dd HH:mm', maxDate: '%y-%M-{%d}' })

    });

    //小时
    $(".hour #startdate").click(function () {

        WdatePicker({ lang: 'zh-cn', dateFmt: 'yyyy-MM-dd', maxDate: '%y-%M-{%d} 00:00' })

    });

    $(".hour #enddate").click(function () {

        WdatePicker({ lang: 'zh-cn', dateFmt: 'yyyy-MM-dd', maxDate: '%y-%M-{%d}' })

    });

    //天

    $(".day .startdate").click(function () {

        WdatePicker({ lang: 'zh-cn', dateFmt: 'yyyy-MM-dd', maxDate: '%y-%M-{%d} 00:00' })

    });

    $(".day .enddate").click(function () {

        WdatePicker({ lang: 'zh-cn', dateFmt: 'yyyy-MM-dd', maxDate: '%y-%M-{%d}' })

    });


    //每日数据
    $(".day #btnQuery").click(function () {
        GetMeasurements(1);
    });

    //分钟数据
    $("#btnMinuteQuery").click(function () {
        console.log("minute");
        var pointnum = $(".minute .pointnum").val();
        var startdate = $(".minute #startdate").val();
        var endate = $(".minute #enddate").val();
        GetMinuteMeasurementData(pointnum,startdate, endate, 1)
    });

});


function GetMinuteMeasurementData(pointnum,startdate,enddate,pageindex) {
    $.ajax({
        type: "POST",
        url: "RealtimeParam.ashx",
        contentType: "application/json; charset=utf-8",
        data: {"pointnum":pointnum, "startdate": startdate, "enddate": enddate, "pageindex": pageindex },
        dataType: "json",
        success: OnSuccess,
        error: OnFail
    });

    return false;
}


$(".Pager .page").live("click", function () {
    console.log('分页');
    console.log(parseInt($(this).attr('page')));
    console.log("minute");
    var pointnum = $(".minute .pointnum").val();
    var startdate = $(".minute #startdate").val();
    var endate = $(".minute #enddate").val();
    GetMinuteMeasurementData(pointnum, startdate, endate, parseInt($(this).attr('page')))

});

function OnFail(result) {
    console.log(result);
}

function OnSuccess(response) {

    console.log(response);
    var measurements = response.List;
    var row = $("[class*=minutereport] tr:last-child").clone(true);
    $("[class*=dayreport] tr").not($("[class*=minutereport] tr:first-child")).remove();


    $.each(measurements, function (index, obj) {

        $("td", row).eq(0).html(obj.MEASURETIME);
        $("td", row).eq(1).html(obj.SW_TEMPERATURE);
        $("td", row).eq(2).html(obj.SW_PRESSURE);
        $("td", row).eq(3).html(obj.AF_FLOWINSTANT);
        $("td", row).eq(4).html(obj.AT_FLOW);
        $("td", row).eq(5).html(obj.AI_DENSITY);

        $("[class*=minutereport]").append(row);
        row = $("[class*=minutereport] tr:last-child").clone(true);
    });

    var pager = response.PagerInfo;
    $(".minutepager .Pager").ASPSnippets_Pager({
        ActiveCssClass: "current",
        PagerCssClass: "pager",
        PageIndex: parseInt(pager.PageIndex),
        PageSize: parseInt(pager.PageSize),
        RecordCount: parseInt(pager.RecordCount)
    });
};