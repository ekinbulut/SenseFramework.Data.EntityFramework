/*
 * Project : SenseFramework - Database
 * Author : Ekin Bulut 
 * Date : 25.02.2017
 * 
 * Desc : A migration entity. Will be created as a table in the database. 
 */


namespace SenseFramework.Data.EntityFramework.Entities
{
    using EntityBases;

    public class EMigration : Entity<int>
    {
        public string Name { get; set; }
    }
}
