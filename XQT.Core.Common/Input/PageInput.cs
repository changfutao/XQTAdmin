using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XQT.Core.Common
{
    /// <summary>
    /// 分页信息输入
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageInput<T>
    {
        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageNumber { get; set; } = 1;
        /// <summary>
        /// 页容量
        /// </summary>
        public int PageSize { get; set; } = 10;
        /// <summary>
        /// 查询条件
        /// </summary>
        public T? Filter { get; set; }
        /// <summary>
        /// 排序字段
        /// </summary>
        public string SortField { get; set; } = "CreatedTime";
        /// <summary>
        /// 排序方向
        /// </summary>
        public string SortDirection { get; set; } = "DESC";
    }
}
