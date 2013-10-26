$(function () {

    $(".reporttype").change(function () {
        var type = $(".reporttype").val();
        if (type == 'WEEK') {



        } else if (type == 'MONTH') {
            $(".startdate").click(function () {

                WdatePicker({ lang: 'zh-cn', dateFmt: 'yyyy-MM', maxDate: '%y-%M-{%d}' })
            });

            $(".endzone").hide();
        } else {
            $(".endzone").show();


            $(".startdate").click(function () {

                WdatePicker({ lang: 'zh-cn', dateFmt: 'yyyy-MM-dd', maxDate: '%y-%M-{%d}' })

            });

            $(".enddate").click(function () {

                WdatePicker({ lang: 'zh-cn', dateFmt: 'yyyy-MM-dd', maxDate: '%y-%M-{%d}' })

            });
        }

        console.log(type);
    });


    $(".startdate").click(function () {

        WdatePicker({ lang: 'zh-cn', dateFmt: 'yyyy-MM-dd', maxDate: '%y-%M-{%d}' })

    });

    $(".enddate").click(function () {

        WdatePicker({ lang: 'zh-cn', dateFmt: 'yyyy-MM-dd', maxDate: '%y-%M-{%d}' })

    });


    $(".btnQuery").click(function () {


    });

});