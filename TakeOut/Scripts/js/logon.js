﻿
window.onload = function () {
    var bodyH = $(window).height();
    $("body").css({ "height": bodyH + "px" });
    //$(".regBtn").on("click", function () {
    //    $(".login").hide();
    //    $(".reg").show();
    //});
    //$(".loginBtn").on("click", function () {
    //    $(".login").show();
    //    $(".reg").hide();
    //});
    //注册方法
    $(".loginBtn").on("click", function () {
        var names = $(".reg input[name = 'names']").val();
        var UserName = $(".reg input[name = 'UserName']").val;
        var password = $(".reg input[name = 'password']").val;
        var sex = $(".reg #sex option:selected").val;
        var userImage = $(".reg input[name = 'image']").val;
        //$.ajax({
        //    async: true,
        //    type: "POST",
        //    url: "../../Controllers/Home/LoginAuthentication",
        //    data: {  },
        //    success: function () {

        //    },
        //    error: function () {

        //    }
        //})

        $.post("../User/LoginAuthentication", { logonUser: "Jerry", password:"985190626"}, function (reData) {
            console.log(reData);
        });
    });
}