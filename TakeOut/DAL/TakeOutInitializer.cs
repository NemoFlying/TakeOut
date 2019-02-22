using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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
                    Password="2E73DEE9F5A16E7FDCEC25BD84D7DCFC",
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

            //产品信息
            List<Goods> goods = new List<Goods>() {
                new Goods()
            {
                Name = "Product",
                Price = 10,
                SalesNum = 100,
                Stocks = 200,
                Unit = "份",
                Locked = "N"
            },
                new Goods()
            {
                Name = "Product1",
                Price = 10,
                SalesNum = 100,
                Stocks = 200,
                Unit = "份",
                Locked = "N"
            },
                new Goods()
            {
                Name = "Product2",
                Price = 10,
                SalesNum = 100,
                Stocks = 200,
                Unit = "份",
                Locked = "N"
            }
        };
            //店铺
            List<Shop> shops = new List<Shop>() {
                new Shop()
            {
                Name = "Shop1",
                Locked = "N",
                Addr = "成都",
                ApplyStaus = 1,
                Phone = "895190626",
                Goods = new List<Goods>(){ goods[0] },
                Keeper = context.User.Where(con => con.LogonUser == "admin").FirstOrDefault(),
            },
                new Shop()
            {
                Name = "Shop2",
                Locked = "N",
                Addr = "成都",
                ApplyStaus = 1,
                Phone = "895190626",
                Goods = new List<Goods>(){ goods[1] },
                Keeper = context.User.Where(con => con.LogonUser == "admin").FirstOrDefault(),
            },
                new Shop()
            {
                Name = "Shop3",
                Locked = "N",
                Addr = "成都",
                ApplyStaus = 1,
                Phone = "895190626",
                Goods = new List<Goods>(){ goods[2] },
                Keeper = context.User.Where(con => con.LogonUser == "admin").FirstOrDefault(),
            }
            };
            shops.ForEach(item => context.Shop.Add(item));

            context.SaveChanges();

            //OrderInfo
            var order = new Order()
            {
                Addr = "addr",
                OrderStaus = 0,
                OrderUser = users[0],
                Phone = "475210",
                Remarks = "sss",
                Recevier = "Nemo",
                Goods = goods,
                Shop = shops[0]
            };
            context.Order.Add(order);
            context.SaveChanges();


            //    List<Goods> goods2 = new List<Goods>() {
            //        new Goods()
            //    {
            //        Name = "Product3",
            //        Price = 10,
            //        SalesNum = 100,
            //        Stocks = 200,
            //        Unit = "份",
            //        Locked = "N"
            //    },
            //        new Goods()
            //    {
            //        Name = "Product4",
            //        Price = 10,
            //        SalesNum = 100,
            //        Stocks = 200,
            //        Unit = "份",
            //        Locked = "N"
            //    },
            //        new Goods()
            //    {
            //        Name = "Product5",
            //        Price = 10,
            //        SalesNum = 100,
            //        Stocks = 200,
            //        Unit = "份",
            //        Locked = "N"
            //    }
            //};
            //    goods2.ForEach(item => context.Goods.Add(item));

            //    context.SaveChanges();




        }

    }
}