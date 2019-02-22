using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TakeOut.Models
{
    /// <summary>
    /// 用户
    /// </summary>
    public class User
    {
        public User()
        {
            this.Locked = "N";
            this.CreateDate = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //设置自动增长
        public int Id { get; set; }

        /// <summary>
        /// 登陆用户名
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string LogonUser { get; set; }

        /// <summary>
        /// 登陆密码
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        /// <summary>
        /// 性别
        /// M:男性
        /// F:女性
        /// </summary>
        [MaxLength(1)]
        public string Sex { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [MaxLength(20)]
        public string Phone { get; set; }

        /// <summary>
        /// 头像地址
        /// </summary>
        [MaxLength(150)]
        public string HeadPortrait { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [MaxLength(150)]
        public string Addr { get; set; }

        /// <summary>
        /// 锁定状态
        /// Y:锁定
        /// N:活跃
        /// </summary>
        [MaxLength(1)]
        public string Locked { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        public virtual ICollection<UserRole> UserRoles { set; get; }

    }
}