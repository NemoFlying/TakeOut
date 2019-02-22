﻿window.onload = function () {
    var bodyH = $(window).height();
    $(".itemsBody").css("height", bodyH + "px");
    $(".search").on("click", function () {
        var searchVal = $(this).parents().find(".searchInput").val();
        window.location.href = 'search?name=' + searchVal;
    });
    $("#Admin").on("click", function () {
        window.location.href = 'index';
    });

    $(function () {

        $.post("../User/GetCurrentUser", {}, function (reData) {
            console.log(reData);
        })
    })

};