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
    public class OrderService
    {
        private readonly IOrderDAL _orderDAL;
        private readonly IUserDAL _userDAL;
        private readonly IOrderGoodsDAL _orderGoodsDAL;
        private readonly IGoodsDAL _goodsDAL;

        public OrderService()
        {
            _orderDAL = new OrderDAL();
            _goodsDAL = new GoodsDAL();
            _orderGoodsDAL = new OrderGoodsDAL();
            _userDAL = new UserDAL();

        }
        /// <summary>
        /// 获得所有订单列表
        /// </summary>
        /// <returns></returns>
        public List<Order> GetAllShopsInfo()
        {
            try
            {
                return _orderDAL.GetModels(con => 1 == 1).ToList();
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
            //删除订单商品商店产品信息
            _orderGoodsDAL.GetModels(con => con.OrderInfo.Id == orderId)
                .ToList()
                .ForEach(item => _orderGoodsDAL.Delete(item));
            try
            {
                _orderGoodsDAL.SaveChanges();
                return _orderDAL.SaveChanges();
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
                return _orderDAL.SaveChanges();
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
            //基本信息
            var order = new Order();
            order = Mapper.Map(newOrder, order);
            order.OrderUser = _userDAL.GetModels(con => con.Id == reqUserId).FirstOrDefault();
            _orderDAL.Add(order);
            goodsIds.ForEach(goodsId =>
            {
                _orderGoodsDAL.Add(new OrderGoods()
                {
                    GoodsInfo = _goodsDAL.GetModels(con => con.Id == goodsId).FirstOrDefault(),
                    OrderInfo = order,
                    GoodsNum = 1
                });
            });
            try
            {
                _orderDAL.SaveChanges();
                return _orderGoodsDAL.SaveChanges();
            }
            catch
            {
                return false;
            }
            
        }



    }
}