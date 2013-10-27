$(function () {

    $(".minute #startdate").val(Date.today().add(-1).toString("yyyy-MM-dd HH:ss"));
    $(".minute #enddate").val(Date.today().toString("yyyy-MM-dd HH:ss"));

    $(".minute #startdate").change(function () {
        var startdate = $(".minute #startdate").val();
        $(".minute #enddate").val(Date.parse(startdate).add(1).toString("yyyy-MM-dd HH:mm"));
    });

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

    //历史


    $(".history .startdate").click(function () {

        WdatePicker({ lang: 'zh-cn', dateFmt: 'yyyy-MM-dd', maxDate: '%y-%M-{%d} 00:00' })

    });

    $(".history .enddate").click(function () {

        WdatePicker({ lang: 'zh-cn', dateFmt: 'yyyy-MM-dd', maxDate: '%y-%M-{%d}' })

    });



    //每日数据
    $(".day #btnQuery").click(function () {
        GetMeasurements(1);
    });

    //分钟数据
    $("#btnMinuteQuery").click(function () {
        console.log("minute");
        var pointnum = $("#pointnum").val();
        var startdate = $(".minute #startdate").val();
        var endate = $(".minute #enddate").val();
        GetMinuteData(pointnum, startdate, endate, 1)
    });

    $("#minutepager .page").on("click", function () {
        console.log("pager");
        var pointnum = $("#pointnum").val();
        var startdate = $(".minute #startdate").val();
        var endate = $(".minute #enddate").val();
        GetMinuteData(pointnum, startdate, endate, parseInt($(this).attr('page')))
    });

    //小时数据
    $("#btnHourQuery").click(function () {

        var pointnum = $("#pointnum").val();
        var startdate = $(".hour #startdate").val();
        var endate = $(".hour #enddate").val();

        GetHourData(pointnum, startdate, endate, 1)
    });

    $("#hourpager .page").on("click", function () {
        console.log("pager");
        var pointnum = $("#pointnum").val();
        var startdate = $(".hour #startdate").val();
        var endate = $(".hour #enddate").val();
        GetMinuteData(pointnum, startdate, endate, parseInt($(this).attr('page')))
    });

    //小时数据
    $("#btnDayQuery").click(function () {

        var pointnum = $("#pointnum").val();
        var startdate = $(".day #startdate").val();
        var endate = $(".day #enddate").val();

        GetDayData(pointnum, startdate, endate, 1)
    });

    $("#daypager .page").on("click", function () {
        console.log("pager");
        var pointnum = $("#pointnum").val();
        var startdate = $(".day #startdate").val();
        var endate = $(".day #enddate").val();
        GetMinuteData(pointnum, startdate, endate, parseInt($(this).attr('page')))
    });





    $("#btnHistoryQuery").click(function () {

        var type = $('input:radio[name=datetype]:checked').val();
        var pointnum = $("#pointnum").val();
        var startdate = $(".history #startdate").val();
        var endate = $(".history #enddate").val();
        if (type == "MINUTE") {
            GetMinuteChart(pointnum, startdate, endate, 1);
        }


    });

    $('input:radio[name=datetype]').click(function () {
        var val = $('input:radio[name=datetype]:checked').val();
    });

});

function OnFail(result) {
    console.log(result);
}

//获取分钟数据
function GetMinuteData(pointnum, startdate, enddate, pageindex) {

    $.ajax({
        type: "GET",
        url: "RealtimeParam.ashx",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: {"pointnum":pointnum, "startdate": startdate, "enddate": enddate, "pageindex": pageindex,"type":"MINUTE"},
        success: OnSuccessForMinute,
        error: OnFail
    });
}

function OnSuccessForMinute(response) {

   // console.log(response);
    var measurements = response.List;

    var row = $("[id*=gvMinuteMeasurement] tr:last-child").clone(true);
    $("[id*=gvMinuteMeasurement] tr").not($("[id*=gvMinuteMeasurement] tr:first-child")).remove();


    $.each(measurements, function (index, obj) {
       // console.log(obj);
        $("td", row).eq(0).html(Date.parse(obj.Time).toString("yyyy-MM-dd HH:mm"));
        $("td", row).eq(1).html(obj.SwTemperature);
        $("td", row).eq(2).html(obj.SwPressure);
        $("td", row).eq(3).html(obj.AfFlowinstant);
        $("td", row).eq(4).html(obj.AtFlow);
        $("td", row).eq(5).html(obj.AiDensity);

        $("[id*=gvMinuteMeasurement]").append(row);
        row = $("[id*=gvMinuteMeasurement] tr:last-child").clone(true);
    });

    var pager = response.PagerInfo;
    $("#minutepager").ASPSnippets_Pager({
        ActiveCssClass: "current",
        PagerCssClass: "pager",
        PageIndex: parseInt(pager.PageIndex),
        PageSize: parseInt(pager.PageSize),
        RecordCount: parseInt(pager.RecordCount)
    });
};


