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


    $(".day #btnQuery").click(function () {
        GetMeasurements(1);
    });

    //  GetCustomers(1);

});

$(".dayreportpager .page").on("click", function () {
    GetMeasurements(parseInt($(this).attr('page')));
});
function GetMeasurements(pageIndex) {
    $.ajax({
        type: "POST",
        url: "RealtimeParam.ashx",
       // data: "{pageIndex: ' + pageIndex + '}",
       // contentType: "application/json; charset=utf-8",
      //  dataType: "json",
        success: OnSuccess,
        failure: function (response) {
            console.log(response);
        },
        error: function (response) {
          //  alert($(response).text());
           console.log(response.responseText);
        }
    });
}

function OnSuccess(response) {
    var xmlDoc = $.parseXML(response);

    console.log(response);

    var xml = $(xmlDoc);
    var measurements = xml.find("Measurement");
    var row = $("[class*=dayreport] tr:last-child").clone(true);
    $("[class*=dayreport] tr").not($("[class*=dayreport] tr:first-child")).remove();

    console.log(xmlDoc);
    console.log(measurements);

    $.each(measurements, function () {
        var customer = $(this);
        $("td", row).eq(0).html($(this).find("MEASURETIME").text());
        $("td", row).eq(1).html($(this).find("SW_TEMPERATURE").text());
        $("td", row).eq(2).html($(this).find("SW_PRESSURE").text());
        $("td", row).eq(3).html($(this).find("AF_FLOWINSTANT").text());
        $("td", row).eq(4).html($(this).find("AT_FLOW").text());
        $("td", row).eq(5).html($(this).find("AI_DENSITY").text());
        $("[class*=dayreport]").append(row);
        row = $("[class*=dayreport] tr:last-child").clone(true);
    });
    var pager = xml.find("Pager");

    console.log(pager);

    $(".dayreportpager").ASPSnippets_Pager({
        ActiveCssClass: "current",
        PagerCssClass: "pager",
        PageIndex: parseInt(pager.find("PageIndex").text()),
        PageSize: parseInt(pager.find("PageSize").text()),
        RecordCount: parseInt(pager.find("RecordCount").text())
    });
};