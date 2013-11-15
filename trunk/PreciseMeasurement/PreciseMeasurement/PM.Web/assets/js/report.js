$(function () {

    $(".startdate").click(function () {
        WdatePicker({ lang: 'zh-cn', dateFmt: 'yyyy-MM-dd', maxDate: '%y-%M-{%d}' })
    });

    $(".enddate").click(function () {
        WdatePicker({ lang: 'zh-cn', dateFmt: 'yyyy-MM-dd', maxDate: '%y-%M-{%d}' })
    });

    initQueryDate();



    $(".btnQuery").click(function () {


    });

});



function initQueryDate () {
    var $startdate = $(".startdate");
    var $enddate = $(".enddate");

    if ($startdate.val() == '') {
        $enddate.val(Date.today().addDays(-1).toString("yyyy-MM-dd"));
        $startdate.val(Date.today().addDays(-8).toString("yyyy-MM-dd"));
    }
    
}
