using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XQT.Core.Common;

namespace XQT.Core.Model
{
    public class UserRoleEntity : Entity, IEntityAdd<long>
    {
        public long? CreatedUserId { get; set; }
        public string? CreatedUserName { get; set; }
        public DateTime? CreatedTime { get; set; }
    }
}
