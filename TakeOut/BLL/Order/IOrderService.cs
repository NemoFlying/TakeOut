using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeOut.Models;
using TakeOut.BLL.Dto;
namespace TakeOut.BLL
{
    public interface IOrderService
    {
        /// <summary>
        /// 根据店铺获得所有订单信息【一个订单上只能是同一个商家】
        /// </summary>
        /// <returns></returns>
        List<Order> GetAllOrderByShopId(int shopId);

        /// <summary>
        /// 根据ID 删除订单信息
        /// </summary>
        /// <param name="shopId"></param>
        /// <returns></returns>
        bool DeleteOrderInfo(int orderId);

        /// <summary>
        /// 根据ID 修改订单信息
        /// </summary>
        /// <param name="newOrder"></param>
        /// <returns></returns>
        bool UpdateOrderInfo(OrderInfoInput newOrder);

        /// <summary>
        /// 创建订单[每个产品只能添加一次]
        /// </summary>
        /// <param name="newOrder"></param>
        /// <returns></returns>
        bool CreateOrder(OrderInfoInput newOrder, List<int> goodsIds, int reqUserId);
    }
}
