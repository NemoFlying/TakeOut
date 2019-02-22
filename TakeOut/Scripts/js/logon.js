
window.onload = function () {
    var bodyH = $(window).height();
    $("body").css({ "height": bodyH + "px" });
    $(".regBtn").on("click", function () {
        $(".login").hide();
        $(".reg").show();
    });

    $(".reg  .backBtn").on("click", function () {
        $(".login").show();
        $(".reg").hide();
    });
    //注册方法
    $(".reg  .loginBtn").on("click", function () {
        //var names = $(".reg input[name = 'names']").val();
        var UserName = $(".reg input[name = 'UserName']").val();
        var password = $(".reg input[name = 'password']").val();
        var sex = $(".reg #sex option:selected").val();
        var userImage = $(".reg input[name = 'image']").val();
        console.log(password);
        if (UserName == null || password == null) {
            alert("请填写注册信息！");
        } else {
            $(".loginBtn").attr("disabled", true);
            $.ajax({
                async: true,
                type: "POST",
                url: "../User/RegistUser",
                data: { LogonUser: UserName, Password: password, Sex: sex, HeadPortrait:"../img/header.png" },
                success: function (data) {
                    console.log(data);
                    if (data.Status == "OK") {
                        alert("注册成功！");
                        $(".login").show();
                        $(".reg").hide();
                        $(".loginBtn").attr("disabled", false);


                    } else {
                        alert("注册失败，请重新注册！");
                    }

                },
                error: function () {

                }
            })

        }
    });
    $(".login  .loginBtn").on("click", function () {
        var UserName = top.$(".login input[name = 'UserName']").val();
        var password = $(".login input[name = 'password']").val();
        if (UserName == null || password == null) {
            alert(UserName)
        } else {
            $.ajax({
                async: true,
                type: "POST",
                url: "../User/LoginAuthentication",
                data: { LogonUser: UserName, Password: password },
                success: function (data) {
                    console.log(data);
                    if (data.Status == "OK") {
                        //alert("登录成功！");
                        window.location.href = "../Home/Index2"

                    } else {
                        alert("" + data.Msg+"，请重新登录！");
                    }

                },
                error: function () {

                }
            })

        }
    });


};