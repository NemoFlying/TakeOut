using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using TakeOut.BLL.Dto;
using TakeOut.DAL;
using TakeOut.Models;

namespace TakeOut.BLL
{
    public class UserService:IUserService
    {

        private readonly IUserDAL _userDAL;
        private readonly IRoleDAL _roleDAL;
        private readonly IUserRoleDAL _userRoleDAL;
        private readonly IShopDAL _shopDAL;
        /// <summary>
        /// 此处后续改为依赖注入
        /// </summary>
        public UserService()
        {
            _userDAL = new UserDAL();
            _roleDAL = new RoleDAL();
            _userRoleDAL = new UserRoleDAL();
            _shopDAL = new ShopDAL();
        }

        /// <summary>
        /// 登录认证
        /// </summary>
        /// <param name="logonUser">登录账号</param>
        /// <param name="password">密码</param>
        /// <returns>
        /// 返回登录信息
        /// 1.0  => 登录成功
        /// 2.1     => 账号不存在
        /// 3.2     => 账号密码不符
        /// 4.3     => 账号被锁定
        /// </returns>
        public string LogonAuthentication(string logonUser, string password)
        {
            var md5 = new MD5CryptoServiceProvider();
            var pwd = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(logonUser + password)));
            pwd = pwd.Replace("-", "");
            var user = _userDAL.GetModels(con => con.LogonUser == logonUser)
                .FirstOrDefault();
            if (user is null)
            {
                //表示没有注册
                return "1";
            }
            else if (user.Password != pwd)
            {
                //密码错误
                return "2";
            }
            else if(user.Locked =="Y")
            {
                //账号被锁
                return "3";
            }
            else
            {
                //认证通过
                return "0";
            }
        }


        /// <summary>
        /// 根据登录名获得用户相关信息
        /// </summary>
        /// <param name="logonUser"></param>
        /// <returns></returns>
        public UserInfoOutput GetUserInfoByName(string logonUser)
        {
            var user = _userDAL.GetModels(con => con.LogonUser == logonUser)
                .FirstOrDefault();
            var userInfo = Mapper.Map<UserInfoOutput>(user);
            if(userInfo != null)
            {
                //获取用户组信息【当前用户只能具有一个权限】
                var role = _userRoleDAL
                    .GetModels(con => con.LogonUser.Id == user.Id)
                    .FirstOrDefault();
                userInfo.RoleName = role.LogonRole.Name;
                userInfo.RoleLocked = role.LogonRole.Locked;
                //获取商家信息
                var shop = _shopDAL
                    .GetModels(con => con.Keeper.Id == user.Id)
                    .FirstOrDefault();
                if(shop != null)
                {
                    userInfo.ShopName = shop.Name;
                    userInfo.ShopID = shop.Id;
                    userInfo.ShopLocked = shop.Locked;
                    userInfo.ShopApplyStatus = shop.ApplyStaus;
                }
                
            }
            return userInfo;
            //_userDAL.GetModels(con=>con.LogonUser)

        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns>
        /// true 注册成功
        /// false 注册失败
        /// </returns>
        public bool RegistUser(RegistUserInfoInput userInfo)
        {
            var user = Mapper.Map<User>(userInfo);
            _userDAL.Add(user);
            //添加默认组
            var userRole = new UserRole()
            {
                LogonUser = user,
                LogonRole = _roleDAL.GetModels(con => con.Name == "user")
                .FirstOrDefault(), //默认为user组别
                CreateUser = _userDAL.GetModels(con => con.Id == userInfo.RequestUserID)
                .FirstOrDefault()
            };
            _userRoleDAL.Add(userRole);
            try
            {
                return _userDAL.SaveChanges();
            }catch(Exception ex)
            {
                //日志记录
                return false;
            }
            
        }




    }
}