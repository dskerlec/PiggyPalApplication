using Microsoft.EntityFrameworkCore;
using PiggyPalAPI.Models;

namespace PiggyPalAPI.Data
{
    //The DbContext class is a part of the Entity Framework Core(EF Core) framework,
    //which is an object-relational mapper(ORM) for .NET applications.
    //The DbContext class represents a session with the database,
    //and it allows you to query and save instances of your entities(data models) to and from the database.
    //In your ASP.NET Core project, you typically create a DbContext class
    //that inherits from the Microsoft.EntityFrameworkCore.DbContext class.
    //This class serves as a bridge between your application's domain models
    //(classes that represent data entities) and the underlying database.

    public class PiggyPalDbContext : DbContext
    {
        public PiggyPalDbContext(DbContextOptions<PiggyPalDbContext> options) : base(options)
        {
        }

        // Add DbSet properties for your entities here
        //you'll need to add DbSet properties for each of your data models (entities)
        //that you want to interact with the database.
        //For example, if you have a Purchase model, you would add a DbSet property like this:
        //public DbSet<Purchase> Purchases { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<TransactionModel> Transactions { get; set; }
    }
}
