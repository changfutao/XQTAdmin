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
    public class RoleMenuConfiguration : IEntityTypeConfiguration<RoleMenuEntity>
    {
        public void Configure(EntityTypeBuilder<RoleMenuEntity> builder)
        {
            builder.ToTable("sys_role_menu");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.CreatedUserName).HasMaxLength(30);
        }
    }
}
