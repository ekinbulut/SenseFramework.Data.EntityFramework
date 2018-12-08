/*
 * Project : SenseFramework - Database module
 * Author : Ekin Bulut 
 * Date : 24.02.2017
 * 
 * Desc : This class is the custom context class which implements DbContext of entity framework.
 * 
 */

using System;
using System.Data.Entity;
using SenseFramework.Core.Messaging;
using SenseFramework.Data.EntityFramework.Conventions;

namespace SenseFramework.Data.EntityFramework.Context
{
    public abstract class BaseContext : DbContext , IDbContext
    {
        protected BaseContext() : base("Context")
        {
        }

        /// <summary>
        /// This method creates all database schema by the configuration of TypeConfigurations.
        /// You should give the path names of the TypeConfiguration Assemblies in the app.config file.
        /// </summary>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new DateTimeConvention());
        }

        /// <summary>
        /// Override of SaveChanges of default save changes method.
        /// </summary>
        /// <returns>0 if exception, 1 for successfull commit</returns>
        public override int SaveChanges()
        {
            using (var transaction = Database.BeginTransaction())
            {
                try
                {
                    base.SaveChanges();
                    transaction.Commit();

                    return 1;
                }
                catch (Exception error)
                {
                    transaction.Rollback();
                    Messanger.Logger.Error(error.Message);


                    return 0;
                }
            }
        }
    }
}
