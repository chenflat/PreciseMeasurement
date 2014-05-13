/**
* 统计报表JS
* @author PING.CHEN
* @version 1.0 build20131121
*/
$(function () {

    $("#btnDelete").hide();

    //为开始、结束时间绑定日历控制
    $(".startdate").click(function () {
        WdatePicker({ lang: 'zh-cn', dateFmt: 'yyyy-MM-dd', maxDate: '%y-%M-{%d-1}' })
    });

    $(".enddate").click(function () {
        WdatePicker({ lang: 'zh-cn', dateFmt: 'yyyy-MM-dd', maxDate: '%y-%M-{%d-1}' })
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

            var index = $($reportrows[j]).find("td").eq(0).text().lastIndexOf("-");
            var d = $($reportrows[j]).find("td").eq(0).text().substr(0, index);
            d = d.replace("-","/").replace("-","/");

            $($reportrows[j]).find("td").eq(0).text(d);

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
        $("#formula").val("");
        $(".customlist").html("");
        $("#action").val("create");
       // $("#btnDelete").hide();
    });

    /**
    * 获取指定设置名称的设置定义项
    * @param name 设置项名称
    */
    function GetReportSettingByName(name) {

        $("#container-measurepoints").html("")

        //设置名称
        $("#SettingName").val(name);
        var formula = "";

        console.log("name:" + name);

        //获取设置数据
        $.getJSON('../services/GetAjaxData.ashx', { "funname": "GetReportSetting", "userid": USERID, "orgid": ORGID, "settingname": name }, function (data) {
            var points = [];
            //遍历数组
            var i = 0;
            $.each(data, function (index, obj) {
                if ($.trim(obj.SettingName) == name) {
                    
                    var li = '<li id="' +  obj.Pointnum + '" class="span12"><div class="desc  ">' + obj.Description + '</div><input type="text" name="formula" class="formula" Value="'+ obj.Formula +'" size="60" title="请输入计算公式" placeholder="请输入计算公式" /><a href="#" class="pull-right removeSetting">×</a></li>';
                    points.push(li);
                    i++;
                }
            });

            $("#container-measurepoints").append(points.join(""));
        });
    }


    /**
     * 编辑自定义报表设置
     */
    $("#SettingNameList").on("click",".editSetting",function(){
        $("#action").val("edit");
         $("#message").empty();
        var name = $(this).attr("itemname");

        console.log("name:"+ name);

        GetReportSettingByName(name);
         $('#myModal').modal('show');
    })

    /**
     * 删除自定义报表设置
     */
    $("#SettingNameList").on("click", ".delSetting", function() {
        var name = $(this).attr("itemname");

        var ret = confirm("删除数据不可恢复，确定要删除名称为" + name + "的报表吗？");
        if (ret) {

            var data = JSON.stringify({
                "funname": "DeleteReportSetting",
                "settingname": name,
                "userid": USERID,
                "orgid": ORGID
            });
            $.post("../services/PostAjaxData.ashx", data, function(data) {
                if (data == "True") {
                    $.each($("#SettingNameList .settingitem"), function(index, obj) {
                        var thisName = $.trim($(this).text());
                        if (thisName == name) {
                            $(this).remove();
                        }
                    });
                };
            });
        }
    });




    $(".formula").on('click', function(event) {

        console.log('ss');

        event.preventDefault();
       
        var div = $(".operators");  

            console.log($(div));

         if(div.is(":hidden")){  
             div.show();  
                
             div.css("left",document.body.scrollLeft+event.clientX+1);  
             div.css("top",document.body.scrollLeft+event.clientY+10);  
             div.css("background-color","#EFF7FE");  
         }else{  
            div.hide();   
         }

    });




    /**
    * 动态添加计量点到列表
    */
    $(".measurepoint-list li").click(function () {

        $("#message").empty();
        var text = $(this).text();
        var id = $(this).attr("id");
        //添加到列表
        var li = '<li id="' + id + '" class="span12"><div class="desc  ">' + text + '</div><input type="text" name="formula" class="formula" Value="'+ id +'" size="60" title="请输入计算公式" placeholder="请输入计算公式" /><a href="#" class="pull-right removeSetting">×</a></li>';
        if (!hasPointElement(id)) {
            $("#container-measurepoints").append(li);
        }
    });

    //运算符操作
    $(".operators button").click(function(){
        var operator = $(this).text();
        var formula = $("#formula").val();
        $("#formula").val(formula+operator);

    });



    //判断计量点元素是否已经存在已选择的列表中
    function hasPointElement(id) {
        var ret = false;
        $("#container-measurepoints li").each(function (index, obj) {
            if ($(obj).attr("id") == id) {
                ret = true;
            }
            //console.log($(obj).attr("id"));
        });
        return ret;
    }


    //移除计量点
    $("#container-measurepoints").on("click", ".removeSetting", function () {
        $(this).parent().remove();
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
                var html = "<div class=\"settingitem\"><a href=\"#\" class=\"customQuery\" itemname=\""+ $("#SettingName").val() +"\">"+ $("#SettingName").val() +"</a> "
                    + "<span class=\"pull-right\"> "
                    + "<a href=\"#\" class=\"editSetting\" itemname=\""+ $("#SettingName").val() +"\"><i class=\"glyphicon glyphicon-pencil\"></i></a> "
                    + "<a href=\"#\" class=\"delSetting\"  itemname=\""+ $("#SettingName").val() +"\"><i class=\"glyphicon glyphicon-remove\"></i></a>"
                    + "</div>";


                 console.log("action:"+ $("#action").val());
                if($("#action").val()=="create") {
                    $("#SettingNameList").append(html);
                }
               
            }
        });

        $('#myModal').modal('hide');
    });

    //获取已选择的测点
    function getSelectPoints() {
        var points = new Array();
        $("#container-measurepoints li").each(function (index, obj) {
            var formula = $(obj).find('.formula').val();
            var desc = $.trim($(obj).find('.desc').text().replace("×",""));
            var p = { "Pointnum": $(obj).attr("id"), "Description": desc, "SettingName": $.trim($("#SettingName").val()),"Formula":$.trim(formula), "Userid": USERID, "Orgid": ORGID };
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


    });


    /**
    * 生成自定义报表
    */
    $("#btnCustomQuery").click(function () {
        var selSettingName = $("#hdnSettingName").val();
        CreateCustomFormulaReport(selSettingName);
    });

    //点击自定报表导航数据，生成对应自定义数据，相当于点击数据运算。
     $(".settingitem").on("click", ".rowQuery", function() {

         var name = $.trim($(this).attr("itemname"));
        //给隐藏域赋值：
        $('#hdnSettingName').val(name);
        //创建自定义报表
        CreateCustomReport(name);
        $(".settingitem").css("background-color",'#fff');
        $(this).parent().css("background-color","#ececec");
     });

    /**
    * 选择设置创建报表
    */
    $("#CreateSettingNameList li").click(function () {

        var settingName = $(this).text();
        $('#hdnSettingName').val(settingName);
        $('[id$=btnExport]').attr("disabled", false);

        CreateCustomReport(settingName);
    });

    /**
    * 创建自定义报表  运行公式
    * @param settingName 设置名称
    */
    function CreateCustomFormulaReport(settingName) {

        var startdate = $(".startdate").val();
        var enddate = $(".enddate").val();

        var ds = new Date(startdate);
        var de = new Date(enddate);

        startdate = moment(startdate).format('YYYY-MM-DD 00:00:00');

       // startdate = ds.toString("yyyy-MM-dd 00:00:00");
        enddate = de.toString("yyyy-MM-dd 23:59:59");

        console.log(startdate)

        //获取自定义报表结果
         $.getJSON('../services/GetAjaxData.ashx', { "funname": "GetCustomReportResult", "startdate": startdate, "enddate": enddate, "type": "Day","userid": USERID, "orgid": ORGID, "settingname": settingName }, function (data) {

            console.log(data);

            if (data.length == 0)
                return;

            //清空表格式数据
            var th = "", td = "";
            $("#gvCustomReport thead tr").html("");
            $("#gvCustomReport tbody").html("");

            $.each(data, function(index, obj) {
                var i = 0;
                if(index==0) {
                     $.each(obj, function(key, value) {
                        if(i==0) {
                             th += "<th>" + key + "</th>";
                        }
                     });
                }
            });

            $("#gvCustomReport thead tr").append(th);
            //动态构造表格内容
            $.each(data, function (index, obj) {
                td += "<tr>"
                $.each(obj, function (key, val) {
                   // console.log(key);

                    if (key == "统计日期") {
                        td += "<td>" + new Date(val).toString('yyyy-MM-dd') + "</td>";
                    } else {
                        td += "<td>" + val + "</td>";
                    }
                });
                td += "</tr>"
            });

            $("#gvCustomReport tbody").append(td);
            

         });

    }

    /**
    * 创建自定义报表  不运行公式
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

            $(".startdate").attr('title', "开始日期" + startdate);
            $(".enddate").attr('title', "结束日期" + enddate);

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
    var startdate = $(".startdate").val(),
        enddate = $(".enddate").val(),
        level = $(".level").val(),
        orgid = $(".orgid").val(),
        pointnum = "",
        type = "All";

    console.log(orgid);

    var ds = new Date(startdate);
    var de = new Date(enddate);

    startdate = ds.toString("yyyy-MM-dd 00:00:00");
    enddate = de.toString("yyyy-MM-dd 23:59:59");

    $(".startdate").attr('title',"开始日期"+ startdate);
    $(".enddate").attr('title',"结束日期"+ enddate);

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
        $enddate.val(Date.today().addDays(-1).toString("yyyy-MM-dd"));
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
    console.log();
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