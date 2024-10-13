using CSharpNotes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CSharpNotes.Data;

// Entity Framework is used to connect database tables directly
// We can select and update records of the table without using SQL
// DbContext is the base class to be inherited
// OnConfiguring is the method of DbContext class, which is called when we create an instance of DbContext class, this can be used for providing connection details (To give database details)
/* OnModelCreating is the method of DbContext class, which is called when we try to access table (Used to give table details within database)
     .Entity<> (Class to Table Mapping)
*/
// DBSet (To Store data from database)
/* Common Methods
DbContext.Model.Add
DbContext.SaveChanges
DbContext.Model.ToList
*/
public class DataEntity : DbContext
{
    private IConfiguration config;

    public DataEntity(IConfiguration config)
    {
        this.config = config;
    }

    // This is required only we want to access table records in another class, so it should be public, records are stored in DbSet
    public DbSet<Computer> Computer{get;set;}

    // override keyword is used to indicate override method
    protected override void OnConfiguring(DbContextOptionsBuilder options){
        if(!options.IsConfigured)
            options.UseSqlServer(config.GetConnectionString("mssql-connection"), options => options.EnableRetryOnFailure());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        // To Set the Default Schema
        modelBuilder.HasDefaultSchema("ComputerSchema");
        // To Map Model class to the table in database
        modelBuilder.Entity<Computer>().ToTable("Computers").HasKey("ComputerId"); // To Map table and schema
        // If same table name (Computer) is used ToTable is not required
    }
}