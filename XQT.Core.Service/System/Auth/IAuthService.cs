using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XQT.Core.Common.Output;

namespace XQT.Core.Service
{
    public interface IAuthService
    {
        Task<IResponseOutput> Login(AuthLoginDto input);
    }
}
