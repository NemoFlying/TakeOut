using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TakeOut.BLL.Dto;

namespace TakeOut.BLL
{
    public interface IUserService
    {
        /// <summary>
        /// 登录认证
        /// </summary>
        /// <param name="logonUser"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        string LogonAuthentication(string logonUser, string password);

        /// <summary>
        /// 根据
        /// </summary>
        /// <param name="logonUser"></param>
        UserInfoOutput GetUserInfoByName(string logonUser);

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns>
        /// true 注册成功
        /// false 注册失败
        /// </returns>
        bool RegistUser(RegistUserInfoInput userInfo);

        /// <summary>
        /// 获取所有人员信息【暂不分页】
        /// </summary>
        /// <returns></returns>
        List<UserInfoOutput> GetAllUserInfo();

        /// <summary>
        /// 根据ID删除用户
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        bool DeleteModlesByIds(List<int> userIds);

        /// <summary>
        /// 解除禁用/禁用用户
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="lockStatus"></param>
        /// <returns></returns>
        bool DisableOrEnableUserById(int userId, string lockStatus);

        /// <summary>
        /// 添加或者删除管理员权限
        /// </summary>
        /// <param name="id"></param>
        /// <param name="adminStatus"></param>
        /// <returns></returns>
        bool SetOrCancelAdminRole(int userId, bool adminStatus);

        /// <summary>
        /// 用户角色设置
        /// </summary>
        /// <param name="id"></param>
        /// <param name="adminStatus"></param>
        /// <returns></returns>
        bool SetUserRole(int userId, int  roleId);

    }
}