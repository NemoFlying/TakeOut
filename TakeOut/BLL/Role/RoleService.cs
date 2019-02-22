using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TakeOut.BLL.Dto;
using TakeOut.DAL;
using TakeOut.Models;

namespace TakeOut.BLL
{
    public class RoleService: IRoleService
    {
        private readonly IRoleDAL _roleDAL;

        public RoleService()
        {
            _roleDAL = new RoleDAL();
        }
        /// <summary>
        /// 获得所有角色列表
        /// </summary>
        /// <returns></returns>
        public List<Role> GetAllRolesInfo()
        {
            try
            {
                return _roleDAL.GetModels(con => 1 == 1).ToList();
            }
            catch
            {
                return null;
            }
            
        }

        /// <summary>
        /// 根据ID删除角色
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public bool DeleteModlesByIds(List<int> RoleIds)
        {
            RoleIds.ForEach(id =>
            {
                //删除基本信息
                _roleDAL.Delete(
                    _roleDAL.GetModels(con => con.Id == id)
                    .FirstOrDefault()
                    );
            });
            try
            {
                 _roleDAL.SaveChanges();
                return true;
            }
            catch
            {
                //日志记录
                return false;
            }
        }


        /// <summary>
        /// 更新OR添加新角色
        /// </summary>
        /// <param name="newRole"></param>
        /// <returns></returns>

        public bool AddOrUpdateRoleModle(RoleInfoInput newRole)
        {
            //检查角色名称是否存在
            var role = _roleDAL.GetModels(con => con.Name == newRole.Name).FirstOrDefault();
            if(role is null)
            {
                //不存在添加角色
                _roleDAL.Add(new Role()
                {
                    Name = newRole.Name,
                    Description = newRole.Description
                });
            }
            else
            {
                //跟新角色
                role.Description = newRole.Description;
                _roleDAL.Update(role);
            }
            try
            {
                _roleDAL.SaveChanges();
                return true;
            }
            catch
            {
                //日志记录
                return false;
            }
        }


    }
}