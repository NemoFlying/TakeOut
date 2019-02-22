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
    public class OrderController : TakeOutBaseController
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }


        private IOrderService _orderService { get; set; }
        // GET: Goods
        public OrderController()
        {
            _orderService = new OrderService();
        }

        /// <summary>
        /// 获取当前店铺所有菜单列表
        /// </summary>
        /// <returns></returns>
        public JsonResult GetCurrentShopOrder()
        {
            return Json(AutoMapper.Mapper.Map<List<OrderOutPutViewModel>>(_orderService.GetAllOrderByShopId(1))
                , JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public JsonResult DeleteOrderById(int OrderId)
        {
            JsonReMsg re = new JsonReMsg();
            re.Status = _orderService.DeleteOrderInfo(OrderId) ? "OK" : "ERR";
            if (re.Status == "ERR")
            {
                re.Msg = "更新失败";
            }
            else
            {
                re.Data = AutoMapper.Mapper.Map<List<GoodsOutputViewModel>>(_orderService.GetAllOrderByShopId(1));
            }
            return Json(re, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 更新订单信息
        /// </summary>
        /// <param name="newRole"></param>
        /// <returns></returns>
        public JsonResult UpdateOrderInfo(OrderInfoInput orderInfo)
        {
            JsonReMsg re = new JsonReMsg();
            re.Status = _orderService.UpdateOrderInfo(orderInfo) ? "OK" : "ERR";
            if (re.Status == "ERR")
            {
                re.Msg = "更新失败";
            }
            else
            {
                re.Data = AutoMapper.Mapper.Map<List<GoodsOutputViewModel>>(_orderService.GetAllOrderByShopId(1));
            }
            return Json(re, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="newRole"></param>
        /// <returns></returns>
        public JsonResult CreateOrder(OrderInfoInput orderInfo,List<int>goodsIds)
        {
            JsonReMsg re = new JsonReMsg();
            re.Status = _orderService.CreateOrder(orderInfo, goodsIds,GuserInfo.Id) ? "OK" : "ERR";
            if (re.Status == "ERR")
            {
                re.Msg = "更新失败";
            }
            else
            {
                re.Data = AutoMapper.Mapper.Map<List<GoodsOutputViewModel>>(_orderService.GetAllOrderByShopId(1));
            }
            return Json(re, JsonRequestBehavior.AllowGet);
        }


    }
}