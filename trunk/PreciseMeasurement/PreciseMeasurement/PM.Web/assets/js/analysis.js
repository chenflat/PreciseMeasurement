
/**
* 曲线对比模块
* @version 1.0
* @author  CHENPING
**/
$(function () {

	$(".bs-sidenav .active").on('click', function () {
		$(this).children('ul').toggle(300);
	});

	AddEvent();
	initSettings();

	//初始化分钟
	function initHistoryMinute() {
		$(".analysis .startdate").val(new Date().addHours(-12).toString("yyyy-MM-dd HH:mm"));
		$(".analysis .enddate").val(new Date().toString("yyyy-MM-dd HH:mm"));
	}
	//初始化小时
	function initHistoryHour() {
		$(".analysis .startdate").val(Date.today().add(-1).day().toString("yyyy-MM-dd"));
		$(".analysis .enddate").val(Date.today().toString("yyyy-MM-dd"));
	}

	initHistoryMinute();


	//更新时间类型事件
	$('.analysis input[name="datetype"]:radio').change(function () {

		AddEvent();

		var value = $(this).val();
		if (value == "MINUTE") {
			initHistoryMinute();
		} else {
			initHistoryHour();
		}
		console.log($(this).val());
	});


	//动态添加参数到列表
	$("#paramlist li").click(function () {
		//  console.log($(this).attr("id") + ", " + $(this).text());
		var text = $(this).text();
		var li = "<li id='" + $(this).attr("id") + "'>" + text + "</li>";
		if (!hasParamElement(text)) {
			$("#container-params").append(li);
		}
	});



	//动态添加计量点到列表
	$(".measurepoint-list li").click(function () {
		$(this).parent().show();
		var text = $(this).text();
		var id = $(this).attr("id");
		var li = "<li id='" + id + "'>" + text + "</li>";
		if (!hasPointElement(text)) {
			$("#container-measurepoints").append(li);
		}
	});

	//移除参数
	$("#container-params").on("click", "li", function () {
		//alert($(this).text());
		$(this).remove();
	});

	//移除计量点
	$("#container-measurepoints").on("click", "li", function () {
		// alert($(this).text());
		$(this).remove();
	});


	//判断是否存在参数元素
	function hasParamElement(text) {
		var ret = false;
		$("#container-params li").each(function (index, obj) {
			if ($(obj).text() == text) {
				ret = true;
			}
		});
		return ret;
	}

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


	/**
	* 初始化查询设置
	*/
	function initSettings() {

		$.getJSON('../services/GetAjaxData.ashx', { "funname": "GetAnalyzeSettings", "userid": USERID, "orgid": ORGID }, function (data) {
		   // console.log(data);
			var params = [];
			var points = [];

			$.each(data, function (index, obj) {
				if (obj.Type == 0) {
					params.push('<li id="' + obj.SettingName + '">' + obj.Description + '</li>');
				} else {
					points.push('<li id="' + obj.SettingName + '">' + obj.Description + '</li>');
				}
			});
			$("#container-params").append(params.join(""));
			$("#container-measurepoints").append(points.join(""));
		});
	}


	/**
	* 保存查询设置
	*/
	$("#btnSaveSetting").click(function () {

		var settings = new Array();

		$("#container-params li").each(function (index, obj) {
			var item = { "type": "MEASUREUNIT", "SETTINGNAME": $(obj).attr("id"), "DESCRIPTION": $.trim($(obj).text()), "USERID": USERID, "ORGID": ORGID };
			settings.push(item);
		});

		$("#container-measurepoints li").each(function (index, obj) {
			var item = { "type": "MEASUREPOINT", "SETTINGNAME": $(obj).attr("id"), "DESCRIPTION": $.trim($(obj).text()), "USERID": USERID, "ORGID": ORGID };
			settings.push(item);
		});

		if (settings.length == 0)
			return;

		var data = JSON.stringify({ "funname": "SaveAnalyzeSetting", "data": JSON.stringify(settings) });
		$.post('../../services/PostAjaxData.ashx', data, function (result) {
			if (result == "True") {
				$('#myModal').modal('hide');
			}
		});
	});

	//生成曲线
	$("#btnQuery").click(function() {
		$("#dvProgress").show();
		historyDataChart()
		
	});


	function historyDataChart() {

		//获取开始和结束日期，时间类型（分钟、小时）
		var startdate = $(".startdate").val();
		var enddate = $(".enddate").val();
		var datetype = $("input[name='datetype']:checked").val();
		GetChart(startdate, enddate, datetype);
		
	}
	

});

