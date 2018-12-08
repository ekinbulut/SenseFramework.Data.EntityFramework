/*
 * Project : SenseFramework - Database
 * Author : Ekin Bulut 
 * Date : 25.02.2017
 * 
 * Desc : Convention class to change DateTime properties into datetime2 type in the database.       
 */
using System;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SenseFramework.Data.EntityFramework.Conventions
{
    internal class DateTimeConvention : Convention
    {
        public DateTimeConvention()
        {
            this.Properties<DateTime>().Configure(c=>c.HasColumnType("datetime2"));
        }
    }
}
