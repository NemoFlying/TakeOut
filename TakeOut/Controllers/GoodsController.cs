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
    public class GoodsController : TakeOutBaseController
    {
        private IGoodsService _goodsService { get; set; }
        // GET: Goods
        public ActionResult Index()
        {
            return View();
        }

        public GoodsController()
        {
            _goodsService = new GoodsService();
        }
        /// <summary>
        /// 获取当前店铺所有菜单列表
        /// </summary>
        /// <returns></returns>
        public JsonResult GetCurrentShopProduct()
        {
            return Json( AutoMapper.Mapper.Map<List<GoodsOutputViewModel>>(_goodsService.GetAllGoodsByShopId(1))
                , JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除产品名称
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public JsonResult DeleteProductById(int productId)
        {
            JsonReMsg re = new JsonReMsg();
            re.Status = _goodsService.DeleteProductByIds(new List<int>() { productId}) ? "OK" : "ERR";
            if (re.Status == "ERR")
            {
                re.Msg = "更新失败";
            }
            else
            {
                re.Data = AutoMapper.Mapper.Map<List<GoodsOutputViewModel>>(_goodsService.GetAllGoodsByShopId(1));
            }
            return Json(re, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除产品名称
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public JsonResult AddProductInfo(GoodsInfoInput goodInfo)
        {
            JsonReMsg re = new JsonReMsg();
            re.Status = _goodsService.AddGoodsInfo(goodInfo, 1) ? "OK" : "ERR";
            if (re.Status == "ERR")
            {
                re.Msg = "更新失败";
            }
            else
            {
                re.Data = AutoMapper.Mapper.Map<List<GoodsOutputViewModel>>(_goodsService.GetAllGoodsByShopId(1));
            }
            return Json(re, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 更新产品信息
        /// </summary>
        /// <param name="newRole"></param>
        /// <returns></returns>
        public JsonResult UpdateProductInfo(GoodsInfoInput goodInfo)
        {
            JsonReMsg re = new JsonReMsg();
            re.Status = _goodsService.UpdateProductInfo(goodInfo) ? "OK" : "ERR";
            if (re.Status == "ERR")
            {
                re.Msg = "更新失败";
            }
            else
            {
                re.Data = AutoMapper.Mapper.Map<List<GoodsOutputViewModel>>(_goodsService.GetAllGoodsByShopId(1));
            }
            return Json(re, JsonRequestBehavior.AllowGet);
        }


    }
}