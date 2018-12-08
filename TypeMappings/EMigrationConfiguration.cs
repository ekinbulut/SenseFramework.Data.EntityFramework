/*
 * Project : SenseFramework - Database module
 * Author : Ekin Bulut 
 * Date : 25.02.2017
 * 
 * Desc : Type configuration class of Migrations. Provides mapping for database.
 * 
 */
using SenseFramework.Data.EntityFramework.Entities;
using SenseFramework.Data.EntityFramework.TypeConfigurationBase;

namespace SenseFramework.Data.EntityFramework.TypeMappings
{
    public class EMigrationConfiguration : EntityTypeConfigurationBase<EMigration, int>
    {
        public EMigrationConfiguration() : base("Migrations")
        {
            Property(x => x.Name).HasMaxLength(25);
            //ToTable("Migrations");
        }
    }
}
