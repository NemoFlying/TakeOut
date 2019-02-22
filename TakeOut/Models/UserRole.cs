using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TakeOut.Models
{
    public class UserRole
    {
        public UserRole()
        {
            this.CreateDate = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //设置自动增长
        public int Id { get; set; }

        public int UId { get; set; }

        public int RId { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public virtual User LogonUser { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public virtual Role LogonRole { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual User CreateUser { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }


    }
}