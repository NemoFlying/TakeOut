using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TakeOut.ViewModels
{
    public class OrderOutPutViewModel
    {
        public int Id { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Addr { get; set; }

        /// <summary>
        /// 收货人
        /// </summary>
        public string Recevier { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        public int GoodsCnt { get; set; }

        /// <summary>
        /// 总价格
        /// </summary>
        public int TotalPrice { get; set; }

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
        public int OrderStaus { get; set; }


        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }


        /// <summary>
        /// 下订单用户
        /// </summary>
        public string OrderUser { get; set; }
    }
}