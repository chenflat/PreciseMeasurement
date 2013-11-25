/**
* 计量点
* 
* @author PING.CHEN
* @version 1.0
*/
$(function () {

    $(".coordinate").dblclick(function () {

        console.log($(this));

        var measurePoint = { "Pointnum": $(".pointnum").val(), "Description": $(".description").val(), "X": $(".x").val(), "Y": $(".y").val(),"OpStatus":"edit"};

        var vReturnValue = window.showModalDialog("../../structure/default.aspx", measurePoint, "dialogHeight=900px;dialogWidth=1500px;center=yes;resizable=no;status=no;help=no;")
    });


});