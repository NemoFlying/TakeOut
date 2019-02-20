using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TakeOut.Models
{
    /// <summary>
    /// 角色
    /// </summary>
    public class Role
    {

        public Role()
        {
            this.Locked = "N";
            this.CreateDate = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //设置自动增长
        public int Id { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }


        /// <summary>
        /// 角色描述
        /// </summary>
        [MaxLength(150)]
        public string Description { get; set; }

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
    }
}