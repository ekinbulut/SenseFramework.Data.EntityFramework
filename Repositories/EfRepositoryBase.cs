/*
 * Project : SenseFramework - Database module
 * Author : Ekin Bulut 
 * Date : 25.02.2017
 * 
 * Desc : Repository pattern base class. All concrete repositories should implement this class.
 * 
 */

using System;
using System.Collections.Generic;
using System.Data.Entity;
using SenseFramework.Data.EntityFramework.Context;

namespace SenseFramework.Data.EntityFramework.Repositories
{
    using EntityBases;

    public abstract class EfRepositoryBase<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> 
        where TEntity : Entity<TPrimaryKey>
    {
        protected readonly BaseContext DbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="EfRepositoryBase{T}"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        protected EfRepositoryBase(BaseContext dbContext)
        {
            DbContext = dbContext;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetAll()
        {
            //Logger.Info("Get");
            return DbContext.Set<TEntity>();
        }

        /// <summary>
        /// Gets the one.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public virtual TEntity GetOne(TPrimaryKey id)
        {
            return DbContext.Set<TEntity>().Find(id);
        }

        /// <summary>
        /// Creates the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public virtual TEntity CreateEntity(TEntity entity)
        {
            //Logger.Info("Insert");

            entity.CreatedDateTime = DateTime.Now;
            var t = DbContext.Set<TEntity>().Add(entity);

            int result = DbContext.SaveChanges();

            return result > 0 ? t : null;
        }

        /// <summary>
        /// Deletes the entity.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual bool DeleteEntity(TPrimaryKey id)
        {
            //TODO: Delete operation
            //Logger.Warn("Delete :" + id);

            var entity = DbContext.Set<TEntity>().Find(id);
            DbContext.Set<TEntity>().Remove(entity);


            int result = DbContext.SaveChanges();

            return result > 0;
        }

        /// <summary>
        /// Updates the entity.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual bool UpdateEntity(TEntity entity)
        {

            var getone = GetOne(entity.Id);

            DbContext.Entry(getone).CurrentValues.SetValues(entity);
            DbContext.Entry(getone).State = EntityState.Modified;

            int result = DbContext.SaveChanges();

            return result > 0;

        }
    }

    public abstract class EfRepositoryBase<TEntity, TPrimaryKey, TContext> : IRepository<TEntity, TPrimaryKey>
        where TEntity : Entity<TPrimaryKey>
        where TContext : BaseContext
    {
        protected readonly TContext DbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="EfRepositoryBase{T}"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        protected EfRepositoryBase(TContext dbContext)
        {
            DbContext = dbContext;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetAll()
        {
            //Logger.Info("Get");
            return DbContext.Set<TEntity>();
        }

        /// <summary>
        /// Gets the one.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public virtual TEntity GetOne(TPrimaryKey id)
        {
            return DbContext.Set<TEntity>().Find(id);
        }

        /// <summary>
        /// Creates the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public virtual TEntity CreateEntity(TEntity entity)
        {
            //Logger.Info("Insert");

            entity.CreatedDateTime = DateTime.Now;
            var t = DbContext.Set<TEntity>().Add(entity);

            int result = DbContext.SaveChanges();

            return result > 0 ? t : null;
        }

        /// <summary>
        /// Deletes the entity.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual bool DeleteEntity(TPrimaryKey id)
        {
            //TODO: Delete operation
            //Logger.Warn("Delete :" + id);

            var entity = DbContext.Set<TEntity>().Find(id);
            DbContext.Set<TEntity>().Remove(entity);


            int result = DbContext.SaveChanges();

            return result > 0;
        }

        /// <summary>
        /// Updates the entity.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual bool UpdateEntity(TEntity entity)
        {

            var getone = GetOne(entity.Id);

            DbContext.Entry(getone).CurrentValues.SetValues(entity);
            DbContext.Entry(getone).State = EntityState.Modified;

            int result = DbContext.SaveChanges();

            return result > 0;

        }
    }
}
