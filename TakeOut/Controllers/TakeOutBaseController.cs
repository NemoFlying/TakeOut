using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TakeOut.ViewModels;

namespace TakeOut.Controllers
{
    public class TakeOutBaseController : Controller
    {
        // GET: TakeOutBase
        /// <summary>
        /// 全局用户信息
        /// </summary>
        protected UserInfo GuserInfo => (UserInfo)HttpContext.Session["userinfo"];
    }
}