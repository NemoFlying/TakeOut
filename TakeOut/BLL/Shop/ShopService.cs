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
    /// <summary>
    /// 店铺管理
    /// </summary>
    public class ShopService: IShopService
    {
        private readonly IShopDAL _shopDAL;
        private readonly IGoodsDAL _goodsDAL;
        //private readonly IShopGoodsDAL _shopGoodsDAL;

        public ShopService()
        {
            _shopDAL = new ShopDAL();
            _goodsDAL = new GoodsDAL();
            //_shopGoodsDAL = new ShopGoodsDAL();


        }

        /// <summary>
        /// 获得所有商店列表
        /// </summary>
        /// <returns></returns>
        public List<Shop> GetAllShopsInfo()
        {
            try
            {
                return _shopDAL.GetModels(con => 1 == 1).ToList();
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// 根据ID 删除商店信息
        /// </summary>
        /// <param name="shopId"></param>
        /// <returns></returns>
        public bool DeleteShopInfo(int shopId)
        {
            //删除商店基本信息
            _shopDAL.Delete(
                _shopDAL.GetModels(con => con.Id == shopId).FirstOrDefault()
                );
            try
            {
                _shopDAL.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 添加修改商店信息
        /// </summary>
        /// <param name="shopInput"></param>
        /// <returns></returns>
        public bool AddOrUpdateShopInfo(ShopInfoInput shopInput)
        {
            var shop = _shopDAL.GetModels(con => con.Id == shopInput.Id).FirstOrDefault();
            if(shop is null)
            {
                _shopDAL.Add(Mapper.Map<Shop>(shopInput));
            }
            else
            {
                shop.Name = shopInput.Name;
                shop.Addr = shopInput.Addr;
                shop.Phone = shopInput.Phone;
                shop.Locked = shopInput.Locked;
                _shopDAL.Update(shop);
            }
            try
            {
                _shopDAL.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 店铺申请审批
        /// </summary>
        /// <param name="shopId"></param>
        /// <param name="agree"></param>
        /// <returns></returns>
        public bool ApplyStatus(int shopId,bool agree)
        {
            var shopInfo = _shopDAL.GetModels(con => con.Id == shopId).FirstOrDefault();
            shopInfo.ApplyStaus = agree ? 1 : 2;
            shopInfo.Locked = agree ? "N" : "Y";
            _shopDAL.Update(shopInfo);
            try
            {
                _shopDAL.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
             
        }

    }
}