//获取小时数据
function GetHourData(pointnum, startdate, enddate, pageindex) {

    $.ajax({
        type: "GET",
        url: "RealtimeParam.ashx",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: { "pointnum": pointnum, "startdate": startdate, "enddate": enddate, "pageindex": pageindex, "type": "HOUR" },
        success: OnSuccessForHour,
        error: OnFail
    });

    // return false;
}

function OnSuccessForHour(response) {

    console.log(response);
    var measurements = response.List;

    var row = $("[id*=gvHourMeasurement] tr:last-child").clone(true);
    $("[id*=gvHourMeasurement] tr").not($("[id*=gvHourMeasurement] tr:first-child")).remove();


    $.each(measurements, function (index, obj) {
        // console.log(obj);
        $("td", row).eq(0).html(obj.Description); 
        $("td", row).eq(1).html($.trim(obj.Level));
        $("td", row).eq(2).html(Date.parse(obj.EndDate).toString("yyyy-MM-dd HH:mm"));
        $("td", row).eq(3).html(obj.StartValue);
        $("td", row).eq(4).html(obj.EndValue);
        $("td", row).eq(5).html(obj.DiffValue);

        $("[id*=gvHourMeasurement]").append(row);
        row = $("[id*=gvHourMeasurement] tr:last-child").clone(true);
    });

    var pager = response.PagerInfo;
    $("#hourpager").ASPSnippets_Pager({
        ActiveCssClass: "current",
        PagerCssClass: "pager",
        PageIndex: parseInt(pager.PageIndex),
        PageSize: parseInt(pager.PageSize),
        RecordCount: parseInt(pager.RecordCount)
    });
};




//获取每天数据
function GetDayData(pointnum, startdate, enddate, pageindex) {

    $.ajax({
        type: "GET",
        url: "RealtimeParam.ashx",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: { "pointnum": pointnum, "startdate": startdate, "enddate": enddate, "pageindex": pageindex, "type": "DAY" },
        success: OnSuccessForDay,
        error: OnFail
    });

    // return false;
}

function OnSuccessForDay(response) {

    console.log(response);
    var measurements = response.List;

    var row = $("[id*=gvDayMeasurement] tr:last-child").clone(true);
    $("[id*=gvDayMeasurement] tr").not($("[id*=gvDayMeasurement] tr:first-child")).remove();


    $.each(measurements, function (index, obj) {
        // console.log(obj);
        $("td", row).eq(0).html(obj.Description);
        $("td", row).eq(1).html($.trim(obj.Level));
        $("td", row).eq(2).html(Date.parse(obj.EndDate).toString("yyyy-MM-dd"));
        $("td", row).eq(3).html(obj.StartValue);
        $("td", row).eq(4).html(obj.EndValue);
        $("td", row).eq(5).html(obj.DiffValue);

        $("[id*=gvDayMeasurement]").append(row);
        row = $("[id*=gvDayMeasurement] tr:last-child").clone(true);
    });

    var pager = response.PagerInfo;
    $("#daypager").ASPSnippets_Pager({
        ActiveCssClass: "current",
        PagerCssClass: "pager",
        PageIndex: parseInt(pager.PageIndex),
        PageSize: parseInt(pager.PageSize),
        RecordCount: parseInt(pager.RecordCount)
    });
};






//获取每天数据
function GetMinuteChart(pointnum, startdate, enddate, pageindex) {

    $.ajax({
        type: "GET",
        url: "RealtimeParam.ashx",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: { "pointnum": pointnum, "startdate": startdate, "enddate": enddate, "pageindex": pageindex, "type": "MINUTE" },
        success: OnSuccessMinuteChart,
        error: OnFail
    });

    // return false;
}

function OnSuccessMinuteChart(response) {


    $('#container').highcharts({
        title: {
            text: 'Monthly Average Temperature',
            x: -20 //center
        },
        subtitle: {
            text: 'Source: WorldClimate.com',
            x: -20
        },
        xAxis: {
            categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']
        },
        yAxis: {
            title: {
                text: 'Temperature (°C)'
            },
            plotLines: [{
                value: 0,
                width: 1,
                color: '#808080'
            }]
        },
        tooltip: {
            valueSuffix: '°C'
        },
        legend: {
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'middle',
            borderWidth: 0
        },
        series: [{
            name: 'Tokyo',
            data: [7.0, 6.9, 9.5, 14.5, 18.2, 21.5, 25.2, 26.5, 23.3, 18.3, 13.9, 9.6]
        }, {
            name: 'New York',
            data: [-0.2, 0.8, 5.7, 11.3, 17.0, 22.0, 24.8, 24.1, 20.1, 14.1, 8.6, 2.5]
        }]
    });

}