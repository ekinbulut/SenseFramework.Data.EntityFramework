/*
 * Project : SenseFramework - Database module
 * Author : Ekin Bulut 
 * Date : 25.02.2017
 * 
 * Desc : Readonly Repository pattern base class. All concrete readonly repositories should implement this class.
 * 
 */

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SenseFramework.Data.EntityFramework.Context;

namespace SenseFramework.Data.EntityFramework.Repositories
{
    using EntityBases;

    public abstract class EfReadonlyRepositoryBase<TEntity, TPrimaryKey> : IReadonlyRepository<TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey>
    {
        protected readonly BaseContext Context;

        /// <summary>
        /// Initializes a new instance of the <see cref="EfReadonlyRepositoryBase{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        protected EfReadonlyRepositoryBase(BaseContext context)
        {
            Context = context;
        }


        public IEnumerable<TEntity> GetAll()
        {
            //Logger.Info("Readonly Repository - Get All Method");
            return Context.Set<TEntity>().ToList();
        }

        public TEntity GetOne(TPrimaryKey id)
        {
            return Context.Set<TEntity>().Find(id);
        }
    }


    public abstract class EfReadonlyRepositoryBase<TEntity, TPrimaryKey, TContext> : IReadonlyRepository<TEntity, TPrimaryKey> 
        where TEntity : Entity<TPrimaryKey> 
        where TContext : BaseContext
    {
        protected readonly TContext Context;

        /// <summary>
        /// Initializes a new instance of the <see cref="EfReadonlyRepositoryBase{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        protected EfReadonlyRepositoryBase(TContext context)
        {
            Context = context;
        }


        public IEnumerable<TEntity> GetAll()
        {
            //Logger.Info("Readonly Repository - Get All Method");
            return Context.Set<TEntity>().ToList();
        }

        public TEntity GetOne(TPrimaryKey id)
        {
            return Context.Set<TEntity>().Find(id);
        }
    }
}
