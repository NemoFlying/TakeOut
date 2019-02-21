using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TakeOut.BLL.Dto
{
    public class OrderInfoInput
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
        /// 备注信息
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// 订单状态
        /// 0:待处理
        /// 1:已经处理
        /// 2:取消
        /// </summary>
        public int OrderStaus { get; set; }
    }
}