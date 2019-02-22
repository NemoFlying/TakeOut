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
            var kkk = dbcontext.Goods.Where(con=>con.Name== "Product1").FirstOrDefault();
            var kkks = dbcontext.Shop.Where(
                con => con.Goods.Contains(
                    dbcontext.Goods.Where(con2 => con2.Name == "Product1").FirstOrDefault()
                    )
                );
            return View();
        }
        public ActionResult Index2()
        {
            return View();
        }

        public ActionResult Logon()
        {
            return View();
        }
        public ActionResult search()
        {
            return View();
        }
        public ActionResult StoreFun()
        {
            return View();
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