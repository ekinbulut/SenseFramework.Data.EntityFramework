/*
 * Project : SenseFramework - Database
 * Author : Ekin Bulut 
 * Date : 25.02.2017
 * 
 * Desc : This interface should be implemented on an occasion of building data transfer. 
 */
namespace SenseFramework.Data.EntityFramework.DataMigrations
{
    public interface IDataMigration
    {
        /// <summary>
        /// Name of the data migration. Should be unique.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Start the data migration.
        /// </summary>
        void Migrate();
    }
}
