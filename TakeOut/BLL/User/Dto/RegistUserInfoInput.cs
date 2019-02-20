using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TakeOut.BLL.Dto
{
    public class RegistUserInfoInput
    {
        /// <summary>
        /// 请求人ID
        /// </summary>
        public int RequestUserID { get; set; }

        /// <summary>
        /// 登陆用户名
        /// </summary>
        public string LogonUser { get; set; }

        /// <summary>
        /// 性别
        /// M:男性
        /// F:女性
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 头像地址
        /// </summary>
        public string HeadPortrait { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Addr { get; set; }
    }
}