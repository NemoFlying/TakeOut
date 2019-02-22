using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeOut.BLL.Dto;
using TakeOut.Models;

namespace TakeOut.BLL
{
    public interface IGoodsService
    {
        /// <summary>
        /// 获得所有产品列表
        /// </summary>
        /// <returns></returns>
        List<Goods> GetAllGoodsByShopId(int shopId);

        /// <summary>
        /// 根据ID删除产品
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        bool DeleteProductByIds(List<int> GoodsIds);

        /// <summary>
        /// 添加产品
        /// </summary>
        /// <param name="newRole"></param>
        /// <returns></returns>
        bool AddGoodsInfo(GoodsInfoInput newGoods, int shopId);

        /// <summary>
        /// 更新产品信息
        /// </summary>
        /// <param name="newRole"></param>
        /// <returns></returns>
        bool UpdateProductInfo(GoodsInfoInput newGoods);
    }
}
