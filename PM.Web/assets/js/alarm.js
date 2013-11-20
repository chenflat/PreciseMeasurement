/**
* 报警管理
* @author PING.CHEN
* @version 1.0  build20131120
*/
$(function () {

    var startdate, enddate, status;

    $(".alarm .startdate").val(Date.today().addDays(-30).toString("yyyy-MM-dd"));
    $(".alarm .enddate").val(Date.today().toString("yyyy-MM-dd"));

    $(".alarm .startdate").click(function () {
        WdatePicker({ lang: 'zh-cn', dateFmt: 'yyyy-MM-dd', maxDate: '%y-%M-{%d-1}' })
    });

    $(".alarm .enddate").click(function () {
        WdatePicker({ lang: 'zh-cn', dateFmt: 'yyyy-MM-dd', maxDate: '%y-%M-{%d+1}' })
    });

    getAlarmlogs(1);
    $(".btnAlarmQuery").click(function () {
        getAlarmlogs(1)
    });

    function getAlarmlogs(pageindex) {
        startdate = $(".alarm .startdate").val();
        enddate = $(".alarm .enddate").val();
        status = $(".alarm .status").val();
        var pointnum = "";
        if (typeof ($("#pointnum").val()) == 'undefined') {
            pointnum = "";
        } else {
            pointnum = $("#pointnum").val();
        }


        var ds = new Date(startdate);
        var de = new Date(enddate);

        startdate = ds.toString("yyyy-MM-dd");
        enddate = de.toString("yyyy-MM-dd 23:59:59");
        var path = CONTEXT_PATH + "services/GetAlarmlogs.ashx"
        $.ajax({
            type: "GET",
            url: path,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: { "startdate": startdate, "enddate": enddate, "pointnum": pointnum, "status": status, "orgid": ORGID, "pageindex": pageindex, "pagesize": 15 },
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
            $("td", row).eq(0).html(getAlarmType(obj.Alarmtype));
            $("td", row).eq(1).html(obj.Measurevalue);
            $("td", row).eq(2).html($.trim(obj.Almcomment));
            $("td", row).eq(3).html(new Date(obj.Logtime).toString("yyyy-MM-dd"));
            $("td", row).eq(4).html(new Date(obj.Acktime).toString("yyyy-MM-dd"));
            $("td", row).eq(5).html(obj.Ackoperatorname);
            $("td", row).eq(5).html("处理");


            $("[id*=gvAlarmData]").append(row);
            row = $("[id*=gvAlarmData] tr:last-child").clone(true);
        });

        var pager = response.PagerInfo;
        $("#alarmpager").ASPSnippets_Pager({
            ActiveCssClass: "current",
            PagerCssClass: "pager",
            PageIndex: parseInt(pager.PageIndex),
            PageSize: parseInt(pager.PageSize),
            RecordCount: parseInt(pager.RecordCount)
        });
    }

    $("#alarmpager").on("click", "a", function () {

        getAlarmlogs(parseInt($(this).attr('page')));
    });

    function getAlarmType(type) {
        switch (type) {
            case 1: return "低报警";
            case 2: return "超低报警";
            case 3: return "高报警";
            case 4: return "超高报警";
            default: return "";
        }
    }

});

