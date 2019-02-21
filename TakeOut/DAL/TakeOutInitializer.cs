using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TakeOut.Models;

namespace TakeOut.DAL
{
    public class TakeOutInitializer : DropCreateDatabaseIfModelChanges<TakeOutContext>
    {
        protected override void Seed(TakeOutContext context)
        {
            //创建角色
            var roles = new List<Role>()
            {
                new Role(){
                     Name="admin",
                      Description="管理员账号"
                },
                new Role()
                {
                    Name="user",
                    Description="普通用户"
                },
                new Role()
                {
                    Name="business",
                    Description="商家"
                }
            };
            roles.ForEach(item => context.Role.Add(item));
            context.SaveChanges();

            //创建用户
            var users = new List<User>()
            {
                new User()
                {
                    LogonUser = "admin",
                    Password="FFBD90693A6A629C960CC7DC581F01D9",
                    HeadPortrait="图片地址",
                    Sex="M",
                    Phone="123",
                    Addr="地址",
                    Locked="N"                   
                },
                new User()
                {
                    LogonUser = "Nemo",
                    Password="7C14E75254AE6BFD6833D7FA86310B25",
                    HeadPortrait="图片地址",
                    Sex="M",
                    Phone="123",
                    Addr="地址",
                    Locked="N"
                },
                new User()
                {
                    LogonUser = "Jerry",
                    Password="19379D10FC994E226DAAAA840BF207CB",
                    HeadPortrait="图片地址",
                    Sex="M",
                    Phone="123",
                    Addr="地址",
                    Locked="N"
                }
            };
            users.ForEach(item => context.User.Add(item));
            context.SaveChanges();

            //用户角色
            var userRoles = new List<UserRole>()
            {
                new UserRole(){
                    UId = context.User.Where(con=>con.LogonUser=="Nemo").FirstOrDefault().Id,
                    RId = context.Role.Where(con=>con.Name=="user").FirstOrDefault().Id,
                    CreateDate = DateTime.Now
                },
                new UserRole()
                {
                    UId = context.User.Where(con=>con.LogonUser=="admin").FirstOrDefault().Id,
                    RId = context.Role.Where(con=>con.Name=="admin").FirstOrDefault().Id,
                    CreateDate = DateTime.Now
                },
                new UserRole()
                {
                    UId = context.User.Where(con=>con.LogonUser=="Jerry").FirstOrDefault().Id,
                    RId = context.Role.Where(con=>con.Name=="business").FirstOrDefault().Id,
                    CreateDate = DateTime.Now
                }
            };
            userRoles.ForEach(item => context.UserRole.Add(item));
            context.SaveChanges();
        }

    }
}