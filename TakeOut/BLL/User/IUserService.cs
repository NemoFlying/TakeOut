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
    }
}