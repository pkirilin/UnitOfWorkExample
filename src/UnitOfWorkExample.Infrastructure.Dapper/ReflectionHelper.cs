using System;
using System.Linq;
using Dapper.Contrib.Extensions;

namespace UnitOfWorkExample.Infrastructure.Dapper
{
    internal static class ReflectionHelper
    {
        public static string GetTableName<TContrib>()
        {
            var contribType = typeof(TContrib);
            var tableAttributeType = typeof(TableAttribute);
            var tableAttribute = contribType.CustomAttributes
                .FirstOrDefault(a => a.AttributeType == tableAttributeType);

            if (tableAttribute == null)
            {
                throw new InvalidOperationException($"Could not find attribute '{tableAttributeType.FullName}' " +
                                                    $"with table name for contrib type '{contribType.FullName}'. " +
                                                    $"Table attribute is required for all contrib types");
            }

            return tableAttribute.ConstructorArguments.First().Value.ToString();
        }
    }
}