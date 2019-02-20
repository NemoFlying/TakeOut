using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TakeOut.Models
{
    /// <summary>
    /// 商店和产品关系
    /// </summary>
    public class ShopGoods
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //设置自动增长
        public int Id { get; set; }

        /// <summary>
        /// 商店信息
        /// </summary>
        public virtual Shop ShopInfo { get; set; }
        /// <summary>
        /// 商品信息
        /// </summary>
        public virtual Goods GoodsInfo { get; set; }


    }
}