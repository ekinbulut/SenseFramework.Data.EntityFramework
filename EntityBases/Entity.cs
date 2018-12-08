/*
 * Project : SenseFramework - Database module
 * Author : Ekin Bulut 
 * Date : 24.02.2017
 * 
 * Desc : This class is a base class which provides initial properties for entities.
 *        All entities should implement this entity.
 * 
 */
using System;

namespace SenseFramework.Data.EntityFramework.EntityBases
{
    /// <summary>
    /// Base class of all entites
    /// </summary>
    /// <typeparam name="TPrimaryKey">Primary Key of entity</typeparam>
    public class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
