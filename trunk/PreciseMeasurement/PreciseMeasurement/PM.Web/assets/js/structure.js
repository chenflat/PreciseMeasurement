/**
 * 系统结构图
 * @author: PING.CHEN
 * @version: 1.0 build20131121
 */

$(function () {

    /**
    *
    */
    $("#structure div").click(function () {
        console.log($(this).attr("id"));

        var template: '<div class="popover"><div class="arrow"></div><h3 class="popover-title">'+ $(this).attr("title") +'</h3><div class="popover-content"></div></div>'

        //$(this).popover(popOverSettings);

        $(this).


    });

   
});
