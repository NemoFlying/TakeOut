window.onload = function () {
    $.ajax({
        async: true,
        type: "POST",
        url: "../User/GetAllUser",
        data: {},
        success: function (data) {
            console.log(data);
            //if (data.Status == "OK") {
            //    alert("登录成功！");
            //    window.location.href = "../Home/Index2"

            //} else {
            //    alert("" + data.Msg + "，请重新登录！");
            //}

        },
        error: function () {

        }
    })
};