/*
 * Project : SenseFramework - Database module
 * Author : Ekin Bulut 
 * Date : 24.02.2017
 * 
 * Desc : This class is a base class which provides initial type configuration properties for entities.
 * 
 */

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SenseFramework.Data.EntityFramework.EntityBases;

namespace SenseFramework.Data.EntityFramework.TypeConfigurationBase
{
    /// <summary>
    /// Base class of EntityTypeConfigurations
    /// </summary>
    /// <typeparam name="TEntity">Type of the Entity</typeparam>
    /// <typeparam name="TPrimaryKey">PrimaryKey of the entity</typeparam>
    public class EntityTypeConfigurationBase<TEntity,TPrimaryKey> : EntityTypeConfiguration<TEntity> 
        where TEntity : Entity<TPrimaryKey> 
        where TPrimaryKey : struct
    {
        public EntityTypeConfigurationBase()
        {
            HasKey(x => x.Id);

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CreatedDateTime).HasColumnName("CreationTime");
        }

        public EntityTypeConfigurationBase(string tableName)
        {
            HasKey(x => x.Id);

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CreatedDateTime).HasColumnName("CreationTime");

            ToTable(Schema.Prefix  + tableName.ToUpperInvariant());
        }

        public EntityTypeConfigurationBase(string tableName, string schemaName)
        {
            HasKey(x => x.Id);

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CreatedDateTime).HasColumnName("CreationTime");

            ToTable(Schema.Prefix  + tableName.ToUpperInvariant(),schemaName);
        }
    }
}
