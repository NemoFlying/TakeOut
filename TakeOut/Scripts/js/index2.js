window.onload = function () {
    var bodyH = $(window).height();
    $(".itemsBody").css("height", bodyH + "px");
    function () {

    };
    //搜索数据事件
    $(".search").on("click", function () {
        var searchInput = $(".searchInput").val();
        console.log(searchInput);
        $.ajax({

        });
    });

    
};