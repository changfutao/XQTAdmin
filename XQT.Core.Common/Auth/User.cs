using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XQT.Core.Common.Auth
{
    public class User : IUser
    {
        public long Id
        {
            get;
            
        }

        public string UserName => throw new NotImplementedException();

        public string NickName => throw new NotImplementedException();
    }
}
