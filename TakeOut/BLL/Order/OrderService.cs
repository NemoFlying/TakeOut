using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TakeOut.BLL.Dto;
using TakeOut.DAL;
using TakeOut.Models;

namespace TakeOut.BLL
{
    public class OrderService: IOrderService
    {
        private readonly IOrderDAL _orderDAL;
        private readonly IUserDAL _userDAL;
        //private readonly IOrderGoodsDAL _orderGoodsDAL;
        private readonly IGoodsDAL _goodsDAL;

        public OrderService()
        {
            _orderDAL = new OrderDAL();
            _goodsDAL = new GoodsDAL();
            //_orderGoodsDAL = new OrderGoodsDAL();
            _userDAL = new UserDAL();

        }
        /// <summary>
        /// 根据店铺获得所有订单信息【一个订单上只能是同一个商家】
        /// </summary>
        /// <returns></returns>
        public List<Order> GetAllOrderByShopId(int shopId)
        {
            try
            {
                return _orderDAL.GetModels(con => con.Shop.Id == shopId).ToList();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 根据ID 删除订单信息
        /// </summary>
        /// <param name="shopId"></param>
        /// <returns></returns>
        public bool DeleteOrderInfo(int orderId)
        {
            //删除订单基本信息
            _orderDAL.Delete(
                _orderDAL.GetModels(con => con.Id == orderId).FirstOrDefault()
                );
            try
            {
                 _orderDAL.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        /// <summary>
        /// 根据ID 修改订单信息
        /// </summary>
        /// <param name="newOrder"></param>
        /// <returns></returns>
        public bool UpdateOrderInfo(OrderInfoInput newOrder)
        {
            var order = _orderDAL.GetModels(con => con.Id == newOrder.Id).FirstOrDefault();
            _orderDAL.Update(Mapper.Map(newOrder, order));
            try
            {
                 _orderDAL.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 创建订单[每个产品只能添加一次]
        /// </summary>
        /// <param name="newOrder"></param>
        /// <returns></returns>
        public bool CreateOrder(OrderInfoInput newOrder,List<int>goodsIds,int reqUserId)
        {
            var order = new Order();
            order = Mapper.Map(newOrder, order);
            order.Goods = _goodsDAL.GetModels(con => goodsIds.Contains(con.Id)).ToList();
            order.Shop = order.Goods.FirstOrDefault().Shop;
            order.OrderUser = _userDAL.GetModels(con => con.Id == reqUserId).FirstOrDefault();
            _orderDAL.Add(order);
            try
            {
                _orderDAL.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }



    }
}