using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using XQT.Core.Common;
using XQT.Core.Common.Extensions;
using XQT.Core.Model;

namespace XQT.Core.EntityFramework
{
    public class XQTContext: DbContext
    {
        public XQTContext(DbContextOptions<XQTContext> options)
         : base(options)
        {

        }
        public DbSet<UserEntity> UserEntities { get; set; }
        public DbSet<RoleEntity> RoleEntities { get; set; }
        public DbSet<UserRoleEntity> UserRoleEntities { get; set; }
        public DbSet<MenuEntity> MenuEntities { get; set; }
        public DbSet<RoleMenuEntity> RoleMenuEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if(typeof(IEntitySoftDelete).IsAssignableFrom(entityType.ClrType))
                {
                    entityType.AddSoftDeleteQueryFilter();
                }
            }
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("XQT.Core.EntityFramework"));
        }
    }
}
