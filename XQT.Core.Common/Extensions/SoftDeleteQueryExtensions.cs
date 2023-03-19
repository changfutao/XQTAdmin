using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace XQT.Core.Common.Extensions
{
    public static class SoftDeleteQueryExtensions
    {
        public static void AddSoftDeleteQueryFilter(this IMutableEntityType entityData)
        {
            var methodToCall = typeof(SoftDeleteQueryExtensions).GetMethod(nameof(GetSoftDeleteFilter), BindingFlags.NonPublic | BindingFlags.Static).MakeGenericMethod(entityData.ClrType);
            var filter = methodToCall?.Invoke(null, new object[] { });
            if(filter != null)
              entityData.SetQueryFilter((LambdaExpression)filter);
            entityData.AddIndex(entityData.FindProperty(nameof(IEntitySoftDelete.IsDeleted)));
        }

        private static LambdaExpression GetSoftDeleteFilter<TEntity>() where TEntity : class, IEntitySoftDelete
        {
            Expression<Func<TEntity, bool>> filter = x => !x.IsDeleted;
            return filter;
        }
    }
}
