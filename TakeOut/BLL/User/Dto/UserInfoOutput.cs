using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TakeOut.BLL.Dto
{
    /// <summary>
    /// 用户信息返回
    /// </summary>
    public class UserInfoOutput
    {
        public UserInfoOutput()
        {
           // RoleName = new List<string>();
        }

        private int Id { get; set; }

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

        /// <summary>
        /// 锁定状态
        /// Y:锁定
        /// N:活跃
        /// </summary>
        public string Locked { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 角色是否锁定
        /// </summary>
        public string RoleLocked { get; set; }

        #region 店铺信息
        /// <summary>
        /// 店铺ID
        /// 暂时一个用户ID只能开一个店
        /// </summary>
        public int ShopID { get; set; }


        /// <summary>
        /// 店铺名称
        /// </summary>
        public string ShopName { get; set; }

        /// <summary>
        /// 审核状态【0：审核中，1：审核通过】
        /// </summary>
        public int ShopApplyStatus { get; set; }

        /// <summary>
        /// 店铺是否被锁定
        /// 【"Y"被锁定】
        /// </summary>
        public string ShopLocked { get; set; }

        #endregion
    }
}