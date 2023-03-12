using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XQT.Core.Common
{
    /// <summary>
    /// 租户接口
    /// </summary>
    public interface ITenant<TKey>
    {
        TKey TenantId { get; set; }
    }
}
