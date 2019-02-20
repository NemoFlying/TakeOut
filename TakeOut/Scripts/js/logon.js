
window.onload = function () {
    var bodyH = $(window).height();
    $("body").css({ "height": bodyH + "px" });
    $(".regBtn").on("click", function () {
        $(".login").hide();
        $(".reg").show();
    });
    $(".loginBtn").on("click", function () {
        $(".login").show();
        $(".reg").hide();
    });
}