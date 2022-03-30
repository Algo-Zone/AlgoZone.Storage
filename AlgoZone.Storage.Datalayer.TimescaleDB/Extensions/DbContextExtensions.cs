using System;
using System.Linq;
using System.Reflection;
using AlgoZone.Storage.Datalayer.TimescaleDB.Attributes;
using Microsoft.EntityFrameworkCore;

namespace AlgoZone.Storage.Datalayer.TimescaleDB.Extensions
{
    public static class DbContextExtensions
    {
        #region Methods

        #region Static Methods

        /// <summary>
        /// Applies the creation of all hypertables.
        /// </summary>
        /// <param name="context">The DbContext</param>
        public static void ApplyHypertables(this DbContext context)
        {
            context.Database.ExecuteSqlRaw("CREATE EXTENSION IF NOT EXISTS timescaledb CASCADE;");

            var entityTypes = context.Model.GetEntityTypes();
            var hypertableEntities = entityTypes.Where(et => et.ClrType.GetCustomAttribute(typeof(HypertableAttribute)) != null);
            foreach (var hypertableEntity in hypertableEntities)
            {
                var timeColumn = hypertableEntity.GetProperties().FirstOrDefault(p => p.PropertyInfo.GetCustomAttribute(typeof(HypertableTimeColumnAttribute)) != null);
                if (timeColumn == null)
                    throw new InvalidOperationException($"No time column in hypertable: {hypertableEntities.GetType().Name}");

                var tableName = hypertableEntity.GetTableName();
                var columnName = timeColumn.GetColumnName();
                context.Database.ExecuteSqlRaw($"SELECT create_hypertable('\"{tableName}\"', '{columnName}', if_not_exists => TRUE);");
            }
        }

        #endregion

        #endregion
    }
}