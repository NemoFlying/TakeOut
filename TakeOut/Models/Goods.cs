using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TakeOut.Models
{
    /// <summary>
    /// 商品信息
    /// </summary>
    public class Goods
    {
        public Goods()
        {
            this.Locked = "Y";
            this.Price = 0;
            this.Unit = "份";
            this.Stocks = 0;
            this.SalesNum = 0;
            this.CreateDate = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //设置自动增长
        public int Id { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 商品图片【暂时只能上传一张图片】
        /// </summary>
        [MaxLength(150)]
        public string ImgUrl { get; set; }

        /// <summary>
        /// 商品价格
        /// </summary>
        [Required]
        public int Price { get; set; }

        /// <summary>
        /// 商品单位
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Unit { get; set; }

        /// <summary>
        /// 商品库存
        /// </summary>
        [Required]
        public int Stocks { get; set; }

        /// <summary>
        /// 商品库存
        /// </summary>
        [Required]
        public int SalesNum { get; set; }

        /// <summary>
        /// 商品锁定状态
        /// Y:锁定
        /// N:活跃
        /// </summary>
        [MaxLength(1)]
        public string Locked { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        [Required]
        public virtual Shop Shop { get; set; }
    }
}