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
                var userRole = _userRoleDAL
                    .GetModels(con2 => con2.UId == user.Id)
                    .FirstOrDefault();
                var role = _roleDAL.GetModels(con => con.Id == userRole.RId).FirstOrDefault();
                if(role!=null)
                {
                    userInfo.RoleName = role.Name;
                    userInfo.RoleLocked = role.Locked;
                }
                //获取商家信息
                var shop = _shopDAL
                    .GetModels(con => con.Keeper.Id == user.Id)
                    .FirstOrDefault();
                if (shop != null)
                {
                    userInfo.ShopName = shop.Name;
                    userInfo.ShopID = shop.Id;
                    userInfo.ShopLocked = shop.Locked;
                    userInfo.ShopApplyStatus = shop.ApplyStaus;
                }
                
            }
            return userInfo;
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
            //_userDAL.Add(user);
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
                 //_userDAL.SaveChanges();
                _userRoleDAL.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                //日志记录
                return false;
            }
            
        }
        
        /// <summary>
        /// 获取所有人员信息【暂不分页】
        /// </summary>
        /// <returns></returns>
        public List<UserInfoOutput> GetAllUserInfo()
        {
            var userInfo = Mapper.Map<List<UserInfoOutput>>(_userDAL.GetModels(con => 1 == 1).ToList());
            userInfo.ForEach(item =>
            {
                //添加角色名称
                var user = userInfo.Find(con => con.Id == item.Id);
                var role = _userRoleDAL.GetModels(con => con.UId == item.Id).FirstOrDefault();
                if (role != null)
                {
                    user.RoleName = _roleDAL.GetModels(con => con.Id == role.RId).FirstOrDefault().Name;
                }
                var shop = _shopDAL.GetModels(con => con.Keeper.Id == item.Id).FirstOrDefault();
                if (shop != null)
                {
                    user.ShopID = shop.Id;
                    user.ShopLocked = shop.Locked;
                    user.ShopName = shop.Name;
                }
            });
            return userInfo;
        }

        /// <summary>
        /// 根据ID删除用户
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public bool DeleteModlesByIds(List<int> userIds)
        {
            userIds.ForEach(id =>
            {
                //删除基本信息
                _userDAL.Delete(
                    _userDAL.GetModels(con => con.Id == id)
                    .FirstOrDefault()
                    );
                //删除对应角色问题
                _userRoleDAL.GetModels(con => con.LogonUser.Id == id)
                .ToList()
                .ForEach(item => _userRoleDAL.Delete(_userRoleDAL
                                            .GetModels(con => con.Id == item.Id).FirstOrDefault()));
            });
            try
            {
                _userDAL.SaveChanges();
                return true;
            }
            catch
            {
                //日志记录
                return false;
            }
        }

        /// <summary>
        /// 解除禁用/禁用用户
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="lockStatus"></param>
        /// <returns></returns>
        public bool DisableOrEnableUserById(int userId, string lockStatus)
        {
            var user = _userDAL.GetModels(con => con.Id == userId).FirstOrDefault();
            user.Locked = lockStatus;
            _userDAL.Update(user);

            try
            {
                _userDAL.SaveChanges();
                return true;
            }
            catch
            {
                //日志记录
                return false;
            }
        }

        /// <summary>
        /// 添加或者删除管理员权限
        /// </summary>
        /// <param name="id"></param>
        /// <param name="adminStatus"></param>
        /// <returns></returns>
        public bool SetOrCancelAdminRole(int userId, bool adminStatus)
        {
            List<string> roleNames = new List<string>();
            _userRoleDAL.GetModels(con => con.LogonUser.Id == userId)
                .ToList().ForEach(item => roleNames.Add(item.LogonRole.Name));
            if(roleNames.Count<=0)
            {
                //表示暂时无权限
                if(adminStatus) //添加管理员
                {
                    _userRoleDAL.Add(
                        new UserRole()
                        {
                            LogonRole = _roleDAL.GetModels(con => con.Name == "admin").FirstOrDefault(),
                            LogonUser = _userDAL.GetModels(con => con.Id == userId).FirstOrDefault()
                        }
                        );
                }

            }
            else
            {
               if(adminStatus)
                {
                    if(!roleNames.Contains("admin"))
                    {
                        _userRoleDAL.Add(
                        new UserRole()
                        {
                            LogonRole = _roleDAL.GetModels(con => con.Name == "admin").FirstOrDefault(),
                            LogonUser = _userDAL.GetModels(con => con.Id == userId).FirstOrDefault()
                        }
                        );
                    }
                }else
                {
                    //删除管理员角色
                    _userRoleDAL.Delete(_userRoleDAL.GetModels(con=>con.LogonRole.Name=="admin"&&con.LogonUser.Id== userId).FirstOrDefault());
                }
            }
            try
            {
                 _userRoleDAL.SaveChanges();
                return true;
            }
            catch
            {
                //日志记录
                return false;
            }
        }

        /// <summary>
        /// 设置用户角色【当前只能一个角色】
        /// </summary>
        /// <param name="id"></param>
        /// <param name="adminStatus"></param>
        /// <returns></returns>
        public bool SetUserRole(int userId, int roleId)
        {
            var userRole = _userRoleDAL.GetModels(con => con.UId == userId).FirstOrDefault();
            if(userRole != null)
            {
                _userRoleDAL.Delete(userRole);
            };
            _userRoleDAL.Add(new UserRole()
            {
                UId = userId,
                RId = roleId
            });
            try
            {
                _userRoleDAL.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                //日志记录
                return false;
            }
        }
    }
}