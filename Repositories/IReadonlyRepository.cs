using System.Collections.Generic;
using SenseFramework.Data.EntityFramework.EntityBases;

namespace SenseFramework.Data.EntityFramework.Repositories
{
    /// <summary>
    /// Readonly Repository Impl.
    /// </summary>
    /// <typeparam name="T">Entity</typeparam>
    public interface IReadonlyRepository<TEntity,TPrimaryKey> where TEntity : IEntity<TPrimaryKey>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetOne(TPrimaryKey id);

    }
}