using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TakeOut.BLL.Dto
{
    public class GoodsInfoInput
    {
        public int? Id { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 商品图片【暂时只能上传一张图片】
        /// </summary>
        public string ImgUrl { get; set; }

        /// <summary>
        /// 商品价格
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// 商品单位
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 商品库存
        /// </summary>
        public int Stocks { get; set; }

        /// <summary>
        /// 商品库存
        /// </summary>
        public int SalesNum { get; set; }

        /// <summary>
        /// 商品锁定状态
        /// Y:锁定
        /// N:活跃
        /// </summary>
        public string Locked { get; set; }
    }
}