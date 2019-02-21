
window.onload = function () {
    var bodyH = $(window).height();
    $("body").css({ "height": bodyH + "px" });
    //$(".regBtn").on("click", function () {
    //    $(".login").hide();
    //    $(".reg").show();
    //});
    //注册方法
    $(".loginBtn").on("click", function () {
        var names = $(".reg input[name = 'names']").val();
        var UserName = $(".reg input[name = 'UserName']").val();
        var password = $(".reg input[name = 'password']").val();
        var sex = $(".reg #sex option:selected").val();
        var userImage = $(".reg input[name = 'image']").val();
        console.log(password);
        $.ajax({
            async: true,
            type: "POST",
            url: "../User/RegistUser",
            data: { LogonUser: UserName, Password: password},
            success: function (data) {
                console.log(data);
                if (data.Status == "ok") {
                    $(".login").show();
                    $(".reg").hide();
                } else {
                    alert("抱歉注册失败！请重新注册");
                }
            },
            error: function () {

            }
        })

        //$.post("../User/LoginAuthentication", { logonUser: "Jerry", password:"985190626"}, function (reData) {
        //    console.log(reData);
        //});
    });
}