
/**
* 曲线对比
**/
$(function () {

    $(".analysis .startdate").click(function () {
        WdatePicker({ lang: 'zh-cn', dateFmt: 'yyyy-MM-dd', maxDate: '%y-%M-{%d} 00:00' })
    });

    $(".analysis .enddate").click(function () {
        WdatePicker({ lang: 'zh-cn', dateFmt: 'yyyy-MM-dd', maxDate: '%y-%M-{%d}' })
    });


    //初始化分钟
    function initHistoryMinute() {
        $(".analysis .startdate").val(new Date().addHours(-10).toString("yyyy-MM-dd HH:mm"));
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
        var text = $(this).text();
        var id = $(this).attr("id");
        var li = "<li id='" + id + "'>" + text + "</li>";
        if (!hasPointElement(text)) {
            $("#container-measurepoints").append(li);
        }
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


    //获取比较参数据
    function getCompareParams() {
        var params = new Array();
        $("#container-params li").each(function (index, obj) {
            params.push($(obj).attr("id"));
        });
        return params;
    }

    function getComparePoints() {
        var points = new Array();
        $("#container-measurepoints li").each(function (index, obj) {
            params.push($(obj).attr("id"));
        });
        return params;
    }


    //保存设置
    $("#btnSetting").click(function () {

    });

    //生成曲线
    $("#btnQuery").click(function () {

        //比较参数
        var params = getCompareParams();

        for (var i = 0; i < params.length; i++) { 
            


        }

    });


});