window.onload = function () {
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
            if (reData.RoleName == "admin") {
                $(".adminLi").append(`
                        < button id = "Admin" class= "layui-btn layui-btn-sm layui-btn-radius layui-btn-danger" > <i class="layui-icon">&#xe66f;</i>管理员</button >
                    `
                )
            } else if (reData.RoleName == "user" || reData.ShopName == null) {
                $(".adminLi").append(`
                    <div><a href=''>亲可以申请为商家哟！</a></div>
                `);
            }
            else if (reData.ShopApplyStatus == "1") {
                //申请中
                $(".adminLi").append(`
                    <div><a href='' style='color:white;'>在申请中，请耐心等待！</a></div>
                `);
            }
            else if (reData.ShopApplyStatus == "0") {
                //通过
                $(".adminLi").append(`
                        < button id = "storeFun" class= "layui-btn layui-btn-sm layui-btn-radius layui-btn-danger" > <i class="layui-icon">&#xe66f;</i>店铺管理</button >
                    `
                )
            }
        })
    })

};
