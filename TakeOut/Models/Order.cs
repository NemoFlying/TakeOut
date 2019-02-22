using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TakeOut.Models
{
    /// <summary>
    /// 订单基本信息
    /// </summary>
    public class Order
    {
        public Order()
        {
            this.CreateDate = DateTime.Now;
            this.OrderStaus = 0;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //设置自动增长
        public int Id { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [Required]
        [MaxLength(150)]
        public string Addr { get; set; }

        /// <summary>
        /// 收货人
        /// </summary>
        [Required]
        [MaxLength(150)]
        public string Recevier { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// 订单状态
        /// 0:待处理
        /// 1:已经处理
        /// 2:取消
        /// </summary>
        [Required]
        public int OrderStaus { get; set; }


        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        public DateTime CreateDate { get; set; }


        ///// <summary>
        ///// 下订单用户
        ///// </summary>
        public virtual User OrderUser { get; set; }

        /// <summary>
        /// 商家信息
        /// </summary>
        public virtual Shop Shop { get; set; }

        /// <summary>
        /// 与产品多对多
        /// </summary>
        //public ICollection<OrderGoods> OrderGoods { get; set; }
        public ICollection<Goods> Goods { get; set; }
    }
}