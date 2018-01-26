$(document).ready(function () {
    var d = $("#cont").css("height").length;
    var c = $("#cont").css("height").substring(0, d - 2);

    if (c < 360) {

        $(".page-footer").css("position", "absolute");
        $(".page-footer").css("bottom", "0px");

    }

});