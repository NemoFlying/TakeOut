using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TakeOut.DAL;
using TakeOut.Models;

namespace TakeOut.BLL
{
    public class RoleService
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
                return _roleDAL.SaveChanges();
            }
            catch
            {
                //日志记录
                return false;
            }
        }


        //public bool AddRoleModles()
        //{
        //    _roleDAL.Add(new Role() {
        //         Name = 
        //    })

        //}


    }
}