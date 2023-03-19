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
        }
    }
}
