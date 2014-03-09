

$(function () {


    //打开或关闭级别菜单
   $("label.tree-toggler").on('click',function(){
        $(this).parent().children('ul.tree').toggle(300);
   
   });


   //获取设置类型
   function GetType() {
      var type = $("input[name='carrier']:checked").val();
        if (type == '') { type = "steam"; }
        return type;
   }

   //切换类型
   $('input[name="carrier"]:radio').change(function () {
        GetMeasurePointList($(this).val());
   });


   $("#organizationlist a").click(function () {
       var orgid = $(this).attr("id");
       //console.log(orgid);

       var url = "../services/GetAjaxData.ashx";
       var params = { "funname": "GetMeasurePointList", "orgid": orgid };

       $.getJSON(url, params, function (data) {
           // console.log(data);
           CreateMeasurePointTreeList(data);
       });
   });


   /**
   * 获取测量点列表
   * @param type 测点类型
   */
   function GetMeasurePointList(type) {
       // console.log(type);

        var url = "../services/GetAjaxData.ashx";
        var params = {"funname":"GetMeasurePointList", "carrier" : type, "orgid" : ORGID};

        $.getJSON(url,params,function(data){
           // console.log(data);
            CreateMeasurePointTreeList(data);
        });
   }


   $("#carrier li").click(function(){
        var type = $(this).attr("id");
        findMeasurePointByType(type);
   });

   //获取指定类型的测点列表
   function findMeasurePointByType(type) {
    console.log(type);
                var url = "../services/GetAjaxData.ashx";
        var params = {"funname":"GetMeasurePointList", "carrier" : type, "orgid" : ORGID};
         $.getJSON(url,params,function(data){
           // console.log(data);
            CreateMeasurePointTreeList(data);
        });
   }




   function CreateMeasurePointTreeList(data) {
    
    var arrLevel = [];

    //第一次迭代,创建层级
    $.each(data,function(i,obj){
        var isExist = $.inArray(obj.Level, arrLevel) > -1;
        if(!isExist) {
            arrLevel.push(obj.Level);
        }
    });


   
    $(".bs-sidenav").empty();

    var firstli = "";
    var secondli = "";
     //第二次迭代,设置层级数据
    $.each(arrLevel,function(j,level){
        firstli += "<li class=\"active\"><a href=\"#\"><i class=\"fa fa-wrench\"></i>" +
           "<span class=\"pull-right\"> <i class=\"fa fa-angle-down text\"></i> <i class=\"fa fa-angle-up text-active\"></i> </span><span>" +
            level + "级</span></a>" +
            "<ul class=\"nav lt tree\">";
            var secondli = "";
        $.each(data,function(i,obj){
            if(obj.Level==level) {
                //arrLevel[j].push(obj);
                secondli +="<li><a href='?type="+ obj.Carrier +"&measurepointid="+ obj.Measurepointid +"'>["+ obj.Pointnum +"] "+ obj.Description +"</a></li>";

            }

        });
        firstli +=secondli + "</ul></li>";

    });

    $(".bs-sidenav").append(firstli);
   }




    /**
    * 获取实时数据
    */
    function getRealtimeData() {
        var $AiDensity = $("#AI_Density"),
            $SWTemperature = $("#SW_Temperature"),
            $AFFlowInstant = $("#AF_FlowInstant"),
            $SWPressure = $("#SW_Pressure"),
            $ATFlow = $("#AT_Flow")
        //设置编号
        var pointnum = $("#pointnum").val();
        if(pointnum!="" && typeof(pointnum)!='undefined') {
            $.getJSON('../services/GetAjaxData.ashx',{ "funname": "GetRealtimeMeasureValue","pointnum":pointnum},function(data){
                if(data!=null) {
                    $AiDensity.text(isNaN(data.AiDensity)?data.AiDensity.substr(0,data.AiDensity.indexOf(".")+2) : data.AiDensity);  
                    $SWTemperature.text(isNaN(data.SwTemperature)?data.SwTemperature.substr(0,data.SwTemperature.indexOf(".")+2) : data.SwTemperature);
                    $AFFlowInstant.text(isNaN(data.AfFlowinstant)?data.AfFlowinstant.substr(0,data.AfFlowinstant.indexOf(".")+2) : data.AfFlowinstant);
                    $SWPressure.text(isNaN(data.SwPressure)?data.SwPressure.substr(0,data.SwPressure.indexOf(".")+2) : data.SwPressure);
                    $ATFlow.text(isNaN(data.AtFlow)?data.AtFlow.substr(0,data.AtFlow.indexOf(".")+2) : data.AtFlow);
                    $("#lastMeasuretime").text(data.Measuretime);
                    

                }
            });
        }
    }
    //每5秒自动更新实时数据
    setInterval(getRealtimeData,10000);
    getRealtimeData();


    $(".minute #startdate").val(new Date().add(-1).day().toString("yyyy-MM-dd HH:mm"));
    $(".minute #enddate").val(new Date().toString("yyyy-MM-dd HH:mm"));

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

    //小时数据
    $(".hour #startdate").val(Date.today().add(-1).day().toString("yyyy-MM-dd"));
    $(".hour #enddate").val(Date.today().toString("yyyy-MM-dd"));

    $(".hour #startdate").click(function () {

        WdatePicker({ lang: 'zh-cn', dateFmt: 'yyyy-MM-dd', maxDate: '%y-%M-{%d} 00:00' })

    });

    $(".hour #enddate").click(function () {

        WdatePicker({ lang: 'zh-cn', dateFmt: 'yyyy-MM-dd', maxDate: '%y-%M-{%d}' })

    });

    //每天数据

    $(".day .startdate").val(Date.today().add(-8).day().toString("yyyy-MM-dd"));
    $(".day .enddate").val(Date.today().toString("yyyy-MM-dd"));

    $(".day .startdate").click(function () {

        WdatePicker({ lang: 'zh-cn', dateFmt: 'yyyy-MM-dd', maxDate: '%y-%M-{%d} 00:00' })

    });

    $(".day .enddate").click(function () {

        WdatePicker({ lang: 'zh-cn', dateFmt: 'yyyy-MM-dd', maxDate: '%y-%M-{%d}' })

    });

    //历史
    function initHistoryMinute() {
        $(".history .startdate").val(new Date().addHours(-10).toString("yyyy-MM-dd HH:mm"));
        $(".history .enddate").val(new Date().toString("yyyy-MM-dd HH:mm"));
    }

    function initHistoryHour() {
        $(".history .startdate").val(Date.today().add(-5).day().toString("yyyy-MM-dd"));
        $(".history .enddate").val(Date.today().toString("yyyy-MM-dd"));
    }

    initHistoryMinute();


    $(".history .startdate").click(function () {   
       AddEvent();
    });

    $(".history .enddate").click(function () {
        AddEvent();

    });
	//更新历史开始结束日期
	 $(".history .startdate").change(function(){
		 console.log('change');
		setEndDay();
	 });

    $('.history input[name="datetype"]:radio').change(function () {
        AddEvent();
        var value = $(this).val();
        if (value == "MINUTE") {
            initHistoryMinute();
        } else {
            initHistoryHour();
        }
    });

    
        /**
         * 获取时间格式
         */
        function GetFormat() {
            var type = getDateType();
            if (type == "MINUTE") {
                return 'yyyy-MM-dd HH:00';
            }
            else {
                return 'yyyy-MM-dd';
            }
        }
    function AddEvent() {
        var type = getDateType();

        if (type == "Minute") {
            $(".history .startdate").click(function () {
                WdatePicker({ lang: 'zh-cn', dateFmt: GetFormat(), maxDate: '%y-%M-%d %H' })
            });

            $(".history .enddate").click(function () {
                WdatePicker({ lang: 'zh-cn', dateFmt: GetFormat(), maxDate: '%y-%M-%d {%H + 12}' })
            });
        }
        else {
            $(".history .startdate").click(function () {
                WdatePicker({ lang: 'zh-cn', dateFmt: GetFormat(), maxDate: '%y-%M-{%d}' })
            });

            $(".history .enddate").click(function () {
                WdatePicker({ lang: 'zh-cn', dateFmt: GetFormat(), maxDate: '%y-%M-{%d + 1}' })
            });
        }
}

	

	//设置开始日期
	function setEndDay() {
		var type = getDateType();
		 if (type == "MINUTE") {
			if($(".history .startdate").val().length>0) {
				//Date startdate = Date.parse($(".history .startdate").val());
				// $(".history .enddate").val();
			}

		 } else {
			 console.log(type);
			if($(".history .startdate").val().length>0) {
				 $(".history .enddate").val(new Date($(".history .startdate").val()).addDay(1));
			}
		 }
	}



    //每日数据
    $(".day #btnQuery").click(function () {
        GetMeasurements(1);
    });

    //分钟数据

    function initMinuteData() {

        var pointnum = $("#pointnum").val();
        var startdate = new Date().add(-1).day().toString("yyyy-MM-dd HH:mm");
        var endate = new Date().toString("yyyy-MM-dd HH:mm");
        GetMinuteData(pointnum, startdate, endate, 1)
    }
    initMinuteData();

    $("#btnMinuteQuery").click(function () {
        console.log("minute");
        var pointnum = $("#pointnum").val();
        var startdate = $(".minute #startdate").val();
        var endate = $(".minute #enddate").val();
        GetMinuteData(pointnum, startdate, endate, 1)
    });

    $("#minutepager").on("click", "a", function () {
        var pointnum = $("#pointnum").val();
        var startdate = $(".minute #startdate").val();
        var endate = $(".minute #enddate").val();
        GetMinuteData(pointnum, startdate, endate, parseInt($(this).attr('page')))
    });

    //小时数据
    //初始小时数据
    function initHourData() {
        var pointnum = $("#pointnum").val();
        var startdate = Date.today().add(-1).day().toString("yyyy-MM-dd");
        var endate = Date.today().toString("yyyy-MM-dd");

        GetHourData(pointnum, startdate, endate, 1)
    }
    initHourData();

    $("#btnHourQuery").click(function () {

        var pointnum = $("#pointnum").val();
        var startdate = $(".hour #startdate").val();
        var endate = $(".hour #enddate").val();

        GetHourData(pointnum, startdate, endate, 1)
    });


    $("#hourpager").on("click", "a", function () {
        //console.log($(this));
        var pointnum = $("#pointnum").val();
        var startdate = $(".hour #startdate").val();
        var endate = $(".hour #enddate").val();

       // console.log($(this).attr('page'));

        GetHourData(pointnum, startdate, endate, parseInt($(this).attr('page')))
    });

    //每日数据
    function initDayData() {
         var pointnum = $("#pointnum").val();
        var startdate = Date.today().add(-8).day().toString("yyyy-MM-dd");
        var endate = Date.today().toString("yyyy-MM-dd");
        GetDayData(pointnum, startdate, endate, 1)
    }
    initDayData();

    $("#btnDayQuery").click(function () {

        var pointnum = $("#pointnum").val();
        var startdate = $(".day #startdate").val();
        var endate = $(".day #enddate").val();

        //console.log(pointnum + "," + startdate +"," + endate);

        GetDayData(pointnum, startdate, endate, 1)
    });


   $("#daypager").on("click", "a", function () {
        var pointnum = $("#pointnum").val();
        var startdate = $(".day #startdate").val();
        var endate = $(".day #enddate").val();

         console.log($(this).attr('page'));

        GetDayData(pointnum, startdate, endate, parseInt($(this).attr('page')))
    });

    //历史数据

    $("#btnHistoryQuery").click(function () {
        var type = $('input:radio[name=datetype]:checked').val();
        var pointnum = $("#pointnum").val();
        var startdate = $(".hsdate").val();
        var enddate = $(".hedate").val();
		
        console.log(pointnum + "," + startdate + "," + enddate );


        if (type == "MINUTE") {
            GetMinuteChart(pointnum, startdate, enddate);
        } else {
//			if(endate==startdate) {
//				enddate = enddate + " 23:59";
//			} else {

//				enddate = dn.addDays(-1).toString('yyyy-MM-dd') + " 23:59";

//			}

            enddate = enddate + " 23:59";

            GetHourChart(pointnum, startdate, enddate);
        }
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
    if (measurements.length == 0)
        return;

    var row = $("[id*=gvMinuteMeasurement] tr:last-child").clone(true);
    $("[id*=gvMinuteMeasurement] tr").not($("[id*=gvMinuteMeasurement] tr:first-child")).remove();


    $.each(measurements, function (index, obj) {
       // console.log(obj);
        $("td", row).eq(0).html(Date.parse(obj.Time).toString("yyyy-MM-dd HH:mm"));
        $("td", row).eq(1).html((obj.SwTemperature).toFixed(1));
        $("td", row).eq(2).html((obj.SwPressure).toFixed(3));
        $("td", row).eq(3).html((obj.AfFlowinstant).toFixed(3));
        $("td", row).eq(4).html((obj.AtFlow).toFixed(0));
        $("td", row).eq(5).html((obj.AiDensity).toFixed(1));

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
    enddate = enddate + " 23:59";
    $.ajax({
        type: "GET",
        url: "RealtimeParam.ashx",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: { "pointnum": pointnum, "startdate": startdate, "enddate": enddate, "pageindex": pageindex, "type": "HOUR" },
        success: OnSuccessForHour,
        error: OnFail
    });

}

function OnSuccessForHour(response) {

    //console.log(response);
    var measurements = response.List;
    if (measurements.length == 0)
        return;

    var row = $("[id*=gvHourMeasurement] tbody tr:last-child").clone(true);
    $("[id*=gvHourMeasurement] tbody tr").not($("[id*=gvHourMeasurement] tr:first-child")).remove();


    $.each(measurements, function (index, obj) {
        // console.log(obj);
        $("td", row).eq(0).html(obj.Description);
        $("td", row).eq(1).html(new Date(obj.Starttime).toString("yyyy-MM-dd HH:mm"));
        $("td", row).eq(2).html((obj.StartValue).toFixed(0));
        $("td", row).eq(3).html(new Date(obj.Endtime).toString("yyyy-MM-dd HH:mm"));
        $("td", row).eq(4).html((obj.LastValue).toFixed(0));
        $("td", row).eq(5).html((obj.Value).toFixed(0));


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
    enddate = new Date(enddate).add(1).day().toString("yyyy-MM-dd");

    $.ajax({
        type: "GET",
        url: "RealtimeParam.ashx",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: { "pointnum": pointnum, "startdate": startdate, "enddate": enddate, "pageindex": pageindex, "type": "DAY" },
        success: OnSuccessForDay,
        error: OnFail
    });
}

function OnSuccessForDay(response) {

    //console.log(response);
    var measurements = response.List;
    if (measurements.length == 0)
        return;

    var row = $("[id*=gvDayMeasurement] tr:last-child").clone(true);
    $("[id*=gvDayMeasurement] tr").not($("[id*=gvDayMeasurement] tr:first-child")).remove();


    $.each(measurements, function (index, obj) {
        // console.log(obj);
        $("td", row).eq(0).html(obj.Description);
        $("td", row).eq(1).html(new Date(obj.Starttime).toString("yyyy-MM-dd"));
        $("td", row).eq(2).html((obj.StartValue).toFixed(0));
        $("td", row).eq(3).html(new Date(obj.Endtime).toString("yyyy-MM-dd"));
        $("td", row).eq(4).html((obj.LastValue).toFixed(0));
        $("td", row).eq(5).html((obj.Value).toFixed(0));

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





/**
* 获取分钟历史数据曲线
*
* @param pointnum 测点编号
* @param startdate 开始统计日期
* @param enddate 结束统计日期
*/
function GetMinuteChart(pointnum, startdate, enddate) {
    
    $.ajax({
        type: "GET",
        url: "MeasurementHistoryData.ashx",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: { "pointnum": pointnum, "startdate": startdate, "enddate": enddate, "type": "MINUTE" },
        success: OnSuccessHourChart,
        error: OnFail
    });
}

/**
* 获取小时历史数据曲线
*
* @param pointnum 测点编号
* @param startdate 开始统计日期
* @param enddate 结束统计日期
*/
function GetHourChart(pointnum, startdate, enddate) {
    console.log(pointnum + "," + startdate + "," + enddate);
    $.ajax({
        type: "GET",
        url: "MeasurementHistoryData.ashx",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: { "pointnum": pointnum, "startdate": startdate, "enddate": enddate, "type": "HOUR" },
        success: OnSuccessHourChart,
        error: OnFail
    });

    // return false;
}

function getDateType() {
    return $('.history input[name="datetype"]:checked').val();
}

/**
*  获取图表X轴
* @param starttime 开始时间
* @param endtime 结束时间
* @type 时间类型
*/
function getChartXAxis(datetype){
	var startdate = $(".history #startdate").val();
    var endate = $(".history #enddate").val();
	
	var dateZone = new Array();

	var d1 = new Date(startdate); //"now"
	var d2 = new Date(endate)  
	if(datetype=="MINUTE") {
		var diff = Math.abs(d1-d2);
		var days =  diff/1000/60/60/24;
		for(var i=0;i<days;i++) {
			dateZone.push(d1.addDays(i).toString("MM-dd"));
		}

	} else {
		var diff = Math.abs(d1-d2);
		var days =  diff/1000/60/60/24;
		for(var i=0;i<days;i++) {
			dateZone.push(d1.addDays(i).toString("MM-dd HH:00"));
		}
	}
	return dateZone;
}


function OnSuccessHourChart(response){

	var dateZone = getChartXAxis("HOUR")
    var type = getDateType();
    var dtformat = "MM-dd"
    var step = 24;
    if(type=="MINUTE") {
        dtformat = "MM-dd HH:00";
        step = 60;
    }
    

	var charItems = [
			{"name":"SW_TEMPERATURE","title":"温度曲线","unit":"°C"},
			{"name":"SW_PRESSURE","title":"压力曲线","unit":"MPa"},
			{"name":"AF_FLOWINSTANT","title":"瞬时流量曲线","unit":"t/h"},
            {"name":"AI_Density","title":"频率","unit":"Hz"}
		];

	var selected = new Array();
	$("input[name='dataitem']:checked").each(function() {
		 selected.push($(this).val());
	});

	var times = [];
	var arrSwtemperature = [];
	var arrSwpressure  = [];
	var arrAfflowinstant  = [];
    var arrAiDensity = [];
	
	for(var i=0;i<response.length;i++) {
		times.push(response[i].Time);
		arrSwtemperature.push(response[i].SwTemperature);
		arrSwpressure.push(response[i].SwPressure);
		arrAfflowinstant.push(response[i].AfFlowinstant);
        arrAiDensity.push(response[i].AiDensity);
	}

    $('#temperature').hide();
    $('#pressure').hide();
    $('#flowinstant').hide();
    $('#aidensity').hide();

	for(var i=0;i<selected.length;i++) {
		if(selected[i]=="SW_TEMPERATURE") {
			$('#temperature').show();
			$('#temperature').highcharts({
			    title: {
			        text: '温度曲线(°C)'
			    },
			    xAxis: {
                    tickInterval:step,
                    tickWidth: 0,
			        labels: {
			            formatter: function () {
			                return Date.parse(this.value).toString(dtformat);
			            }
			        },
			        categories: times,
			        gridLineWidth: 1
			    },
			    yAxis: {
			        title: {
			            text: 'Temperature (°C)'
			        },
			        plotLines: [{
			            value: 0,
			            width: 0,
			            color: '#808080'
			        }]
			    },
			    tooltip: {
			        valueSuffix: '°C',
                    valueDecimals : 1
			    },
			    legend: {
			        enabled: false
			    },
			    series: [{
			        name: '温度',
			        data: arrSwtemperature
			    }],
			    plotOptions: {
                    line: {
                        marker: {
                            enabled: false
                        }
                    }
			    },
			    credits: {
			        enabled: false
			    }
			});

		} else if(selected[i]=="SW_PRESSURE") {
			$('#pressure').show();
			$('#pressure').highcharts({
				title: {
					text: '压力曲线(MPa)',
					x: -20 //center
				},
				xAxis: {
                    tickInterval:step,
				    labels: {
				        //staggerLines: 4,
				        //step: 24,
				        formatter: function () {
				            return Date.parse(this.value).toString(dtformat);
				        }
				    },
				    categories: times,
				    gridLineWidth: 1,
				},
				yAxis: {
					title: {
						text: 'Pressure (MPa)'
					},
					plotLines: [{
						value: 0,
						width: 1,
						color: '#808080'
					}]
				},
				tooltip: {
					valueSuffix: 'MPa',
                    valueDecimals : 3
				},
				legend: {
				    enabled: false
				},
				series: [{
					name: '压力',
					data: arrSwpressure
				}],
                plotOptions: {
                    line: {
                        marker: {
                            enabled: false
                        }
                    }
			    },
	            credits: {
	                enabled: false
	            }
			});			

		} else if(selected[i]=="AF_FLOWINSTANT") {
			$('#flowinstant').show();
			$('#flowinstant').highcharts({
				title: {
					text: '瞬时流量曲线(t/h)',
					x: -20 //center
				},
				xAxis: {
                     tickInterval:step,
				    labels: {
				        step: 24,
				        formatter: function () {
				            return Date.parse(this.value).toString(dtformat);
				        }
				    },
				    categories: times,
				    gridLineWidth: 1
				},
				yAxis: {
					title: {
						text: 'Flowinstant (t/h)'
					},
					plotLines: [{
						value: 0,
						width: 1,
						color: '#808080'
					}]
				},
				tooltip: {
					valueSuffix: 't/h',
                    valueDecimals : 3
				},
				legend: {
				    enabled: false
				},
				series: [{
					name: '瞬时流量',
					data: arrAfflowinstant
				}],
                plotOptions: {
                    line: {
                        marker: {
                            enabled: false
                        }
                    }
			    },
	            credits: {
	                enabled: false
	            }
			});			

		} else if(selected[i]=="AI_Density") {
			$('#aidensity').show();
			$('#aidensity').highcharts({
				title: {
					text: '频率曲线(Hz)',
					x: -20 //center
				},
				xAxis: {
                     tickInterval:step,
				    labels: {
				        step: 24,
				        formatter: function () {
				            return Date.parse(this.value).toString(dtformat);
				        }
				    },
				    categories: times,
				    gridLineWidth: 1
				},
				yAxis: {
					title: {
						text: 'Density (Hz)'
					},
					plotLines: [{
						value: 0,
						width: 1,
						color: '#808080'
					}]
				},
				tooltip: {
					valueSuffix: 'Hz',
                    valueDecimals : 1
				},
				legend: {
				    enabled: false
				},
				series: [{
					name: '频率',
					data: arrAiDensity
				}],
                plotOptions: {
                    line: {
                        marker: {
                            enabled: false
                        }
                    }
			    },
	            credits: {
	                enabled: false
	            }
			});			

		}


		
	
	}




   

}