using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TakeOut.BLL.Dto;
using TakeOut.ViewModels;

namespace TakeOut.Controllers
{
    public class TakeOutBaseController : Controller
    {
        // GET: TakeOutBase
        /// <summary>
        /// 全局用户信息
        /// </summary>
        protected UserInfoOutput GuserInfo => (UserInfoOutput)HttpContext.Session["userinfo"];
    }
}