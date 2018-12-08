using Castle.DynamicProxy;
using SenseFramework.Data.EntityFramework.Repositories;

namespace SenseFramework.Data.EntityFramework.Attributes
{
    public interface IUnitOfWork<T, TPrimaryKey> 
        where T : EntityBases.Entity<TPrimaryKey> 
        where TPrimaryKey : struct
    {
        IRepository<T, TPrimaryKey> GetGetRepository();

        void SaveChanges();
    }
}