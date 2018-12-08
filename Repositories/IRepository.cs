using System.Collections.Generic;
using SenseFramework.Data.EntityFramework.EntityBases;

namespace SenseFramework.Data.EntityFramework.Repositories
{
    /// <summary>
    /// Repository for all CRUD's
    /// </summary>
    /// <typeparam name="T">Entity</typeparam>
    public interface IRepository<TEntity,TPrimaryKey> where TEntity : IEntity<TPrimaryKey>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetOne(TPrimaryKey id);
        TEntity CreateEntity(TEntity entity);
        bool DeleteEntity(TPrimaryKey id);
        bool UpdateEntity(TEntity entity);
    }
}
