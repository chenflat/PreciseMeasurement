
/**
* 疏水器实时数据
*/
$(function () {


    //每60秒自动重新获取实时数据
    setInterval(getRealData, 60000);
    getRealData()

    /**
    * 获取所有测点的实时数据
    */
    function getRealData() {

        $("#gvRealtimeData tbody").html("");
        var content = "";
        //获取所有测点对应的实时数据
        $.getJSON('../services/GetAjaxData.ashx', { "funname": "GetAsssetRealtimeMeasureValue", "specclass": "STEAM", "specsubclass": "STEAMTRAP" }, function (data) {
            //设置计量点数值
            $.each(data, function (index, obj) {
                var mstyle = "";

                var level = 1;
                var measuretime = "";
                var front_temperature = "0"
                var after_temperature = "0"
                var diff_temperature = "0"
                var status = "";   //疏水 直通  堵塞

                if (obj.Measurements.length > 0) {
                    if ((new Date(obj.Measurements[0].Measuretime).toString('yyyy-MM-dd')) == '1900-01-01') {
                        mstyle = " style='color:red;'";
                    }
                    measuretime = obj.Measurements[0].Measuretime;
                    front_temperature = obj.Measurements[0].SwTemperature;
                    after_temperature = obj.Measurements[1].SwTemperature;
                    diff_temperature = parseFloat(front_temperature) - parseFloat(after_temperature);
                    console.log(measuretime);
                }

                content += "<tr " + mstyle + ">"
                content += "<td>" + level + "级</td>"
                content += "<td>[" + obj.AssetInfo.Assetnum + "]" + obj.AssetInfo.Description + "</td>"
                content += "<td>" + measuretime + "</td>"
                content += "<td>" + front_temperature + "</td>"
                content += "<td>" + after_temperature + "</td>"
                content += "<td>" + diff_temperature + "</td>"
                content += "<td>" + status + "</td>"
                content += "</tr>";

            });

            $("#gvRealtimeData tbody").append(content);
        });
    }



});