/**
 * 获取时间类型 
 */
function getDateType() {
	var datetype = $("input[name='datetype']:checked").val();
	if (datetype == '') { datetype = "MINUTE"; }
	return datetype;
}

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


		$(".analysis .startdate").click(function() {
			WdatePicker({
				lang: 'zh-cn',
				dateFmt: GetFormat(),
				maxDate: '%y-%M-%d %H'
			})
		});

		$(".analysis .enddate").click(function() {
			WdatePicker({
				lang: 'zh-cn',
				dateFmt: GetFormat(),
				maxDate: '%y-%M-%d {%H + 12}'
			})
		});
	} else {

		$(".analysis .startdate").click(function() {
			WdatePicker({
				lang: 'zh-cn',
				dateFmt: GetFormat(),
				maxDate: '%y-%M-{%d}'
			})
		});

		$(".analysis .enddate").click(function() {
			WdatePicker({
				lang: 'zh-cn',
				dateFmt: GetFormat(),
				maxDate: '%y-%M-{%d + 1}'
			})
		});
	}
}




//获取比较参数据
function getCompareParams() {
	var params = new Array();
	$("#container-params li").each(function(index, obj) {
		var p = {
			"num": $(obj).attr("id"),
			"description": $(obj).text()
		};
		params.push(p);
	});
	return params;
}

//获取比较测点
function getComparePoints() {
	var points = new Array();
	$("#container-measurepoints li").each(function(index, obj) {
		var p = {
			"num": $(obj).attr("id"),
			"description": $(obj).text()
		};
		points.push(p);
	});
	return points;
}

