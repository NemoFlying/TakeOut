using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TakeOut.BLL.Dto
{
    public class RoleInfoInput
    {
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

    }
}