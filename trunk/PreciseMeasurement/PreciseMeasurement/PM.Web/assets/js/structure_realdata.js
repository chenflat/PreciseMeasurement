
function ApplicationModel() {
  var self = this;

  self.carrier = ko.observable("steam"),
  self.username = ko.observable();
  self.datarows = ko.observable(new MeasurementModel());
  self.connect = function() {
	$.getJSON('../services/GetAjaxData.ashx', {
			"funname": "GetRealtimeMeasureValue",
			"carrier":   self.carrier
		}, function(data) {
			self.datarows().load(data);
		});
  }
}

function MeasurementModel() {
	var self = this;
	self.rows = ko.observableArray();
	self.load = function(measurements) {
		for (var i = 0; i < measurements.length; i++) {
			var row = new MeasurementRow(measurements[i]);
			self.rows.push(row);
		}
	};
}



/**
 * 计量点数据模块
 * @param  {[type]} data
 * @return {[type]}
 */
function MeasurementRow(data) {
	var self = this;

	self.pointnum = ko.observable(data.Pointnum);
	self.measuretime = ko.observable(data.Measuretime);
	self.SwPressure = ko.observable(data.SwPressure);
	self.SwTemperature = ko.observable(data.SwTemperature);
	self.AfFlowinstant = ko.observable(data.AfFlowinstant);
	self.status = ko.computed(function() { 
		var lasttime = new Date(data.Measuretime);
		var currtime = new Date();
 		var diff = (currtime - lasttime)/(1000*60);
               if (diff > 10) {
                    $("#" + obj.Pointnum).find(".icon").removeClass('nomarl').addClass('fault');
               }
		return "";
	});

}