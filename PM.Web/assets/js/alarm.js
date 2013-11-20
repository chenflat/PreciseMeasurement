/**
* 报警管理
* @author PING.CHEN
* @version 1.0  build20131120
*/
$(function () {

    var startdate, enddate, status;

    $(".btnQuery").click(function () {

    });

    function getAlarmlogs(pageindex) {
        startdate = $(".startdate").val();
        enddate = $(".enddate").val();
        status = $(".status").val();

        var ds = new Date(startdate);
        var de = new Date(enddate);

        startdate = ds.toString("yyyy-MM-dd");
        enddate = de.toString("yyyy-MM-dd 23:59:59");

        $.ajax({
            type: "GET",
            url: "MeasurementReport.ashx",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: { "startdate": startdate, "enddate": enddate, "pageindex": pageindex, "type": "ALL" },
            success: OnSuccess,
            error: OnFail
        });
    }

    function OnFail(result) {
        console.log(result);
    }

    function OnSuccess(response) {

        var alarmlogs = response.List;
        if (alarmlogs.length == 0)
            return;

        var row = $("[id*=gvAlarmData] tr:last-child").clone(true);
        $("[id*=gvAlarmData] tr").not($("[id*=gvAlarmData] tr:first-child")).remove();

        $.each(alarmlogs, function (index, obj) {
            // console.log(obj);
            $("td", row).eq(0).html(obj.Measurevalue);
            $("td", row).eq(1).html($.trim(obj.Almcomment));
            $("td", row).eq(2).html(new Date(obj.Logtime).toString("yyyy-MM-dd"));
            $("td", row).eq(3).html(new Date(obj.Acktime).toString("yyyy-MM-dd"));
            $("td", row).eq(4).html(obj.Ackoperatorname);
            $("td", row).eq(5).html("处理");

            $("[id*=gvAlarmData]").append(row);
            row = $("[id*=gvAlarmData] tr:last-child").clone(true);
        });

        var pager = response.PagerInfo;
        $("#pager").ASPSnippets_Pager({
            ActiveCssClass: "current",
            PagerCssClass: "pager",
            PageIndex: parseInt(pager.PageIndex),
            PageSize: parseInt(pager.PageSize),
            RecordCount: parseInt(pager.RecordCount)
        });
    }

});

