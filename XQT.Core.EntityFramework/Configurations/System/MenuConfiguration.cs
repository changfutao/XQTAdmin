using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XQT.Core.Model;

namespace XQT.Core.EntityFramework.Configurations.System
{
    public class MenuConfiguration : BaseConfiguration<MenuEntity>
    {
        public override void Configure(EntityTypeBuilder<MenuEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("sys_menu");
            builder.Property(a => a.MenuName).HasMaxLength(50);
            builder.Property(a => a.MenuCode).HasMaxLength(50);
            builder.Property(a => a.MenuPath).HasMaxLength(50);
            builder.Property(a => a.RoutePath).HasMaxLength(50);
            builder.Property(a => a.Icon).HasMaxLength(30);
            builder.Property(a => a.Remark).HasMaxLength(200);

            // 建立导航属性(外键)
            //builder.HasMany(a => a.RoleMenuEntities)
            //       .WithOne(a => a.MenuEntity)
            //       .HasForeignKey(a => a.MenuId);

            builder.HasData(new MenuEntity
            {
                Id = 123989081921,
                MenuName = "系统管理",
                MenuCode = "",
                MenuType = MenuTypeEnum.目录,
                IsDeleted = false,
                CreatedTime = DateTime.Now,
                CreatedUserId = 123123123,
                CreatedUserName = "admin",
                IsHidden = false,
                IsOpenWindow = false,
                MenuPath = "",
                RoutePath = "",
                ParentId = 0
            },
            new MenuEntity
            {
                Id = 123989081922,
                MenuName = "用户管理",
                MenuCode = "",
                MenuType = MenuTypeEnum.页面,
                IsDeleted = false,
                CreatedTime = DateTime.Now,
                CreatedUserId = 123123123,
                CreatedUserName = "admin",
                IsHidden = false,
                IsOpenWindow = false,
                MenuPath = "/api/user/getpage",
                RoutePath = "system/user",
                ParentId = 123989081921
            },
            new MenuEntity
            {
                Id = 123989081923,
                MenuName = "添加",
                MenuCode = "api:user:add",
                MenuType = MenuTypeEnum.按钮,
                IsDeleted = false,
                CreatedTime = DateTime.Now,
                CreatedUserId = 123123123,
                CreatedUserName = "admin",
                IsHidden = false,
                IsOpenWindow = false,
                MenuPath = "",
                RoutePath = "",
                ParentId = 123989081922
            }
            );
        }
    }
}
