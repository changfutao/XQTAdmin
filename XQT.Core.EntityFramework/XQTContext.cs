using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XQT.Core.Model;

namespace XQT.Core.EntityFramework
{
    public class XQTContext: DbContext
    {
        public DbSet<UserEntity> UserEntities { get; set; }
        public DbSet<RoleEntity> RoleEntities { get; set; }
        public DbSet<UserRoleEntity> UserRoleEntities { get; set; }
    }
}
