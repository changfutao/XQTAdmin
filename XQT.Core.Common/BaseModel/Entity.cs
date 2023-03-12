using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yitter.IdGenerator;

namespace XQT.Core.Common
{
    public interface IEntity<TKey>
    {
        /// <summary>
        /// 主键
        /// </summary>
        TKey Id { get; set; }
    }

    public interface IEntity: IEntity<long>
    {

    }

    public class Entity<TKey> : IEntity<TKey>
    {
        /// <summary>
        /// 主键
        /// </summary>
        public TKey Id { get; set; }
    }

    public class Entity: Entity<long>
    {
        /// <summary>
        /// 主键由雪花Id自动生成
        /// </summary>
        public new long Id { get; set; } = YitIdHelper.NextId();
    }
}
