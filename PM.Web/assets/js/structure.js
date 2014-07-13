

/**
 * 系统结构图
 * @author: PING.CHEN
 * @version: 1.0 build20131121
 */
function StructureModel() {
    var self = this;
    self.measurepoint = ko.observable(new MeasurePointModel());
}

function MeasurePointModel() {

    var self = this;

    self.rows = ko.observableArray();

    self.filter = ko.observable("");
    self.filteredItems = ko.dependentObservable(function() {
        var filter = self.filter().toLowerCase();

        if (!filter) {
            return self.rows();
        } else {
            return ko.utils.arrayFilter(self.rows(), function(item) {
                if(filter!="") {
                     return item.Carrier.toLowerCase()==filter;
                 } else {
                     return self.rows();
                 }
               
            });
        }
    }, self);

    self.gridOptions = { 
        data: self.filteredItems,
        columnDefs: [
            {field: 'fullName', displayName: '计量点',width:'150px'},
            {field: 'time', displayName: '采集时间',width:'110px'},
            {field: 'formattedPressure', displayName: '压力(MPa)',width:'80px'},
            {field: 'formattedTemp', displayName: '温度(℃)',width:'80px'},
            {field: 'formattedAfFlowinstant', displayName: '瞬时流量(t/h)',width:'100px'}
        ],
        displaySelectionCheckbox:false,
        footerVisible: false,
        multiSelect: false
    };

    




    var rowLookup = {};
    self.loadPositions = function(positions) {
        for ( var i = 0; i < positions.length; i++) {
          var row = new MeasurePointDataModel(positions[i]);
          self.rows.push(row);
          rowLookup[row.Pointnum] = row;
        }
    };
    self.updatePosition = function(position) {
        var row = rowLookup[position.Pointnum];
        if(typeof(row)!='undefined') {
            
            row.Measuretime(position.Measuretime);
            row.SwPressure(position.SwPressure);
            row.SwTemperature(position.SwTemperature);
            row.AfFlowinstant(position.AfFlowinstant);
            row.AtFlow(position.AtFlow);
            row.AiDensity(position.AiDensity);


            $("#" + position.Pointnum + "_data .SW_Temperature span").text(position.SwTemperature);
            $("#" + position.Pointnum + "_data .SW_Pressure span").text(position.SwPressure);
            $("#" + position.Pointnum + "_data .AF_FlowInstant span").text(position.AfFlowinstant);
            $("#" + position.Pointnum + "_data .AT_Flow span").text(position.AtFlow);
            $("#" + position.Pointnum + "_data .AI_Density span").text(position.AiDensity);
            $("#" + position.Pointnum + "_data .MEASURETIME div").text(position.Measuretime);


            if ((new Date(position.Measuretime).toString('yyyy-MM-dd')) == '1900-01-01') {
                    mstyle = " style='color:red;'";

                    $("#" + position.Pointnum).find(".status").hide();

                    $("#" + position.Pointnum).find(".icon").removeClass('nomarl').addClass('noconnection');
                }

            var lasttime = new Date(position.Measuretime);
            var currtime = new Date();

            //当前时间和最后采集时间比较，如果相差为10，也就是10分钟内未采集数据，则设置当前计量器为故障状态
            var diff = (currtime - lasttime)/(1000*60);
            if (diff > 10) {
                 $("#" + position.Pointnum).find(".icon").removeClass('nomarl').addClass('fault');
            }
        }
    };

    self.updatePositions = function(positions) {
         for ( var i = 0; i < positions.length; i++) {
            //console.log(positions[i]);
            self.updatePosition(positions[i]);
         }
    };
}

//计量点模型
function MeasurePointDataModel(data) {
    var self = this;
    self.Pointnum = data.Pointnum;
    self.Description = data.Description;
    self.Carrier = data.Carrier;
    self.Measuretime = ko.observable(data.Measuretime);
    self.SwPressure = ko.observable(data.SwPressure);
    self.SwTemperature = ko.observable(data.SwTemperature);
    self.AfFlowinstant = ko.observable(data.AfFlowinstant);
    self.AtFlow = ko.observable(data.AtFlow);
    self.AiDensity = ko.observable(data.AiDensity);
    self.fullName = ko.computed(function(){return "["+ self.Pointnum + "]" + self.Description});
    self.time = ko.computed(function() {
        var t = ko.toJS(self.Measuretime);
        if(typeof(t)!='undefined ') {
           var a = moment(t).format("MM-DD HH:mm:ss");
           return a;
        }
    });
    self.formattedTemp = ko.computed(function() { 
       // return self.SwTemperature(); 
        var num = parseFloat(ko.toJS(self.SwTemperature()));
        return  formartNumber(num,1)

    });
    self.formattedPressure = ko.computed(function() { 
        var num = parseFloat(ko.toJS(self.SwPressure()));
        return  formartNumber(num,3)
    });

    self.formattedAfFlowinstant = ko.computed(function(){
        var num = parseFloat(ko.toJS(self.AfFlowinstant()));
        return  formartNumber(num,2)
    });


    self.change = ko.observable(0);
    self.arrow = ko.observable();

    self.updateTime = function(newTime) {
      //  var delta = (newPrice - self.price()).toFixed(2);
       // self.arrow((delta < 0) ? '<i class="icon-arrow-down"></i>' : '<i class="icon-arrow-up"></i>');
       // self.change((delta / self.price() * 100).toFixed(2));
       // self.price(newPrice);
      };
}


 function formartNumber(num,length) {
    if (isNaN(num)) {  
        return;  
    } 
    var ret = Math.floor(num * 1000) / 1000;

    var s = ret.toString();  
    var rs = s.indexOf('.');  
    if (rs < 0) {  
        rs = s.length;  
        s += '.';  
    }  
    while (s.length <= rs + length) {  
         s += '0';  
    }  
    //console.log(s);
    return s;
}




