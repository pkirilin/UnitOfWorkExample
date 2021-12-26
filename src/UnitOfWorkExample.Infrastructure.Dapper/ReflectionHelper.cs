using System;
using System.Linq;
using Dapper.Contrib.Extensions;

namespace UnitOfWorkExample.Infrastructure.Dapper
{
    internal static class ReflectionHelper
    {
        public static string GetTableName<TPersistentEntity>()
        {
            var persistentEntityType = typeof(TPersistentEntity);
            var tableAttributeType = typeof(TableAttribute);
            var tableAttribute = persistentEntityType.CustomAttributes
                .FirstOrDefault(a => a.AttributeType == tableAttributeType);

            if (tableAttribute == null)
            {
                throw new InvalidOperationException(
                    $"Could not find attribute '{tableAttributeType.FullName}' " +
                    $"with table name for entity type '{persistentEntityType.FullName}'. " +
                    "Table attribute is required for all entity types");
            }

            return tableAttribute.ConstructorArguments
                .First()
                .Value
                .ToString();
        }
    }
}