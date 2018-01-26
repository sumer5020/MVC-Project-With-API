var d,c,f,e;

$(document).ready(function () {
     d = $("#Right-side").css("height").length;
     c = $("#Right-side").css("height").substring(0, d - 2);

     e = $("#left-side").css("height").length;
     f = $("#left-side").css("height").substring(0, e - 2);
    //976px
    if (f < c) {
        $("#left-side").css("height", parseInt(parseInt(c) + 100) + "px");
    }
});

$(window).resize(function () {
    if ($("#left-side").css("width") > "976px") {
         $("#left-side").css("height", parseInt(parseInt(c) + 100) + "px");
     }
    if ($("#left-side").css("width") < "976px") {
        $("#left-side").css("height", c + "px");
    }
});