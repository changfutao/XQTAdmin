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
        public override void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("sys_user");
            builder.Property(a => a.UserName).HasMaxLength(30);
            builder.Property(a => a.Password).HasMaxLength(50);
            builder.Property(a => a.NickName).HasMaxLength(30);
            builder.Property(a => a.Email).HasMaxLength(30);
            builder.Property(a => a.Phone).HasMaxLength(20);
            builder.Property(a => a.Remark).HasMaxLength(100);

            builder.HasData(new UserEntity
            {
                Id = 123123123,
                UserName = "admin",
                Password = "E10ADC3949BA59ABBE56E057F20F883E",
                UserStatus = UserStatus.Normal,
                CreatedTime = DateTime.Now,
                CreatedUserId= 123123123,
                CreatedUserName = "admin",
                IsDeleted= false
            });
        }
    }
}
