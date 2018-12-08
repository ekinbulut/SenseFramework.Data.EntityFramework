/*
 * Project : SenseFramework - Database module
 * Author : Ekin Bulut 
 * Date : 25.02.2017
 * 
 * Desc : Unit of work for Entity Framework. Managenet of dbcontext for transaction.
 * 
 *        ! STILL IN DEVELOPMENT !
 * 
 */

using System;
using Castle.Core.Logging;
using Castle.DynamicProxy;
using SenseFramework.Core.IoC;
using SenseFramework.Data.EntityFramework.Context;
using SenseFramework.Data.EntityFramework.Repositories;

namespace SenseFramework.Data.EntityFramework.Attributes
{
    public class UnitOfWork<T, TPrimaryKey>: IUnitOfWork<T, TPrimaryKey> where T: EntityBases.Entity<TPrimaryKey> where TPrimaryKey :struct
    {
        private readonly BaseContext _context;
        private readonly ILogger _logger;

        public UnitOfWork()
        {
            _context = IoCManager.Container.Resolve<BaseContext>();
            _logger = IoCManager.Container.Resolve<ILogger>();
        }

        public IRepository<T, TPrimaryKey> GetGetRepository()
        {
            return IoCManager.Container.Resolve<IRepository<T,TPrimaryKey>>();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}