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
    public class UserController : Controller
    {
        private IUserService _userService { get; set; }


        public UserController()
        {
            _userService = new UserService();
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 用户登陆认证
        /// </summary>
        /// <param name="loginInput"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult LoginAuthentication(string logonUser, string password)
        {
            var reData = new JsonReMsg() { Status = "ERR" };
            if(string.IsNullOrEmpty(logonUser)||string.IsNullOrEmpty(password))
            {
                reData.Msg = "请输入完整信息！";
                return Json(reData, JsonRequestBehavior.AllowGet);
            }
            var result = _userService.LogonAuthentication(logonUser, password);

            switch(result)
            {
                
                case "1":
                    reData.Msg = "账号不存在";
                    break;
                case "2":
                    reData.Msg = "账号密码不符";
                    break;
                case "3":
                    reData.Msg = "账号被锁定";
                    break;
                case "0":
                default:
                    reData.Status = "OK";
                    break;
            }

            return Json(reData, JsonRequestBehavior.AllowGet);

        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult RegistUser(RegistUserInfoInput userInfo)
        {
            var reData = new JsonReMsg() { Status = _userService.RegistUser(userInfo) ? "OK" : "ERR" };
            if(reData.Status=="ERR")
            {
                reData.Msg = "注册失败,请联系管理员!";
            }
            return Json(reData, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetAllUser()
        {
            return Json(_userService.GetAllUserInfo(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 根据Id删除用户信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteUsers(List<int> userIds)
        {
            var reData = new JsonReMsg() { Status = _userService.DeleteModlesByIds(userIds) ? "OK" : "ERR" };
            if (reData.Status == "ERR")
            {
                reData.Msg = "删除失败,请联系管理员!";
            }
            return Json(reData, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 解锁锁定用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DisableOrEnableUserById(int userId,string lockStatus)
        {
            var reData = new JsonReMsg() { Status = _userService.DisableOrEnableUserById(userId, lockStatus) ? "OK" : "ERR" };
            if (reData.Status == "ERR")
            {
                reData.Msg = "删除失败,请联系管理员!";
            }
            return Json(reData, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 设置用户角色
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SetUserRole(int userId, int RoleId)
        {
            var reData = new JsonReMsg() { Status = _userService.SetUserRole(userId, RoleId) ? "OK" : "ERR" };
            if (reData.Status == "ERR")
            {
                reData.Msg = "删除失败,请联系管理员!";
            }
            return Json(reData, JsonRequestBehavior.AllowGet);
        }


    }
}