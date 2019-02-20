using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TakeOut.DAL;

namespace TakeOut.BLL
{
    public class RoleService
    {
        private readonly IRoleDAL _roleDAL;

        public RoleService()
        {
            _roleDAL = new RoleDAL();
        }
        //public List<Role> GetAllRolesInfo()
        //{

        //}
    }
}