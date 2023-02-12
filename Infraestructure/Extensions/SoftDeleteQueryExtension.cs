using Domain.Interfaces.Entities;
using System.Linq.Expressions;
using System.Reflection;

namespace Infraestructure.Extensions
{
    public static class SoftDeleteQueryExtension
    {
        public static void AddSoftDeleteQueryFilter(this Microsoft.EntityFrameworkCore.Metadata.IMutableEntityType mutableEntityType)
        {
            var methodToCall = typeof(SoftDeleteQueryExtension)
                .GetMethod(nameof(GetSoftDeleteFilter), BindingFlags.NonPublic | BindingFlags.Static)
                .MakeGenericMethod(mutableEntityType.ClrType);
            var filter = methodToCall.Invoke(null, new object[] { });
            mutableEntityType.SetQueryFilter((LambdaExpression)filter);
        }

        private static LambdaExpression GetSoftDeleteFilter<TEntity>() where TEntity : class, ISoftDelete
        {
            Expression<Func<TEntity, bool>> filter = x => x.Activo;
            return filter;
        }
    }
}
