using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TakeOut.ViewModels
{
    public class ShopOutPutViewModel
    {
        public int Id { get; set; }

        /// <summary>
        /// 商店名称
        /// </summary>
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

        /// <summary>
        /// 店铺申请状态
        /// 0:申请中
        /// 1:申请通过
        /// </summary>
        public int ApplyStaus { get; set; }

        /// <summary>
        /// 商家名称
        /// </summary>
        public string  KeeperName { get; set; }
    }
}