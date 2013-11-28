
/**
* 疏水器JS
* 
*
*
*
*
*
*@author PING.CHEN
*@version 1.0
*/
$(function () {

    //为开始、结束时间绑定日历控制
    $(".startdate").click(function () {
        WdatePicker({ lang: 'zh-cn', dateFmt: 'yyyy-MM-dd HH:mm', maxDate: '%y-%M-{%d}' })
    });

    $(".enddate").click(function () {
        WdatePicker({ lang: 'zh-cn', dateFmt: 'yyyy-MM-dd HH:mm', maxDate: '%y-%M-{%d}' })
    });


    $('input[name="datetype"]:radio').change(function () {
        AddEvent();
        var value = $(this).val();
        if (value == "MINUTE") {
            //  initHistoryMinute();
        } else {
            //  initHistoryHour();
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

    /**
    * 获取日期类型
    */
    function getDateType() {
        return $('.history input[name="datetype"]:checked').val();
    }

    function AddEvent() {
        var datetype = getDateType();
        if (datetype == "MINUTE") {
            $(".startdate").click(function () {
                WdatePicker({ lang: 'zh-cn', dateFmt: GetFormat(), maxDate: '%y-%M-%d %H' })
            });

            $(".enddate").click(function () {
                WdatePicker({ lang: 'zh-cn', dateFmt: GetFormat(), maxDate: '%y-%M-%d {%H + 12}' })
            });
        }
        else {
            $(".startdate").click(function () {
                WdatePicker({ lang: 'zh-cn', dateFmt: GetFormat(), maxDate: '%y-%M-{%d}' })
            });

            $(".enddate").click(function () {
                WdatePicker({ lang: 'zh-cn', dateFmt: GetFormat(), maxDate: '%y-%M-{%d + 1}' })
            });
        }
    }




});