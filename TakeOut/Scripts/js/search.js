$(function () {
    //穫取url中的參數
    function getQueryString(name) {
        var result = window.location.search.match(new RegExp("[\?\&]" + name + "=([^\&]+)", "i"));
        if (result == null || result.length < 1) {
            return "";
        }
        return result[1];
        //console.log(result[1])
    }
    var searchName = getQueryString("name");
    var searchNameUrl = decodeURIComponent(searchName);
    $("#storeFun").on("click", function () {
        window.location.href = 'storeFun'
    });
    console.log(searchNameUrl);
    //var pay = $("input[type='checkbox']:checked");
    $(".chooseBtn").on("click", function () {
        var Id = $(this).parents("tr").find("td:nth(0)").text();
        var Name = $(this).parents("tr").find("td:nth(0)").text();
        var Price = $(this).parents("tr").find("td:nth(0)").text();

        layui.use('layer', function () {
            var layer = layui.layer;
            layer.open({
                type: 1,
                title: "购物车",
                content: `
                    <div class= "layui-form-item shopAll" >
                      <div class="layui-form-item">
                        <label class="layui-form-label">ID</label>
                        <div class="layui-input-block">
                          <div><ul>
                                <li>`+ Id + `</li>
                                <li>`+ Name + `</li>
                                <li>`+ Price + `</li>
                                </ul>
                            </div>
                        </div>
                        <label class="layui-form-label">地址</label>
                        <div class="layui-input-block">
                          <input type="text" name="roleUpDateName" required  lay-verify="required" id='shopAddAddr' placeholder="请输入地址" autocomplete="off" class="layui-input shopAddAddr">
                        </div>
                        <label class="layui-form-label">电话</label>
                        <div class="layui-input-block">
                          <input type="text" name="roleUpDateName" required  lay-verify="required" id='shopAddPhone' placeholder="请输入电话" autocomplete="off" class="layui-input shopAddPhone">
                        </div>
                      </div>
                    </div>
                    <div class="layui-form-item">
                        <div class="layui-input-block">
                            <button class="layui-btn payForBtns">立即提交</button>
                        </div>
                    </div>
                    `
            });
            $(".payForBtns").on("click", function () {
                $.ajax({
                    async: true,
                    type: "POST",
                    //url: "../Shop/GetAllShops",
                    //data: {},
                    success: function (data) {
                        console.log(data);

                    }
                });
            });
        });
    });




    $.post("../User/GetAllUser", {}, function (reData) {
        //console.log(reData);
    })
})



//JavaScript代码区域
//Demo
layui.use('form', function () {
    var form = layui.form;

    //监听提交
    form.on('submit(formDemo)', function (data) {
        layer.msg(JSON.stringify(data.field));
        return false;
    });
});

//注意：选项卡 依赖 element 模块，否则无法进行功能性操作
layui.use('element', function () {
    var element = layui.element;

    //…
});
//function package() {
//    var pay = $("input[type='checkbox']:checked").parents("tr").find("td:nth(0)").text();
//    layui.use('layer', function () {
//        var layer = layui.layer;
//        layer.open({
//            type: 1,
//            title: "购物车",
//            content: `
//                    <div class= "layui-form-item shopAll" >
//                      <div class="layui-form-item">
//                        <label class="layui-form-label">ID</label>
//                        <div class="layui-input-block">
//                          <div>123</div>
//                        </div>
//                        <label class="layui-form-label">地址</label>
//                        <div class="layui-input-block">
//                          <input type="text" name="roleUpDateName" required  lay-verify="required" id='shopAddAddr' placeholder="请输入地址" autocomplete="off" class="layui-input shopAddAddr">
//                        </div>
//                        <label class="layui-form-label">电话</label>
//                        <div class="layui-input-block">
//                          <input type="text" name="roleUpDateName" required  lay-verify="required" id='shopAddPhone' placeholder="请输入电话" autocomplete="off" class="layui-input shopAddPhone">
//                        </div>
//                      </div>
//                    </div>
//                    <div class="layui-form-item">
//                        <div class="layui-input-block">
//                            <button class="layui-btn payForBtns">立即提交</button>
//                        </div>
//                    </div>
//                    `
//        });
//        $.ajax({
//            async: true,
//            type: "POST",
//            //url: "../Shop/GetAllShops",
//            //data: {},
//            success: function (data) {
//                console.log(data);

//                //layer.open({
//                //    type: 1,
//                //    title: "结束购买",
//                //    content: `
//                //    <div class= "layui-form-item shopAll" >
//                //        成功与否
//                //    </div>
//                //    `
//                //});
//            }
//        })
//    });
//}