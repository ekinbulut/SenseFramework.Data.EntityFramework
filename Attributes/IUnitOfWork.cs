/// <summary>
/// Unit of work interface
/// </summary>
namespace SenseFramework.Data.EntityFramework.Attributes
{
    using Repositories;

    public interface IUnitOfWork<T, TPrimaryKey>
        where T : EntityBases.Entity<TPrimaryKey>
        where TPrimaryKey : struct
    {
        /// <summary>
        /// Gets the entity repository.
        /// </summary>
        /// <value>
        /// The entity repository.
        /// </value>
        IRepository<T, TPrimaryKey> EntityRepository { get; }

        /// <summary>
        /// Saves the changes. Commit to database
        /// </summary>
        void SaveChanges();
    }
}