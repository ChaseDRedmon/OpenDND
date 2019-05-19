using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace OpenDND.Data.Utilities
{
    public static class DbContextExtensions
    {
        public static void UpdateProperty<TEntity, TValue>(this DbContext dbContext, TEntity entity, Expression<Func<TEntity, TValue>> propertySelector) where TEntity : class
        {
            if (dbContext == null)
                throw new ArgumentNullException(nameof(dbContext));

            if (propertySelector == null)
                throw new ArgumentNullException(nameof(propertySelector));

            dbContext.Entry(entity).Property(propertySelector).IsModified = true;
        }
    }
}