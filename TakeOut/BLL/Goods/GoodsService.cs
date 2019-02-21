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
    public class GoodsService
    {
        private readonly IGoodsDAL _goodsDAL;
        private readonly IShopDAL _shopDAL;
        private readonly IShopGoodsDAL _shopGoodsDAL;
        public GoodsService()
        {
            _goodsDAL = new GoodsDAL();
            _shopGoodsDAL = new ShopGoodsDAL();
        }
        /// <summary>
        /// 获得所有产品列表
        /// </summary>
        /// <returns></returns>
        public List<Goods> GetAllGoodsInfo()
        {
            try
            {
                return _goodsDAL.GetModels(con => 1 == 1).ToList();
            }
            catch
            {
                return null;
            }

        }

        /// <summary>
        /// 根据ID删除产品
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public bool DeleteModlesByIds(List<int> GoodsIds)
        {
            GoodsIds.ForEach(id =>
            {
                //删除基本信息
                _goodsDAL.Delete(
                    _goodsDAL.GetModels(con => con.Id == id)
                    .FirstOrDefault()
                    );
                //删除产品商店列表
                _shopGoodsDAL.GetModels(con => con.GoodsInfo.Id == id)
                .ToList()
                .ForEach(item => _shopGoodsDAL.Delete(item));
            });
            
            try
            {
                _shopGoodsDAL.SaveChanges();
                return _goodsDAL.SaveChanges();
            }
            catch
            {
                //日志记录
                return false;
            }
        }

        /// <summary>
        /// 添加产品
        /// </summary>
        /// <param name="newRole"></param>
        /// <returns></returns>

        public bool AddGoodsModle(GoodsInfoInput newGoods, int shopId)
        {
            //添加基本信息
            var goods = Mapper.Map<Goods>(newGoods);
            _goodsDAL.Add(goods);
            //添加产品商店对应
            _shopGoodsDAL.Add(
                new ShopGoods()
                {
                    GoodsInfo = goods,
                    ShopInfo = _shopDAL.GetModels(con => con.Id == shopId).FirstOrDefault()
                }
                );
            try
            {
                _goodsDAL.SaveChanges();
                return _shopGoodsDAL.SaveChanges();
            }
            catch
            {
                return false;
            }
            
        }

        /// <summary>
        /// 更新产品信息
        /// </summary>
        /// <param name="newRole"></param>
        /// <returns></returns>

        public bool UpdateRoleModle(GoodsInfoInput newGoods)
        {
            var goods = _goodsDAL.GetModels(con => con.Id == newGoods.Id.Value).FirstOrDefault();
                _goodsDAL.Update(Mapper.Map(newGoods, goods));
            try
            {
                return _goodsDAL.SaveChanges();
            }
            catch
            {
                return false;
            }
            
        }




    }
}