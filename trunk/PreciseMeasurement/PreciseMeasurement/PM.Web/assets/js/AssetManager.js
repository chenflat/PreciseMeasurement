
/**
* 资产管理
*/
$(function () {

    // parentAsset

    


    $(".coordinate").dblclick(function () {

        var asset = { "Assetnum": $(".assetnum").val(), "Description": $(".description").val(), "X": $(".x").val(), "Y": $(".y").val(), "OpStatus": "edit" };
        var vReturnValue = window.showModalDialog("../../structure/steamtrap.aspx", asset, "dialogHeight=900px;dialogWidth=1500px;center=yes;resizable=no;status=no;help=no;")
    });


    //coordinate
});