/**
* 获取数据曲线
*
* @param pointnum 测点编号
* @param startdate 开始统计日期
* @param enddate 结束统计日期
*/
function GetChart(startdate, enddate, datetype) {

	//获取比较参数
	var params = getCompareParams();
	//获取要比较的计量点
	var points = getComparePoints();
	var datetype = getDateType();
	var seriesOptions_Temp = [],
		seriesOptions_Density = [],
		seriesOptions_FlowInstant = [],
		seriesOptions_Pressure = [],
		yAxisOptions = [],
		seriesCounter = 0,
		colors = Highcharts.getOptions().colors;


	//计量数据地址,分别查询单点
	var path = "../services/GetAjaxData.ashx";
	$.each(points, function(i, point) {
		$.ajax({
			type: "GET",
			url: path,
			contentType: "application/json; charset=utf-8",
			dataType: "json",
			data: {
				"funname": "GetMeasurementHistoryData",
				"pointnum": point.num,
				"startdate": startdate,
				"enddate": enddate,
				"type": datetype
			},
			success: function(result) {

				var data_SwTemperature = []; //温度数据
				var data_AiDensity = []; //频率数据
				var data_AfFlowInstant = []; //瞬时流量
				var data_SwPressure = []; //压力


				//重新整理数据到指定类型的数组
				$.each(result, function(index, obj) {
					data_SwTemperature.push([new Date(obj.Measuretime).getTime(), obj.SwTemperature]);
					data_AiDensity.push([new Date(obj.Measuretime).getTime(), obj.AiDensity]);
					data_AfFlowInstant.push([new Date(obj.Measuretime).getTime(), obj.AfFlowinstant]);
					data_SwPressure.push([new Date(obj.Measuretime).getTime(), obj.SwPressure]);
				});


				//多个序列
				seriesOptions_Temp[i] = {
					name: point.description,
					data: data_SwTemperature
				};
				seriesOptions_Density[i] = {
					name: point.description,
					data: data_AiDensity
				};
				seriesOptions_FlowInstant[i] = {
					name: point.description,
					data: data_AfFlowInstant
				};
				seriesOptions_Pressure[i] = {
					name: point.description,
					data: data_SwPressure
				};

				seriesCounter++;

				if (seriesCounter == points.length) {
					// set the allowed units for data grouping
					var groupingUnits = [
						[
							'week', // unit name
							[1] // allowed multiples
						],
						[
							'month', [1, 2, 3, 4, 6]
						]
					];


					//不同的参数创建不同的图表
					$.each(params, function(index, obj) {
						switch (obj.num) {
							case "SW_Temperature":
								createChart(obj, seriesOptions_Temp, '温度(℃)', '(℃)', seriesCounter);
								break;
							case "AI_Density":
								createChart(obj, seriesOptions_Density, '频率(Hz)', '(Hz)', seriesCounter);
								break;
							case "AF_FlowInstant":
								createChart(obj, seriesOptions_FlowInstant, '流量(t)', '(t)', seriesCounter);
								break;
							case "SW_Pressure":
								createChart(obj, seriesOptions_Pressure, '压力(MPa)', '(MPa)', seriesCounter);
								break;
							default:
								break;
						}

					});
				} //end if
				$("#dvProgress").hide();
			} //end success
		});

	});

	/**
	* 当所有数据全部加载完成后，动态创建图表
	*/
	function createChart(obj,series,ytitle,unit,countParam) {

		$("#charts").append("<div id='" + obj.num + "'></div>");
		var id = obj.num;
		Highcharts.setOptions({
			global: {
				useUTC: false
			}
		});
		$('#' + id).highcharts('StockChart', {
			chart: {},
			title: {
				text: obj.description + '曲线' + unit
			},
			legend: {
				enabled: true,
				layout: 'vertical',
				align: 'right',
				verticalAlign: 'middle',
				borderWidth: 0
			},
			xAxis: {
				events: {
					setExtremes: function(e) {
						if (e.trigger === "navigator") {
							setTimeout(function() {
								for (var k = 0; k < countParam; k++) {
									console.log(Highcharts.charts[k].xAxis);
									if(typeof(Highcharts.charts[k].xAxis)!='undefined') {
										Highcharts.charts[k].xAxis[0].setExtremes(e.min, e.max);
									}
								}
							}, 4);
						}

					}
				},
				tickPixelInterval: 240, //x轴上的间隔  
				type: 'datetime', //定义x轴上日期的显示格式  
				labels: {
					formatter: function() {

						//console.log("x lables:"+ this.value);

						var vDate = new Date(this.value);
						var ret = ""
						//区分分钟和小时数据的日期格式
						if (datetype == 'MINUTE') {
							ret = vDate.getFullYear() + "-" + (vDate.getMonth() + 1) + "-" + vDate.getDate() + " " + vDate.getHours() + ":" + vDate.getMinutes();
						} else {
							ret = vDate.getFullYear() + "-" + (vDate.getMonth() + 1) + "-" + vDate.getDate();
						}

						return ret;
					},
					align: 'center'
				}
			},

			yAxis: {
				title: {
					text: ytitle
				},
				plotLines: [{
					value: 0,
					width: 2,
					color: 'silver'
				}],
				allowDecimals: true,
				minorGridLineColor: '#F0F0F0',
				minorTickInterval: 'auto'
			},

			plotOptions: {
				/* series: {
				compare: 'percent'
				} */
			},
			credits: {
				enabled: false
			},
			tooltip: {
				xDateFormat: '%Y-%m-%d %H:%M',
				pointFormat: '<span style="color:{series.color}">{series.name} ' + obj.description + '</span>: <b>{point.y}</b> <br/>',
				valueDecimals: 2
			},

			rangeSelector: {
				buttons: [{ //定义一组buttons,下标从0开始  
					type: 'week',
					count: 1,
					text: '1w'
				}, {
					type: 'month',
					count: 1,
					text: '1m'
				}, {
					type: 'month',
					count: 3,
					text: '3m'
				}, {
					type: 'month',
					count: 6,
					text: '6m'
				}, {
					type: 'ytd',
					text: 'YTD'
				}, {
					type: 'year',
					count: 1,
					text: '1y'
				}, {
					type: 'all',
					text: 'All'
				}],
				selected: 0 //表示以上定义button的index,从0开始  
			},
			series: series
		});
	}

}


function OnFail(response) {
	console.log(response);
}