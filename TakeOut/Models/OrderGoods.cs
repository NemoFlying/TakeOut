using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TakeOut.Models
{
    /// <summary>
    /// 订单产品列表
    /// </summary>
    public class OrderGoods
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //设置自动增长
        public int Id { get; set; }

        /// <summary>
        /// 商品信息
        /// </summary>
        public virtual Order OrderInfo { get; set; }

        /// <summary>
        /// 商品信息
        /// </summary>
        public virtual Goods GoodsInfo { get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        public int GoodsNum { get; set; }

        /// <summary>
        /// 商品价格
        /// </summary>
        public int GoodsPrice { get; set; }
    }
}