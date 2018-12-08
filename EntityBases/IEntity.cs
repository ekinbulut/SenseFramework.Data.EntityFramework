using System;

namespace SenseFramework.Data.EntityFramework.EntityBases
{
    public interface IEntity<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
        DateTime CreatedDateTime { get; set; }

    }
}
