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
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRoleEntity>
    {
        public void Configure(EntityTypeBuilder<UserRoleEntity> builder)
        {
            builder.ToTable("sys_user_role");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.CreatedUserName).HasMaxLength(30);

            builder.HasData(new UserRoleEntity
            {
                Id = 1231209887,
                RoleId = 12312534123,
                UserId = 123123123,
                CreatedTime = DateTime.Now,
                CreatedUserId = 123123123,
                CreatedUserName = "admin"
            });
        }
    }
}