$(function () {

    var appModel = new StructureModel();
    ko.applyBindings(appModel);

   
    //获取计量点列表
    $.getJSON('../services/GetAjaxData.ashx', { "funname": "GetMeasurePointList"}, function (data) {
        appModel.measurepoint().loadPositions(data);
    });


    //每60秒自动重新获取实时数据
    getRealtimeData()
    setInterval(getRealtimeData, 60000);
    counter();

    //防止未加载，1秒后重新加载一次
    setTimeout(getRealtimeData,1000);
  

   //获取设置类型
    function GetType() {
        var type = $("input[name='carrier']:checked").val();
        if (type == '') {
            type = "steam";
        }
        return type;
    }

    //切换类型
    $('input[name="carrier"]:radio').change(function() {
         var carrier = $("input[name='carrier']:checked").val();

/*
       $.each($("#gvRealtimeData tbody tr"),function(index,row){
            $(row).show();
            var type = $(row).attr("type");
            if(type!=carrier && (carrier!="")) {
                $(row).hide();
            }
       });

*/

    });

    //获取所有测点的实时数据
    function getRealtimeData() {

        $.ajax({
            type: "GET",
            url: '../services/GetAjaxData.ashx',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            beforeSend: function() {
               // $("#dvProgress").show();
            },
            data: {
                "funname": "GetRealtimeMeasureValue"
            },
            success: function(data) {

                //var mappedData= jQuery.map(data, function(item) { return new MeasurePointDataModel(item) });
               // appModel.measurepoint().rows(mappedData);
                appModel.measurepoint().updatePositions(data);

                ///$("#dvProgress").hide();
            },
            error: function(response) {
                console.log(response);
                //$("#dvProgress").hide();
            }
        });
    }

    //点击记量点，动态显示当前数据的计量值
    $("#structure div").click(function () {
        //编辑时不弹出计量点信息
        if (window.dialogArguments) {
            return;
        }
        pointnum = $(this).attr("id");
        description = $(this).attr("title");
        contentId = pointnum + "_data";

        var position = $("#" + pointnum).position();
        $("#" + contentId).css({ top: position.top + 30, left: position.left + 30 }).toggle();

    });


    $("#structure .close").click(function () {
        $(this).parent().hide();
    });

    //刷新数据
    $("#refreshData").click(function () {
        getRealtimeData();
    });

    /**
    * 关闭或显示时间数据表格
    */
    $("#swichbar").click(function() {
        $("#realdata").toggle(function() {
            if ($("#realdata").css("display") == 'none') {
                $("#swichbar").text('>>');
                $("#refresh").css({
                    left: 1100
                });
            } else {
                $("#swichbar").text('<<');
                $("#refresh").css({
                    left: 980
                });
            }
        });
    });

    $('#btnSave').button();
    //拖动区域
    $(".meter_content").draggable();
    /**
    * 保存测点位置
    */
    $("#btnSave").click(function () {

        var meters = $(".meter");
        var coordinates = new Array();
        $.each($(meters), function (index, obj) {
            //获取测点结构图位置，并保存到数组中
            coordinates.push({ "Pointnum": $(obj).attr("id"), "X": $(obj).position().left, "Y": $(obj).position().top, "Orgid": $(obj).attr("orgid") });
        });
        if (coordinates.length == 0) {
            return;
        }

        var data = JSON.stringify({ "funname": "SaveMeasurePointCoordinates", "data": coordinates })

        $.post("../services/PostAjaxData.ashx", data, function (result) {
            console.log(result);
            if (result == "True") {
                alert("计量点位置保存成功，请关闭窗口!");
            }
        });

    });

});

/***
 * 刷新时间计数器 
 */
var start = 60;
var step = -1;
function counter() {
    $("#counter").text(start);
    start += step;
    if (start < 0)
        start = 60;
    setTimeout("counter()", 1000);
}


/**
 * [计量点编辑]
 * @return {[type]}
 */
$(window).load(function () {

    //计量点编辑
    var measurePoint = window.dialogArguments;
    if (measurePoint == null) {
        return;
    }
    console.log(measurePoint);
    console.log(measurePoint.OpStatus);
    if (measurePoint.OpStatus == "edit") {
        $(".structure-tools").show();

        $(".meter").draggable();
        $("#structure").droppable({
            deactivate: function (event, ui) {
                //console.log(ui);
                //console.log(ui.draggable);

                var elementId = ui.draggable.attr("id");

                //console.log("ID:" + elementId + ",Left:" + ui.position.left + ",Top:" + ui.position.top);
              
            }
        });
    }

});
