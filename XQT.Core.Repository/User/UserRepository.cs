using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XQT.Core.EntityFramework;
using XQT.Core.Model;

namespace XQT.Core.Repository
{
    public class UserRepository: BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(XQTContext xqtContext): base(xqtContext)
        {
            
        }
    }
}
