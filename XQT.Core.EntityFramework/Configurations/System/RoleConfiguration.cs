using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XQT.Core.Model;

namespace XQT.Core.EntityFramework.Configurations
{
    public class RoleConfiguration : BaseConfiguration<RoleEntity>
    {
        public override void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.ToTable("sys_role");
            builder.Property(a => a.Name).HasMaxLength(50);
            builder.Property(a => a.Code).HasMaxLength(50);
            builder.Property(a => a.Remark).HasMaxLength(100);

            //builder.HasMany(a => a.UserRoleEntities)
            //      .WithOne(a => a.RoleEntity)
            //      .HasForeignKey(a => a.RoleId);

            //builder.HasMany(a => a.RoleMenuEntities)
            //       .WithOne(a => a.RoleEntity)
            //       .HasForeignKey(a => a.RoleId);
            base.Configure(builder);

            builder.HasData(new RoleEntity
            {
                Id = 12312534123,
                Name = "超级管理员",
                Code = "admin",
                CreatedTime = DateTime.Now,
                CreatedUserName = "admin",
                CreatedUserId = 123123123,
                IsDeleted = false,
                Sort = 1,
                IsEnable = true
            });
        }
    }
}
