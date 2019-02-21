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
            $(data).each(function () {
                $(".userTable tbody").append(`
                    <tr>
                        <td>`+this.Id+`</td>
                        <td>`+ this.LogonUser +`</td>
                        <td>`+ this.RoleName +`</td>
                        <td>`+ (this.Locked=='N'?'未禁用':'锁定')+`</td>
                        <td>`+ this.ShopName+`</td>
                        <td><button class="layui-btn layui-btn-sm layui-btn-radius layui-btn-danger remove"><i class="layui-icon">&#xe640;</i></button></td>
                        <td><button class="layui-btn layui-btn-sm layui-btn-radius isable">解除禁用</button></td>
                        <td><button class="layui-btn layui-btn-sm layui-btn-radius layui-btn-danger disable">禁用</button></td>
                        <td><button class="layui-btn layui-btn-sm layui-btn-radius layui-btn-warm isAdmin">设置管理员</button></td>
                        <td><button class="layui-btn layui-btn-sm layui-btn-radius layui-btn-danger settingRole">设置角色</button></td>
                    </tr>
                `)
            });
            layui.use('layer', function () {
                var layer = layui.layer;
                //用户管理
                $(".userTable .remove").on("click", function () {
                    layer.open({
                        type: 1,
                        title: "删除",
                        content: `
                        <div style='height:100px;width:300px;'></div>
                        <div class="layui-input-block" style='margin-bottom:10px;'>
                            <button class="layui-btn removeBtns">确认删除</button>
                        </div>
                        `
                    });
                });
                //删除
                $(".userTable .disable").on("click", function () {
                    layer.open({
                        type: 1,
                        title: "禁用",
                        content: `
                        <div style='height:100px;width:300px;'></div>
                        <div class="layui-input-block" style='margin-bottom:10px;'>
                            <button class="layui-btn">确认禁用</button>
                        </div>
                        `
                    });
                });
                $(".userTable .isable").on("click", function () {
                    layer.open({
                        type: 1,
                        title: "解除禁用",
                        content: `
                        <div style='height:100px;width:300px;'></div>
                        <div class="layui-input-block" style='margin-bottom:10px;'>
                            <button class="layui-btn">确认提交</button>
                        </div>
                        `
                    });
                });
                $(".userTable .isAdmin").on("click", function () {
                    layer.open({
                        type: 1,
                        title: "设置管理员",
                        content: `
                        <div style='height:100px;width:300px;'></div>
                        <div class="layui-input-block" style='margin-bottom:10px;'>
                            <button class="layui-btn">确认提交</button>
                        </div>
                        `
                    });
                });
                //设置角色
                $(".userTable .settingRole").on("click", function () {
                    layer.open({
                        type: 1,
                        title: "设置角色",
                        content: `
                            <div class="layui-form-item" style='height:100px;width:300px;'>
                                <label class="layui-form-label">选择框</label>
                                <div class="layui-input-block">
                                    <select name="users" lay-verify="required" style='margin: 9px 15px;width: 130px;'>
                                        <option value=""></option>
                                        <option value="0">admin</option>
                                        <option value="1">user</option>
                                        <option value="2">user1</option>
                                        <option value="3">user2</option>
                                        <option value="4">user3</option>
                                    </select>
                                </div>
                            </div>

                            <div class="layui-form-item">
                                <div class="layui-input-block">
                                    <button class="layui-btn">立即提交</button>
                                </div>
                            </div>
                        `
                    });
                });
                //角色管理功能
                //删除
                $(".role .layui-btn-danger").on("click", function () {
                    layer.open({
                        type: 1,
                        title: "刪除",
                        content: `
                        <div style='height:100px;width:300px;'></div>
                        <div class="layui-input-block" style='margin-bottom:10px;'>
                            <button class="layui-btn">确认删除</button>
                        </div>
                        `
                    });
                });
                //添加角色
                $(".role .layui-btn-normal").on('click', function () {
                    layer.open({
                        type: 1,
                        title: "添加角色",
                        content: `
                    <div class= "layui-form-item" >
                        <label class="layui-form-label">角色名</label>
                        <div class="layui-input-inline">
                            <input type="text" name="role" required lay-verify="required" placeholder="输入角色名称" autocomplete="off" class="layui-input">
                        </div>
                        <div class="layui-form-mid layui-word-aux" style='margin:0 50px;'>例如：user1</div>
                    </div>
                    <div class="layui-form-item">
                        <div class="layui-input-block">
                            <button class="layui-btn" lay-submit lay-filter="formDemo">立即提交</button>
                            <button type="reset" class="layui-btn layui-btn-primary">重置</button>
                        </div>
                    </div>
                    `
                    });
                });
                //storeTable
                $(".role .layui-btn-normal").on('click', function () {
                    layer.open({
                        type: 1,
                        title: "修改",
                        content: `
                    <div class= "layui-form-item" >
                        <label class="layui-form-label">用户名</label>
                        <div class="layui-input-inline">
                            <input type="text" name="role" required lay-verify="required" placeholder="用户名" autocomplete="off" class="layui-input">
                        </div>
                        <label class="layui-form-label">地址</label>
                        <div class="layui-input-inline">
                            <input type="text" name="role" required lay-verify="required" placeholder="地址" autocomplete="off" class="layui-input">
                        </div>
                        <label class="layui-form-label">电脑</label>
                        <div class="layui-input-inline">
                            <input type="text" name="role" required lay-verify="required" placeholder="电脑" autocomplete="off" class="layui-input">
                        </div>
                        <div class="layui-form-mid layui-word-aux" style='margin:0 50px;'>例如：user1</div>
                    </div>
                    <div class="layui-form-item">
                        <div class="layui-input-block">
                            <button class="layui-btn" lay-submit lay-filter="formDemo">立即提交</button>
                            <button type="reset" class="layui-btn layui-btn-primary">重置</button>
                        </div>
                    </div>
                    `
                    });
                });

            });
            $(".userTable tbody .remove").on("click", function () {
                var id1 = $(this);
                var ID = $(this)[0].parentElement.parentElement.cells[0].innerText;
                console.log("dsaoood");
                $(".removeBtns").on("click", function () {
                    console.log("dsadsa")
                    $.ajax({
                        async: true,
                        type: "POST",
                        url: "../User/DeleteUsers",
                        data: { userIds: [ID]},
                        success: function (data) {
                            console.log(data)
                        }
                    });
                });
            });
            //弹框
            
        },
        error: function () {

        }
    })
};