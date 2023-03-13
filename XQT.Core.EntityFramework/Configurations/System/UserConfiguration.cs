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
    public class UserConfiguration : BaseConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            base.Configure(builder);
            builder.Property(a => a.UserName).HasMaxLength(30);
            builder.Property(a => a.Password).HasMaxLength(30);
            builder.Property(a => a.NickName).HasMaxLength(30);
            builder.Property(a => a.Email).HasMaxLength(30);
            builder.Property(a => a.Phone).HasMaxLength(20);
            builder.Property(a => a.Remark).HasMaxLength(100);
        }
    }
}
