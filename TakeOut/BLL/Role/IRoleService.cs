using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeOut.BLL.Dto;
using TakeOut.Models;

namespace TakeOut.BLL
{
    public interface IRoleService
    {
        /// <summary>
        /// 获得所有角色列表
        /// </summary>
        /// <returns></returns>
        List<Role> GetAllRolesInfo();

        /// <summary>
        /// 根据ID删除角色
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        bool DeleteModlesByIds(List<int> RoleIds);

        /// <summary>
        /// 更新OR添加新角色
        /// </summary>
        /// <param name="newRole"></param>
        /// <returns></returns>

        bool AddOrUpdateRoleModle(RoleInfoInput newRole);
    }
}
