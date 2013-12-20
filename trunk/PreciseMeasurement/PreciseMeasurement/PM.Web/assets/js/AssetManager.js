
/**
* 资产管理
*/
$(function () {

    // parentAsset

    $(".select2").select2();


    $(".coordinate").dblclick(function () {

        var asset = { "Assetnum": $(".assetnum").val(), "Description": $(".description").val(), "X": $(".x").val(), "Y": $(".y").val(), "OpStatus": "edit" };
        var vReturnValue = window.showModalDialog("../../steamtrap/default.aspx", asset, "dialogHeight=900px;dialogWidth=1500px;center=yes;resizable=no;status=no;help=no;")
    });


    //coordinate
});