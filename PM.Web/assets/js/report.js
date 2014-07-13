/**
* 统计报表JS
* @author PING.CHEN
* @version 1.0 build20131121
*/
$(function () {

    $("#btnDelete").hide();

    //为开始、结束时间绑定日历控制
    $(".startdate").click(function () {
        WdatePicker({ lang: 'zh-cn', dateFmt: 'yyyy-MM-dd HH:00', maxDate: '%y-%M-{%d-1} 08:00' })
    });

    $(".enddate").click(function () {
        WdatePicker({ lang: 'zh-cn', dateFmt: 'yyyy-MM-dd HH:00', maxDate: '%y-%M-{%d-1} 08:00' })
    });

    //时期为年时绑定日历格式
    $(".year").click(function () {
        WdatePicker({ lang: 'zh-cn', dateFmt: 'yyyy' })
    });
    initQueryDate();

    //查询事件
    $("#btnQuery").click(function () {
        getAllReportData(1);
    });

    //分页事件
    $("#pager").on("click", "a", function () {
        getAllReportData(parseInt($(this).attr('page')));
    });

    $("#btnDayQuery").click(function () {
        console.log('getDayReportData');
        getDayReportData();
    });

    $("#btnWeekQuery").click(function () {
        getWeekReportData();
    });

    $("#btnMonthQuery").click(function () {
        getMonthReportData();
    });

    //格式化日期格式
    var $reportrows = $("[id*=gvReport] tr");
    for (var i = 1; i < $reportrows.length; i++) {
        $($reportrows[i]).find("td").eq(0).attr("width", "100px");
        var index = $($reportrows[i]).find("td").eq(0).text().indexOf(" ");
        var d = $($reportrows[i]).find("td").eq(0).text().substr(0, index);
        d = d.replace("-","/").replace("-","/");
        //console.log(d);

        $($reportrows[i]).find("td").eq(0).text(d);
    }



    var path = window.location.pathname;
    if (path == '/report/custom.aspx') {
        $('[id$=btnExport]').attr({ "disabled": true })

        initSettings();
    } else if (path == '/report/month.aspx') {
        $reportrows = $("[id*=gvMonthReport] tr");
        for (var j = 1; j < $reportrows.length; j++) {
            $($reportrows[j]).find("td").eq(0).attr("width", "100px");

            var date = $($reportrows[j]).find("td").eq(0).text();
            

            /*var index = $($reportrows[j]).find("td").eq(0).text().lastIndexOf("-");
            var d = $($reportrows[j]).find("td").eq(0).text().substr(0, index);

            d = d.replace("-","/").replace("-","/");*/

            $($reportrows[j]).find("td").eq(0).text(moment(date).format("YYYY-MM"));

        }
    }

    //初始化设置
    function initSettings() {

        $(".bs-sidenav .active").on('click', function () {
            $(this).children('ul').toggle(300);
        });
    }

    


/**
 * 获取所有报表数据
 * @param pageindex 当前页次
 */
function getAllReportData(pageindex) {
    var startdate = $(".startdate").val(),
        enddate = $(".enddate").val(),
        level = $(".level").val(),
        orgid = $(".orgid").val(),
        pointnum = "",
        type = "All";

    $(".startdate").attr('title',"开始日期："+ startdate);
    $(".enddate").attr('title',"结束日期："+ enddate);

    $.ajax({
        type: "GET",
        url: "../services/GetAjaxData.ashx",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        beforeSend: function() {
            $("#dvProgress").show();
        },
        data: { "funname": "GetMeasurementReport", "pointnum":pointnum,"startdate": startdate, "enddate": enddate, "level": level,"orgid":orgid, "pageindex": pageindex, "type": type },
        success: OnSuccess,
        error: OnFail
    });
}



function OnFail(result) {
    console.log(result);
}

/**
 * 处理报表数据
 */
function OnSuccess(response) {
   // console.log(response);
    var measurements = response.List;

    var row = $("[id*=gvMeasurementReport] tr:last-child").clone(true);
    $("[id*=gvMeasurementReport] tr").not($("[id*=gvMeasurementReport] tr:first-child")).remove();

    //没有查询结果时，自动添加一行空数据
    if (measurements.length == 0) {
        var obj = {
            Description: "",
            Endtime: "",
            LastValue: 0,
            Level: "",
            Measuretime: "",
            Measureunitid: "",
            Pointnum: "",
            StartValue: 0,
            Starttime: "",
            Value: 0
        }
        measurements.push(obj);
        //return;
    }


    $.each(measurements, function (index, obj) {
       //  console.log(obj);
        $("td", row).eq(0).html(obj.Description);
        $("td", row).eq(1).html(toRoman(obj.Level) + " 级");
        $("td", row).eq(2).html(moment(obj.Starttime).format("YYYY-MM-DD HH:mm"));
        $("td", row).eq(3).html(obj.StartValue);
        $("td", row).eq(4).html(moment(obj.Endtime).format("YYYY-MM-DD HH:mm"));
        $("td", row).eq(5).html(obj.LastValue);
        $("td", row).eq(6).html(obj.Value);
        //判断是否空数据，如果是则清空所有内容
        if (obj.Description == "") {
            $("td", row).html('');
        }
        $("[id*=gvMeasurementReport]").append(row);
        row = $("[id*=gvMeasurementReport] tr:last-child").clone(true);
    });

    var pager = response.PagerInfo;
    $("#pager").ASPSnippets_Pager({
        ActiveCssClass: "current",
        PagerCssClass: "pager",
        PageIndex: parseInt(pager.PageIndex),
        PageSize: parseInt(pager.PageSize),
        RecordCount: parseInt(pager.RecordCount)
    });
    $("#dvProgress").hide();
}

function initQueryDate () {
    var $startdate = $(".startdate");
    var $enddate = $(".enddate");

    if ($startdate.val() == '') {
        
        $enddate.val(Date.today().addDays(-1).toString("yyyy-MM-dd 08:00"));
        $startdate.val(Date.today().addDays(-8).toString("yyyy-MM-dd 08:00"));
    }

    if (window.location.pathname == '/report/default.aspx' || window.location.pathname == '/report/') {
        getAllReportData(1);
     }
}

/**
* 获取日报数据
*/
function getDayReportData() {
    var startdate = $(".startdate").val();
    var enddate = $(".enddate").val();

    //startdate = moment(startdate).format('YYYY-MM-DD 00:00:00');
    var ds = new Date(startdate);
    var de = new Date(enddate);

    startdate = ds.toString("yyyy-MM-dd 00:00:00");
    enddate = de.toString("yyyy-MM-dd 23:59:59");
    $.ajax({
        type: "GET",
        url: "MeasurementReport.ashx",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: { "startdate": startdate, "enddate": enddate, "pageindex": pageindex, "type": "All" },
        success: OnSuccess,
        error: OnFail
    });
}

function getWeekReportData() {

}

function getMonthReportData() {

}


function toRoman(num) {
    if (isNaN(num)) return num;

    var a = [["", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX"],
                          ["", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XCC"],
                          ["", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM"]];
    var roman = "";
    var t = 0;
    for (var m = 0, i = 1000; m < 3; m++, i /= 10) {
        t = Math.floor((num % i) / (i / 10));
        roman += a[2 - m][t];
    }
    return roman;
}


$(window).load(function() {

    var contentHeight = $(window).height() - $(".header").height() - $("#toolbars").height();
    $("#reportContainer").width($("#contents").width());
    //$("#dayReport").height(contentHeight);
    $("#reportContainer").mCustomScrollbar({
        horizontalScroll: true,
        scrollButtons: {
            enable: true
        },
        theme: "dark-thin"
    });

});

});