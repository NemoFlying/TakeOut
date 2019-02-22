using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using TakeOut.Models;

namespace TakeOut.DAL
{
    public class TakeOutContext:DbContext
    {
        public TakeOutContext()
            : base("TakeOutConnectionString")
        {
        }
        public DbSet<Goods> Goods { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Shop> Shop { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //指定单数形式的表名
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}