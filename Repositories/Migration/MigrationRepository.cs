/*
 * Project : SenseFramework - Database module
 * Author : Ekin Bulut 
 * Date : 24.02.2017
 * 
 * Desc : Repository for migration entity.
 * 
 */

using System.Data.Entity;
using SenseFramework.Data.EntityFramework.Entities;

namespace SenseFramework.Data.EntityFramework.Repositories.Migration
{
    public class MigrationRepository : EfRepositoryBase<EMigration, int>, IMigrationRepository
    {
        public MigrationRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
