using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TakeOut.BLL.Dto
{
    public class ShopInfoInput
    {
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// 商店名称
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 店铺地址
        /// </summary>
        public string Addr { get; set; }

        /// <summary>
        /// 店铺联系电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 店铺锁定状态
        /// Y:锁定
        /// N:活跃
        /// </summary>
        public string Locked { get; set; }
    }
}