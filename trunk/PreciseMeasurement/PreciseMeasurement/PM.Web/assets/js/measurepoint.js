/**
* 计量点
* 
* @author PING.CHEN
* @version 1.0
*/
$(function () {

    //双击打开
    $(".coordinate").dblclick(function () {
        var measurepointid = $("[id*=measurepointid]").val();
        var btnSave = $("[id*=btnSave]");
        console.log("measurepointid:" + measurepointid);
        if (measurepointid == "") {
            btnSave.click();
            return;
        }

        // console.log($(this));

        var measurePoint = { "Pointnum": $(".pointnum").val(), "Description": $(".description").val(), "X": $(".x").val(), "Y": $(".y").val(), "OpStatus": "edit" };

        var vReturnValue = window.showModalDialog("../../structure/default.aspx", measurePoint, "dialogHeight=900px;dialogWidth=1500px;center=yes;resizable=no;status=no;help=no;")

    });

    $("#btnCoordinate").click(function () {
        var measurePoint = { "Pointnum": '', "Description": '', "X": '', "Y": '', "OpStatus": "edit" };
        var vReturnValue = window.showModalDialog("../../structure/default.aspx", measurePoint, "dialogHeight=900px;dialogWidth=1500px;center=yes;resizable=no;status=no;help=no;")  
    });


    $("#btnDlgClassstructureid").click(function () {
        $('#Div1').modal('show')
    });
});