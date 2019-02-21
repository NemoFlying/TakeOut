window.onload = function () {

    function ajaxData(data) {
        $(data).each(function () {
            $(".userTable tbody").append(`
                <tr>
                    <td>`+ this.Id + `</td>
                    <td>`+ this.LogonUser + `</td>
                    <td>`+ this.RoleName + `</td>
                    <td>`+ (this.Locked == 'N' ? '未禁用' : '锁定') + `</td>
                    <td>`+ this.ShopName + `</td>
                    <td><button class="layui-btn layui-btn-sm layui-btn-radius layui-btn-danger remove"><i class="layui-icon">&#xe640;</i></button></td>
                    <td><button class="layui-btn layui-btn-sm layui-btn-radius isable">解除禁用</button></td>
                    <td><button class="layui-btn layui-btn-sm layui-btn-radius layui-btn-danger disable">禁用</button></td>
                    <td><button class="layui-btn layui-btn-sm layui-btn-radius layui-btn-danger settingRole">设置角色</button></td>
                </tr>
            `)
        });
    };
    function GetAllRolesSelect(data) {

        $(data).each(function () {
            //console.log(this)
            $(".role").append(`
                <tr>
                    <td title='`+ this.Key + `'>` + this.Value + `</td>
                    <td width="10%"><button class="layui-btn layui-btn-sm layui-btn-radius layui-btn-danger remove"><i class="layui-icon removeBtn">&#xe640;</i></button></td>
                    <td width="10%"><button class="layui-btn layui-btn-sm layui-btn-radius layui-btn-normal roleUpDate"><i class="layui-icon">&#xe642;</i></button></td>
                </tr>
            `)
        });
    };
    $.ajax({
        async: true,
        type: "POST",
        url: "../User/GetAllUser",
        data: {},
        success: function (data) {
            //console.log(data);
            //if (data.Status == "OK") {
            //    alert("登录成功！");
            //    window.location.href = "../Home/Index2"

            //} else {
            //    alert("" + data.Msg + "，请重新登录！");
            //}
            ajaxData(data);
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
                            <button class="layui-btn disableBtn">确认禁用</button>
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
                            <button class="layui-btn isableBtn">确认提交</button>
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
                                    <select name="users" id="Role" lay-verify="required" style='margin: 9px 15px;width: 130px;'>
                                    </select>
                                </div>
                            </div>

                            <div class="layui-form-item">
                                <div class="layui-input-block">
                                    <button class="layui-btn nowBtn">立即提交</button>
                                </div>
                            </div>
                        `
                    });
                });


            });
            $(".userTable tbody .remove").on("click", function () {
                var layer = layui.layer;
                var id1 = $(this);
                var ID = $(this)[0].parentElement.parentElement.cells[0].innerText;
                $(".removeBtns").on("click", function () {
                    $.ajax({
                        async: true,
                        type: "POST",
                        url: "../User/DeleteUsers",
                        data: { userIds: [ID] },
                        success: function (reData) {
                            console.log(reData)
                            layer.close(layer.index);
                            $(".userTable tbody tr").remove();
                            ajaxData(reData.Data);
                        }
                    });
                });
            });

            $(".userTable tbody .disable").on("click", function () {
                var layer = layui.layer;
                var id1 = $(this);
                var ID = $(this)[0].parentElement.parentElement.cells[0].innerText;
                $(".disableBtn").on("click", function () {
                    $.ajax({
                        async: true,
                        type: "POST",
                        url: "../User/DisableOrEnableUserById",
                        data: { userId: ID, lockStatus: "Y" },
                        success: function (reData) {
                            console.log(reData)
                            layer.close(layer.index);
                            $(".userTable tbody tr").remove();
                            ajaxData(reData.Data);
                        }
                    });
                });
            });

            $(".userTable tbody .isable").on("click", function () {
                var layer = layui.layer;
                var id1 = $(this);
                var ID = $(this)[0].parentElement.parentElement.cells[0].innerText;
                $(".isableBtn").on("click", function () {
                    $.ajax({
                        async: true,
                        type: "POST",
                        url: "../User/DisableOrEnableUserById",
                        data: { userId: ID, lockStatus: "N" },
                        success: function (reData) {
                            console.log(reData)
                            layer.close(layer.index);
                            $(".userTable tbody tr").remove();
                            ajaxData(reData.Data);
                        }
                    });
                });
            });

            $(".userTable tbody .settingRole").on("click", function () {
                var layer = layui.layer;
                var id1 = $(this);
                var ID = $(this)[0].parentElement.parentElement.cells[0].innerText;
                $.ajax({
                    async: true,
                    type: "POST",
                    url: "../Role/GetAllRolesSelect",
                    success: function (reData) {
                        //layer.close(layer.index);
                        $(reData).each(function () {
                            //console.log(this);
                            $("#Role").append(`
                                    <option value="`+ this.Key + `">` + this.Value + `</option>
                            `);

                        });
                        var selecteds = $('#Role option:selected').attr("value");
                        $(".nowBtn").on("click", function () {
                            $.ajax({
                                async: true,
                                type: "POST",
                                url: "../User/SetUserRole",
                                data: { userId: ID, RoleId: selecteds },
                                success: function (reData) {
                                    console.log(reData)
                                    layer.close(layer.index);
                                    $(".userTable tbody tr").remove();
                                    ajaxData(reData.Data);
                                }
                            });
                        });
                    }
                });

                //$(".settingRoleBtn").on("click", function () {
                //    $.ajax({
                //        async: true,
                //        type: "POST",
                //        url: "../User/DisableOrEnableUserById",
                //        data: { userId: ID, lockStatus: "N" },
                //        success: function (reData) {
                //            console.log(reData)
                //            layer.close(layer.index);
                //            $(".userTable tbody tr").remove();
                //            ajaxData(reData.Data);
                //        }
                //    });
                //});
            });


        },
        error: function () {

        }
    });
    $.ajax({
        async: true,
        type: "POST",
        url: "../Role/GetAllRolesSelect",
        success: function (reData) {
            GetAllRolesSelect(reData);
            layui.use('layer', function () {
                var layer = layui.layer;
                //角色管理功能
                //删除
                $(".role .layui-btn-danger").on("click", function () {
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
                });
                //添加角色
                $(".role .addroleUpDate").on('click', function () {
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
                $(".role .roleUpDate").on('click', function () {
                    layer.open({
                        type: 1,
                        title: "修改",
                        content: `
                    <div class= "layui-form-item" >
                      <div class="layui-form-item">
                        <label class="layui-form-label">输入框</label>
                        <div class="layui-input-block">
                          <input type="text" name="roleUpDateName" required  lay-verify="required" value='' placeholder="请输入标题" autocomplete="off" class="layui-input roleUpDateName">
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
                });
            });
            $(".role .remove").on("click", function () {
                var ID = $(this)[0].parentElement.parentElement.cells[0].title;
                
                $(".roleRemoveBtns").on("click", function () {
                    console.log($(this));
                    
                    $.ajax({
                        async: true,
                        type: "POST",
                        url: "../Role/DeleteRole",
                        data: { roleId: ID},
                        success: function (reData) {
                            console.log(reData)
                            layer.close(layer.index);
                            $(".userTable tbody tr").remove();
                            GetAllRolesSelect(reData.Data);
                        }
                    });
                    //RoleIds
                });
            });
            $(".role .roleUpDate").on("click", function () {
                

                var roleUpDateName = $(".roleUpDateName");
                var roleUpDateNames = $(".roleUpDateName")[0].Value;
                console.log(roleUpDateName)
                console.log(roleUpDateNames)
                $(".roleUpDateBtns").on("click", function () {
                    console.log("123456")
                });
            });
        }

    });
};