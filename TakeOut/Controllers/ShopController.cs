using AutoMapper;
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
    public class ShopController : TakeOutBaseController
    {
        private IShopService _shopService { get; set; }

        public ShopController()
        {
            _shopService = new ShopService();
        }

        // GET: Shop
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取店铺列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetAllShops()
        {
            return Json(Mapper.Map<List<ShopOutPutViewModel>> (_shopService.GetAllShopsInfo()), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// ById删除店铺
        /// </summary>
        /// <param name="shopId"></param>
        /// <returns></returns>
        public JsonResult DeleteShop(int shopId)
        {
            JsonReMsg re = new JsonReMsg();
            re.Status = _shopService.DeleteShopInfo(shopId) ? "OK" : "ERR";
            if (re.Status == "ERR")
            {
                re.Msg = "更新失败";
            }
            else
            {
                re.Data = Mapper.Map <List<ShopOutPutViewModel>>(_shopService.GetAllShopsInfo());
            }
            return Json(re, JsonRequestBehavior.AllowGet);

        }

        /// <summary>
        /// 添加OR修改
        /// </summary>
        /// <param name="newShop"></param>
        /// <returns></returns>
        /// <summary>
        public JsonResult AddOrUpdateShop(ShopInfoInput newShop)
        {
            JsonReMsg re = new JsonReMsg();
            re.Status = _shopService.AddOrUpdateShopInfo(newShop) ? "OK" : "ERR";
            if (re.Status == "ERR")
            {
                re.Msg = "更新失败";
            }
            else
            {
                re.Data = Mapper.Map<List<ShopOutPutViewModel>>(_shopService.GetAllShopsInfo());
            }
            return Json(re, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 审核状态改变
        /// </summary>
        public JsonResult ApplyStatusChange(int shopId, bool agree)
        {
            JsonReMsg re = new JsonReMsg();
            re.Status = _shopService.ApplyStatus(shopId, agree) ? "OK" : "ERR";
            if (re.Status == "ERR")
            {
                re.Msg = "更新失败";
            }
            else
            {
                re.Data = Mapper.Map<List<ShopOutPutViewModel>>(_shopService.GetAllShopsInfo());
            }
            return Json(re, JsonRequestBehavior.AllowGet);
        }



    }
}