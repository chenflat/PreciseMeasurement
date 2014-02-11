/**
* 统计报表JS
* @author PING.CHEN
* @version 1.0 build20131121
*/
$(function () {

    $("#btnDelete").hide();

    //为开始、结束时间绑定日历控制
    $(".startdate").click(function () {
        WdatePicker({ lang: 'zh-cn', dateFmt: 'yyyy-MM-dd', maxDate: '%y-%M-{%d}' })
    });

    $(".enddate").click(function () {
        WdatePicker({ lang: 'zh-cn', dateFmt: 'yyyy-MM-dd', maxDate: '%y-%M-{%d}' })
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

        $($reportrows[i]).find("td").eq(0).text($($reportrows[i]).find("td").eq(0).text().substr(0, 10));
    }



    var path = window.location.pathname;
    if (path == '/report/custom.aspx') {
        $('[id$=btnExport]').attr({ "disabled": true })

        initSettings();
    } else if (path == '/report/month.aspx') {
        $reportrows = $("[id*=gvMonthReport] tr");
        for (var j = 1; j < $reportrows.length; j++) {
            $($reportrows[j]).find("td").eq(0).attr("width", "100px");
            $($reportrows[j]).find("td").eq(0).text(($($reportrows[j]).find("td").eq(0).text()).substr(0, 7));
        }
    }

    //初始化设置
    function initSettings() {

        $(".bs-sidenav .active").on('click', function () {
            $(this).children('ul').toggle(300);
        });
    }

    /**
    * 创建自定义设置
    */
    $("#CreateSetting").click(function () {
        //清空设置名称，显示设置窗口
        $("#SettingName").val("");
        $('#myModal').modal('show');
        $("#btnDelete").hide();
    });

    /**
    * 获取指定设置名称的设置定义项
    * @param name 设置项名称
    */
    function GetReportSettingByName(name) {

        $("#container-measurepoints").html("")

        //设置名称
        $("#SettingName").val(name);

        //获取设置数据
        $.getJSON('../services/GetAjaxData.ashx', { "funname": "GetReportSetting", "userid": USERID, "orgid": ORGID, "settingname": name }, function (data) {
            var points = [];
            //遍历数组
            $.each(data, function (index, obj) {
                if ($.trim(obj.SettingName) == name) {
                    points.push('<li id="' + obj.Pointnum + '"><span class="desc">' + obj.Description + '</span><div class="pull-right">×</div></li>');
                }
            });

            $("#container-measurepoints").append(points.join(""));
        });
    }

    /**
    * 编辑自定义设置
    */
    $("#SettingNameList").on("click", "li", function () {
        $("#btnDelete").show();
        GetReportSettingByName($(this).text());
        $('#myModal').modal('show');
    });

    /**
    * 动态添加计量点到列表
    */
    $(".measurepoint-list li").click(function () {

        $("#message").empty();
        var text = $(this).text();
        var id = $(this).attr("id");
        var li = "<li id='" + id + "'>" + text + "  <input type='hidden' value='' /> <i class='.glyphicon .glyphicon-remove'></i></li>";
        if (!hasPointElement(text)) {
            $("#container-measurepoints").append(li);
        }
    });

    //判断是否存在计量点元素
    function hasPointElement(text) {
        var ret = false;
        $("#container-measurepoints li").each(function (index, obj) {
            if ($(obj).text() == text) {
                ret = true;
            }
        });
        return ret;
    }


    //移除计量点
    $("#container-measurepoints").on("click", "li", function () {
        $(this).remove();
    });

    //保存设置
    $("#btnSaveSetting").click(function () {
        var SettingName = $("#SettingName").val();
        var settings = getSelectPoints();
        if (settings.length == 0 || SettingName.length == 0) {
            var message = "<div class=\"alert alert-warning alert-dismissable\">" +
                "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>" +
                "<strong>提示!</strong> 请选择计量点或填写设置名称" +
                "</div>";

            $("#message").append(message);
            return;
        }

        if (settings.length == 0)
            return;

        var data = JSON.stringify({ "funname": "SaveReportSetting", "data": settings })

        $.post("../services/PostAjaxData.ashx", data, function (result) {
            if (result == "True") {
                var li = "<li><a href=\"#\">" + $("#SettingName").val() + "</a></li>";

                console.log(li);

                $("#SettingNameList").append(li);
                $("#CreateSettingNameList").append(li);

            }
        });

        $('#myModal').modal('hide');
    });

    //获取已选择的测点
    function getSelectPoints() {
        var points = new Array();
        $("#container-measurepoints li").each(function (index, obj) {
            var p = { "Pointnum": $(obj).attr("id"), "Description": $.trim($(obj).text()), "SettingName": $.trim($("#SettingName").val()), "Userid": USERID, "Orgid": ORGID };
            points.push(p);
        });

        return points;
    }

    function getSelectPointStrings() {
        var pointnums = getSelectPoints();
        var ret = "";
        for (var i = 0; i < pointnums.length; i++) {
            if (ret.length > 0)
                ret += ",";
            ret += pointnums[i].num;
        }
        return ret;
    }

    $("#btnDelete").click(function () {
        var settingname = $("#SettingName").val();
        var data = JSON.stringify({ "funname": "DeleteReportSetting", "settingname": settingname, "userid": USERID, "orgid": ORGID });
        $.post("../services/PostAjaxData.ashx", data, function (data) {
            if (data == "True") {
                $.each($("#SettingNameList li"), function (index, obj) {
                    if ($(this).text() == settingname) {
                        $(this).remove();
                    }
                });

                $.each($("#CreateSettingNameList li"), function (index, obj) {
                    if ($(this).text() == settingname) {
                        $(this).remove();
                    }
                });
            }
        });

    });


    /**
    * 生成自定义报表
    */
    $("#btnCustomQuery").click(function () {

        //取第一个设置为默认值
        var defSettingName = $.trim($("#settingNameList").val());
        //给隐藏域赋值：
        $('[id$=hdnSettingName]').val(defSettingName);
        //创建自定义报表
        CreateCustomReport(defSettingName);

    });

    /**
    * 选择设置创建报表
    */
    $("#CreateSettingNameList li").click(function () {

        var settingName = $(this).text();
        $('[id$=hdnSettingName]').val(settingName);
        $('[id$=btnExport]').attr("disabled", false);

        CreateCustomReport(settingName);
    });

    /**
    * 创建自定义报表
    * @param settingName 设置名称
    */
    function CreateCustomReport(settingName) {

        //获取设置数据
        $.getJSON('../services/GetAjaxData.ashx', { "funname": "GetReportSetting", "userid": USERID, "orgid": ORGID, "settingname": settingName }, function (data) {

            var strPointnums = "";
            $.each(data, function (index, obj) {
                if (strPointnums.length > 0)
                    strPointnums += ",";
                strPointnums += obj.Pointnum;
            });

            if (strPointnums == "")
                return;

            var startdate = $(".startdate").val();
            var enddate = $(".enddate").val();

            var ds = new Date(startdate);
            var de = new Date(enddate);

            startdate = ds.toString("yyyy-MM-dd");
            enddate = de.toString("yyyy-MM-dd 23:59:59");

            $.ajax({
                type: "GET",
                url: "MeasurementReport.ashx",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: { "pointnum": strPointnums, "startdate": startdate, "enddate": enddate, "type": "Day", "formula": "", "iscustom": "true" },
                success: OnSuccessCustomReport,
                error: OnFail
            });

        });


    }



    function OnSuccessCustomReport(response) {

        if (response.length == 0)
            return;

        //清空表格式数据
        var th = "", td = "";
        $("#gvCustomReport thead tr").html("");
        $("#gvCustomReport tbody").html("");

        //动态构造表头
        $.each(response[0], function (key, val) {
            console.log("key:" + key);
            th += "<th>" + key + "</th>";
        });
        $("#gvCustomReport thead tr").append(th);
        //动态构造表格内容
        $.each(response, function (index, obj) {
            td += "<tr>"
            $.each(obj, function (key, val) {
                if (key == "统计日期") {
                    td += "<td>" + new Date(val).toString('yyyy-MM-dd') + "</td>";
                } else {
                    td += "<td>" + val + "</td>";
                }
            });
            td += "</tr>"
        });
        $("#gvCustomReport tbody").append(td);


    }



});

/**
 * 获取所有报表数据
 * @param pageindex 当前页次
 */
function getAllReportData(pageindex) {
    var startdate = $(".startdate").val();
    var enddate = $(".enddate").val();
    var level = $(".level").val();

    var ds = new Date(startdate);
    var de = new Date(enddate);

    startdate = ds.toString("yyyy-MM-dd");
    enddate = de.toString("yyyy-MM-dd 23:59:59");
    $.ajax({
        type: "GET",
        url: "MeasurementReport.ashx",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: { "startdate": startdate, "enddate": enddate, "level": level, "pageindex": pageindex, "type": "All" },
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
    if (measurements.length == 0)
        return;

    var row = $("[id*=gvMeasurementReport] tr:last-child").clone(true);
    $("[id*=gvMeasurementReport] tr").not($("[id*=gvMeasurementReport] tr:first-child")).remove();

    $.each(measurements, function (index, obj) {
        // console.log(obj);
        $("td", row).eq(0).html(obj.Description);
        $("td", row).eq(1).html(toRoman(obj.Level) + " 级");
        $("td", row).eq(2).html(new Date(obj.Starttime).toString("yyyy-MM-dd"));
        $("td", row).eq(3).html(obj.StartValue);
        $("td", row).eq(4).html(new Date(obj.Endtime).toString("yyyy-MM-dd"));
        $("td", row).eq(5).html(obj.LastValue);
        $("td", row).eq(6).html(obj.Value);

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
}

function initQueryDate () {
    var $startdate = $(".startdate");
    var $enddate = $(".enddate");

    if ($startdate.val() == '') {
        $enddate.val(Date.today().toString("yyyy-MM-dd"));
        $startdate.val(Date.today().addDays(-8).toString("yyyy-MM-dd"));
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

    var ds = new Date(startdate);
    var de = new Date(enddate);

    startdate = ds.toString("yyyy-MM-dd");
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