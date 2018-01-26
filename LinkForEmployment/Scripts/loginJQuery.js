$(document).ready(function () {
    var g = $("#loginId").css("height").length;
    var ga = $("#loginId").css("height").substring(0, g - 2);
    if (ga > 360) {

        $(".page-footer").css("position", "absolute");
        $(".page-footer").css("bottom", "0px");

    }

});