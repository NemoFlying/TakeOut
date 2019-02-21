using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TakeOut.BLL;
using TakeOut.BLL.Dto;
using TakeOut.ViewModels;

namespace TakeOut.Controllers
{
    public class RoleController : TakeOutBaseController
    {
        private IRoleService _roleService { get; set; }

        public RoleController()
        {
            _roleService = new RoleService();
        }

        // GET: Role
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAllRolesSelect()
        {
            List<SelectOptionModel> options = new List<SelectOptionModel>();
            _roleService.GetAllRolesInfo().ForEach(item =>
                options.Add(
                    new SelectOptionModel()
                    {
                        Key = item.Id.ToString(),
                        Value = item.Name
                    }
                    )
            );
            return Json(options, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 获得所有角色信息【不进行分页】
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAllRoles()
        {
            return Json(_roleService.GetAllRolesInfo(),JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 添加OR修改
        /// </summary>
        /// <param name="newrole"></param>
        /// <returns></returns>
        public JsonResult AddOrUpdateRole(RoleInfoInput newrole)
        {
            JsonReMsg re = new JsonReMsg();
            re.Status = _roleService.AddOrUpdateRoleModle(newrole) ? "OK" : "ERR";
            if (re.Status == "ERR")
            {
                re.Msg = "更新失败";
            }
            else
            {
                re.Data = _roleService.GetAllRolesInfo();
            }
            return Json(re, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 
        /// ById删除角色返回角色列表
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public JsonResult DeleteRole(int roleId)
        {
            JsonReMsg re = new JsonReMsg();
            re.Status = _roleService.DeleteModlesByIds(new List<int>() { roleId}) ? "OK" : "ERR";
            if (re.Status == "ERR")
            {
                re.Msg = "更新失败";
            }
            else
            {
                re.Data = _roleService.GetAllRolesInfo();
            }
            return Json(re, JsonRequestBehavior.AllowGet);

        }

    }
}