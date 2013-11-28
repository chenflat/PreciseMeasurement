
/**
* 阀门JS
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

    //时间类型
    var datetype = $('input[name="datetype"]:checked').val();

    //为开始、结束时间绑定日历控制
    $(".startdate").click(function () {
        WdatePicker({ lang: 'zh-cn', dateFmt: 'yyyy-MM-dd HH:mm', maxDate: '%y-%M-{%d}' })
    });

    $(".enddate").click(function () {
        WdatePicker({ lang: 'zh-cn', dateFmt: 'yyyy-MM-dd HH:mm', maxDate: '%y-%M-{%d}' })
    });






});