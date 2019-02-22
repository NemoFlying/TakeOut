using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeOut.BLL.Dto;
using TakeOut.Models;

namespace TakeOut.BLL
{
    public interface IShopService
    {
        /// <summary>
        /// 获得所有商店列表
        /// </summary>
        /// <returns></returns>
        List<Shop> GetAllShopsInfo();

        /// <summary>
        /// 根据ID 删除商店信息
        /// </summary>
        /// <param name="shopId"></param>
        /// <returns></returns>
        bool DeleteShopInfo(int shopId);

        /// <summary>
        /// 添加修改商店信息
        /// </summary>
        /// <param name="shopInput"></param>
        /// <returns></returns>
        bool AddOrUpdateShopInfo(ShopInfoInput shopInput,int currentUid);

        /// <summary>
        /// 店铺申请审批
        /// </summary>
        /// <param name="shopId"></param>
        /// <param name="agree"></param>
        /// <returns></returns>
        bool ApplyStatus(int shopId, bool agree);



    }
}
