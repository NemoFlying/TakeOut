using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace TakeOut.Models
{
    public class RoleMap:EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            this.HasMany(x => x.Users)
                .WithMany(x => x.Roles)
                .Map(m => m.ToTable("UserRole")
                .MapLeftKey("UserId")
                .MapRightKey("RoleId"));
               
        }
    }
}