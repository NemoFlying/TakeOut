using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TakeOut.Models
{
    /// <summary>
    /// 商店
    /// </summary>
    public class Shop
    {
        public Shop()
        {
            this.Locked = "Y";
            this.ApplyStaus = 0;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //设置自动增长
        public int Id { get; set; }

        /// <summary>
        /// 商店名称
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 商店名称
        /// </summary>
        [Required]
        public virtual User Keeper { get; set; }

        /// <summary>
        /// 店铺地址
        /// </summary>
        [MaxLength(150)]
        [Required]
        public string Addr { get; set; }

        /// <summary>
        /// 店铺联系电话
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }

        /// <summary>
        /// 店铺锁定状态
        /// Y:锁定
        /// N:活跃
        /// </summary>
        [MaxLength(1)]
        public string Locked { get; set; }

        /// <summary>
        /// 店铺申请状态
        /// 0:申请中
        /// 1:激活
        /// </summary>
        public int ApplyStaus { get; set; }

    }
}