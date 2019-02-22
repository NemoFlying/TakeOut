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
    public class GoodsService : IGoodsService
    {
        private readonly IGoodsDAL _goodsDAL;
        private readonly IShopDAL _shopDAL;
        public GoodsService()
        {
            _goodsDAL = new GoodsDAL();
        }



        /// <summary>
        /// 获得所有产品列表
        /// </summary>
        /// <returns></returns>
        public List<Goods> GetAllGoodsByShopId(int shopId)
        {
            try
            {
                return _goodsDAL.GetModels(con => con.Shop.Id == shopId).ToList();
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
        public bool DeleteProductByIds(List<int> GoodsIds)
        {
            GoodsIds.ForEach(id =>
            {
                //删除基本信息
                _goodsDAL.Delete(
                    _goodsDAL.GetModels(con => con.Id == id)
                    .FirstOrDefault()
                    );
            });
            
            try
            {
                _goodsDAL.SaveChanges();
                return true;
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
        public bool AddGoodsInfo(GoodsInfoInput newGoods, int shopId)
        {
            //添加基本信息
            var goods = Mapper.Map<Goods>(newGoods);
            goods.Shop = _shopDAL.GetModels(con => con.Id == shopId).FirstOrDefault();
            try
            {
                _goodsDAL.SaveChanges();
                return true;
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
        public bool UpdateProductInfo(GoodsInfoInput newGoods)
        {
            var goods = _goodsDAL.GetModels(con => con.Id == newGoods.Id.Value).FirstOrDefault();
                _goodsDAL.Update(Mapper.Map(newGoods, goods));
            try
            {
                _goodsDAL.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }




    }
}