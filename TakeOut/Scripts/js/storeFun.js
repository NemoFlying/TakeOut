$(function () {
    function getOrder(data) {
        console.log(data);
        $(data).each(function () {
            $(".orderManagement tbody").append(`
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td><button class="layui-btn layui-btn-radius layui-btn-danger removeOrder"><i class="layui-icon">&#xe640;</i>删除</button></td>
                    <td><button class="layui-btn layui-btn-radius layui-btn-normal updateOrder"><i class="layui-icon">&#xe642;</i>修改</button></td>
                </tr>
            `);
        });
    };
    function storeManagement(data) {
        console.log(data);
        $(data).each(function () {
            $(".storeManagement tbody").append(`
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td><button class="layui-btn layui-btn-radius layui-btn-danger removeOrder"><i class="layui-icon">&#xe640;</i>删除</button></td>
                    <td><button class="layui-btn layui-btn-radius layui-btn-normal updateOrder"><i class="layui-icon">&#xe642;</i>修改</button></td>
                </tr>
            `);
        });
    };
    //订单管理
    $.ajax({
        async: true,
        type: "POST",
        //url: "../Role/DeleteRole",
        //data: { roleId: ID },
        success: function (reData) {
            console.log(reData);
            layer.close(layer.index);
            //$(".userTable tbody tr").remove();
            //getStore(reData.Data);
            $(".removeOrder").on("click", function () {
                var OrderId = $(this).parents("tr").find(".td:nth(1)").text();
                layui.use('layer', function () {
                    var layer = layui.layer;
                    //角色管理功能
                    //删除
                    $(".orderManagement .removeOrder").on("click", function () {
                        layer.open({
                            type: 1,
                            title: "刪除",
                            content: `
                        <div style='height:100px;width:300px;'></div>
                        <div class="layui-input-block" style='margin-bottom:10px;'>
                            <button class="layui-btn roleRemoveBtns">确认删除</button>
                        </div>
                        `
                        });
                        $.ajax({
                            async: true,
                            type: "POST",
                            //url: "../Order/DeleteOrderById",
                            data: { OrderId: OrderId },
                            success: function (reData) {
                                //$(".orderManagement tbody tr").remove();
                                //getOrder(reData.Data);
                            }

                        });
                    });
                    //修改
                    $(".orderManagement .updateOrder").on('click', function () {
                        layer.open({
                            type: 1,
                            title: "修改",
                            content: `
                    <div class= "layui-form-item" >
                      <div class="layui-form-item">
                        <label class="layui-form-label">输入框</label>
                        <div class="layui-input-block">
                          <input type="text" name="roleUpDateName" required  lay-verify="required" id='roleUpDateName' placeholder="请输入标题" autocomplete="off" class="layui-input roleUpDateName">
                        </div>
                      </div>
                    </div>
                    <div class="layui-form-item">
                        <div class="layui-input-block">
                            <button class="layui-btn roleUpDateBtns">立即提交</button>
                            <button type="reset" class="layui-btn layui-btn-primary">重置</button>
                        </div>
                    </div>
                    `
                        });
                        $.ajax({
                            async: true,
                            type: "POST",
                            //url: "../Order/UpdateOrderInfo",
                            data: { OrderId: OrderId },
                            success: function (reData) {
                                //$(".orderManagement tbody tr").remove();
                                //getOrder(reData.Data);
                            }

                        });
                    });


                    //店家管理

                });

            });
        }
    });
    //店家管理
    $.ajax({
        async: true,
        type: "POST",
        //url: "../Order/GetCurrentShopOrder",
        //data: { roleId: ID },
        success: function (reData) {
            console.log(reData);
            layer.close(layer.index);
            //$(".userTable tbody tr").remove();
            //getStore(reData.Data);


            //删除
            $(".removeOrder").on("click", function () {
                var OrderId = $(this).parents("tr").find(".td:nth(1)").text();
                layui.use('layer', function () {
                    var layer = layui.layer;
                    
                    //删除
                    $(".storeManagement .removeOrder").on("click", function () {
                        layer.open({
                            type: 1,
                            title: "刪除",
                            content: `
                        <div style='height:100px;width:300px;'></div>
                        <div class="layui-input-block" style='margin-bottom:10px;'>
                            <button class="layui-btn roleRemoveBtns">确认删除</button>
                        </div>
                        `
                        });
                        $(".roleRemoveBtns").on("click", function () {
                            $.ajax({
                                async: true,
                                type: "POST",
                                //url: "../Order/DeleteOrderById",
                                data: { OrderId: OrderId },
                                success: function (reData) {
                                    //$(".orderManagement tbody tr").remove();
                                    //getStore(reData.Data);
                                }

                            });
                        });


                    });

                });
            });
            //修改
            $(".storeManagement .updateOrder").on('click', function () {
                layer.open({
                    type: 1,
                    title: "修改",
                    content: `
                    <div class= "layui-form-item" >
                      <div class="layui-form-item">
                        <label class="layui-form-label">输入框</label>
                        <div class="layui-input-block">
                          <input type="text" name="roleUpDateName" required  lay-verify="required" id='roleUpDateName' placeholder="请输入标题" autocomplete="off" class="layui-input roleUpDateName">
                        </div>
                      </div>
                    </div>
                    <div class="layui-form-item">
                        <div class="layui-input-block">
                            <button class="layui-btn orderUpDateBtns">立即提交</button>
                            <button type="reset" class="layui-btn layui-btn-primary">重置</button>
                        </div>
                    </div>
                    `
                });
                $(".orderUpDateBtns").on("click", function () {
                    $.ajax({
                        async: true,
                        type: "POST",
                        //url: "../Order/UpdateOrderInfo",
                        data: { OrderId: OrderId },
                        success: function (reData) {
                            //$(".orderManagement tbody tr").remove();
                            //getStore(reData.Data);
                        }

                    });
                });

            });
            //添加
            $(".storeManagement .AddStore").on("click", function () {
                layer.open({
                    type: 1,
                    title: "添加",
                    content: `
                            <div class= "layui-form-item shopAll" >
                              <div class="layui-form-item">
                                <label class="layui-form-label">菜品名称</label>
                                <div class="layui-input-block">
                                  <input type="text" name="roleUpDateName" required  lay-verify="required" id='orderAddName' placeholder="请输入角色名" autocomplete="off" class="layui-input orderAddName">
                                </div>
                                <label class="layui-form-label">图片信息</label>
                                <div class="layui-input-block">
                                  <input type="text" name="roleUpDateName" required  lay-verify="required" id='orderAddImg' placeholder="图片信息" autocomplete="off" class="layui-input orderAddImg">
                                </div>
                                <label class="layui-form-label">菜品价格</label>
                                <div class="layui-input-block">
                                  <input type="text" name="roleUpDateName" required  lay-verify="required" id='orderAddPrice' placeholder="菜品价格" autocomplete="off" class="layui-input orderAddPrice">
                                </div>
                                <label class="layui-form-label">单位</label>
                                <div class="layui-input-block">
                                  <input type="text" name="roleUpDateName" required  lay-verify="required" id='orderAddUnit' placeholder="单位" autocomplete="off" class="layui-input orderAddUnit">
                                </div>
                                <label class="layui-form-label">库存</label>
                                <div class="layui-input-block">
                                  <input type="text" name="roleUpDateName" required  lay-verify="required" id='orderAddInventory' placeholder="库存" autocomplete="off" class="layui-input orderAddInventory">
                                </div>
                              </div>
                            </div>
                            <div class="layui-form-item">
                                <div class="layui-input-block">
                                    <button class="layui-btn orderAddBtns">确认</button>
                                </div>
                            </div>
                        `
                });

                $(".orderAddBtns").on("click", function () {

                    $.ajax({
                        async: true,
                        type: "POST",
                        //url: "../Order/DeleteOrderById",
                        data: { OrderId: OrderId },
                        success: function (reData) {
                            //$(".orderManagement tbody tr").remove();
                            //getStore(reData.Data);
                        }

                    });
                });

            });
        }
    });
    
});