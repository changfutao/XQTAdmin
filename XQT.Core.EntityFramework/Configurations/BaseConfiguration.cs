using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XQT.Core.Common;

namespace XQT.Core.EntityFramework.Configurations
{
    public abstract class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : EntityFull
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.CreatedUserName).HasMaxLength(30);
            builder.Property(a => a.ModifiedUserName).HasMaxLength(30);
        }
    }
}
