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

using Castle.Core.Logging;
using SenseFramework.Core.IoC;

namespace SenseFramework.Data.EntityFramework.Attributes
{
    using Context;
    using Repositories;

    public class UnitOfWork<T, TPrimaryKey> : IUnitOfWork<T, TPrimaryKey>
        where T : EntityBases.Entity<TPrimaryKey>
        where TPrimaryKey : struct
    {
        private readonly BaseContext _context;
        private readonly ILogger _logger;

        public UnitOfWork(BaseContext context, ILogger logger = null)
        {
            _context = context;

            if (logger == null)
            {
                logger = new NullLogger();
            }
            else
            {
                _logger = logger;
            }
        }

        public IRepository<T, TPrimaryKey> EntityRepository
        {
            get
            {
                return IoCManager.Container.Resolve<IRepository<T, TPrimaryKey>>();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}