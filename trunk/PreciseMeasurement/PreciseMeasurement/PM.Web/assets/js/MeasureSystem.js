$(function () {

    $(".tab-content > div").hide();
    $(".NavButtons li").click(function () {
        var id = $(this).attr("class");
        $(".tab-content > div").hide();
        $("#" + id).show();
    });


});