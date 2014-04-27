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



    function AlarmlogInfo(data) {
        var self = this;
        self.Logid = ko.observable(data.Logid);
        self.Logtime = ko.observable(data.Logtime);
        self.Measurevalue = ko.observable(data.Measurevalue);
        self.Limitvalue = ko.observable(data.Limitvalue);
        self.Alarmtype = ko.observable(data.Alarmtype);
        self.Almcomment = ko.observable(data.Almcomment);
        self.Measureunitid = ko.observable(data.Measureunitid);
        self.Pointnum = ko.observable(data.Pointnum);
        self.Almpriority = ko.observable(data.Almpriority);
        self.Almoperatorname = ko.observable(data.Almoperatorname);
        self.Acktime = ko.observable(data.Acktime);
        self.Ackvalue = ko.observable(data.Ackvalue);
        self.Ackoperatorname = ko.observable(data.Ackoperatorname);
        self.Rettime = ko.observable(data.Rettime);
        self.Retvalue = ko.observable(data.Retvalue);
        self.Retoperatorname = ko.observable(data.Retoperatorname);
        self.Reviewtime = ko.observable(data.Reviewtime);
        self.Reviewcontent = ko.observable(data.Reviewcontent);
        self.Reviewer = ko.observable(data.Reviewer);
        self.Status = ko.observable(data.Status);
        self.Orgid = ko.observable(data.Orgid);
        self.Measureunitname = ko.observable(data.Measureunitname);

    }

    function ViewModel() {
        var self = this;
        // create an empty observable array...will fill with json data
        self.alarmlogInfos = ko.observableArray([]); 
        // page.php below is a link to the php page that contains your json code created above
       /* jQuery.getJSON('http://chadmullins.com/misc-php/knockout-series-json.php', {
            returnformat: 'json'
            }, function(allData) {
                var mappedData= jQuery.map(allData, function(item) { return new AlarmlogInfo(item) });
                self.alarmlogInfos(mappedData);
            });
        }
*/

        self.loadAlarmlogs = function() {


            var oTable = $('#alarmgrd').dataTable();
            var oSettings = oTable.fnSettings();

            console.log(oSettings);


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

            console.log(enddate);

            var path = CONTEXT_PATH + "services/GetAlarmlogs.ashx"
            $.ajax({
                type: "GET",
                url: path,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                beforeSend: function(){
                       $("#dvProgress").show();
                   },
                data: { "startdate": startdate, "enddate": enddate, "pointnum": pointnum, "status": status, "orgid": ORGID, "pageindex": 1, "pagesize": 150 },
                success: function(allData){
                    var mappedData= jQuery.map(allData.List, function(item) { return new AlarmlogInfo(item) });
                    self.alarmlogInfos(mappedData);

                   // console.log(allData.List);
                    $("#dvProgress").hide();
                },
                error: OnFail
            });
        }

        

    }

    var vm = new ViewModel();
    ko.applyBindings(vm);   
    vm.loadAlarmlogs();



   // getAlarmlogs(1);
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

        console.log(alarmlogs);

        var row = $("[id*=gvAlarmData] tr:last-child").clone(true);
        $("[id*=gvAlarmData] tr").not($("[id*=gvAlarmData] tr:first-child")).remove();

        $.each(alarmlogs, function (index, obj) {
            // console.log(obj);
            $("td", row).eq(0).html(obj.Pointnum);
            $("td", row).eq(1).html(getAlarmType(obj.Alarmtype));
            $("td", row).eq(2).html($.trim(obj.Measureunitname));
            $("td", row).eq(3).html($.trim(obj.Measurevalue));
            $("td", row).eq(4).html($.trim(obj.Almcomment));
            $("td", row).eq(5).html(new Date(obj.Logtime).toString("yyyy-MM-dd"));
            $("td", row).eq(6).html(new Date(obj.Acktime).toString("yyyy-MM-dd"));
            $("td", row).eq(7).html(obj.Ackoperatorname);
            $("td", row).eq(8).html("处理");


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

