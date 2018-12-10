
[![Build status](https://ci.appveyor.com/api/projects/status/y2g1w1epmdggnh5h/branch/master?svg=true)](https://ci.appveyor.com/project/ekinbulut/senseframework-data-entityframework/branch/master)


This framework is built to help development of n-tier applications by giving service oriented architectural platform.
You may built your apps by implementing of certain libraries. 
Each library provides components for easiy implementations of repository pattern, unit of work, mapping, logging, aop etc.


### Samples

To use this module efficiently follow these steps.

After adding SenseFramework.Data.EntityFramework to your project, create your entities by implementing **Entity<>** class.

```csharp
public class CustomEntity : Entity<int>
{

}
```

Then you need to implement your repositories by using **EfRepositoryBase<TEntity,TPrimaryKey>** and **IRepository<TEntity,TPrimaryKey>**

```csharp

public interface ICustomRepository : IRepository<CustomEntity, int>
{

}

public class CustomRepository : EfRepositoryBase<CustomEntity, int>, ICustomRepository
{
    public CustomRepository(BaseContext dbContext) : base(dbContext)
    {
    }
}
```

Finally you should apply **EntityTypeConfigurationBase<TEntity,TPrimaryKey>** abstraction to your EntityConfiguration.

```csharp
public class CustomEntityTypeMapping : EntityTypeConfigurationBase<CustomEntity, int>
{
    public CustomEntityTypeMapping(string tableName) : base(tableName)
    {
        HasKey(t => t.Id);
        Property(p => p.CreatedDateTime).HasColumnName("CREATED");
    }
}
```

Do NOT forget to implement your own Context by implementing **BaseContext** class.

```csharp

    public class CustomContext : BaseContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // DO NOT FORGET TO REGISTER YOUR CONFIGURATION. EF CODE FIRST WON'T WORK IF SO.
            modelBuilder.Configurations.Add(new CustomEntityTypeMapping("CUSTOMS"));
        }
    }

```


Now you may apply Code first migrations with commands; 
* Enable-Migrations 
* Add-Migration 
* Update-Database.


### Notes

Do not forget to add a connectionstring to your app.config.

```xml
    <add name="Context" connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=DemoDb;User Id=demo;Password=******;" providerName="System.Data.SqlClient"/>
```

### Options

You may use optional keys;

```xml
   <appSettings>
    <add key="SchemaName" value="dbo" />  // schema name of your databae
    <add key="TablePrefix" value="" />    // adds the keyword before the table name
  </appSettings>
```
