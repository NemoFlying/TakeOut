using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TakeOut.DAL;
using TakeOut.ViewModels;

namespace TakeOut.Controllers
{
    public class HomeController : Controller
    {
        TakeOutContext dbcontext = new TakeOutContext();
        public ActionResult Index()
        {
            var kk = dbcontext.User.FirstOrDefault();
            return View();
        }

        public ActionResult Logon()
        {
            return View();
        }

        /// <summary>
        /// 用户登陆认证
        /// </summary>
        /// <param name="loginInput"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult LoginAuthentication(string logonUser,string password)
        {
            var md5 = new MD5CryptoServiceProvider();
            var passWord = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(logonUser + password)));
            passWord = passWord.Replace("-", "");
            var user = dbcontext.User
                .Where(con => con.LogonUser == logonUser && con.Password == passWord)
                .FirstOrDefault();
            var Result = new JsonReMsg()
            {
                Status = "OK"
            };
            if (user is null)
            {
                Result.Status = "ERR";
                user = dbcontext.User
                    .Where(con => con.LogonUser == logonUser)
                    .FirstOrDefault();
                if (user is null)
                {
                    Result.Msg = "用户尚未注册，请先注册";
                }
                else
                {
                    Result.Msg = "用户密码不符，请注意大小写！";
                }
            }
            else if(user.Locked=="Y")
            {
                Result.Msg = "账号被锁，请注意大小写！";
            }
            else
            {
                var userInfo = new UserInfo()
                {
                    User = user,
                    roles = new List<Models.Role>()
                };
                dbcontext.UserRole.Where(con => con.Id == user.Id).ToList().ForEach(item => userInfo.roles.Add(item.LogonRole));
                //认证通过KeepSession
                //var userInfo = new UserInfo()
                //{
                //    Certification = logonUser.Certification,
                //    HeadPortrait = logonUser.HeadPortrait,
                //    LogonUser = logonUser.LogonUser,
                //    UserType = logonUser.UserType,
                //    ClassId = new List<int>()
                //};
                //var classInfos = dbcontext.UserClass
                //    .Where(con => con.UserInfo.Id == logonUser.Id)
                //    .ToList();
                ////保存该用户加入的班级列表
                ////当有多个的时候在前端要用户进行选择【补充功能】
                //classInfos.ForEach(item => userInfo.ClassId.Add(item.ClassInfo.Id));
                //if (classInfos.Count == 1)
                //{
                //    //表示已经申请了一个班级
                //    userInfo.CurrentClass = classInfos[0].ClassInfo;
                //}
                ////保存Session
                //HttpContext.Session["userinfo"] = userInfo;

                Result.Data = userInfo;//将用户基本信息传回前台
            }
            return Json(Result, JsonRequestBehavior.AllowGet);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}