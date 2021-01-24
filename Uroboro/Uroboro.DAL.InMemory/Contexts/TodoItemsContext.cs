using Microsoft.EntityFrameworkCore;
using Uroboro.Common.Models;

namespace Uroboro.DAL.InMemory.Contexts
{
    public class TodoItemsContext : DbContext
    {
        public TodoItemsContext(DbContextOptions<TodoItemsContext> options) : base(options)
        {
        }

        // Another way to customize builder options without DI
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        IConfigurationRoot configuration = new ConfigurationBuilder()
        //           .SetBasePath(Directory.GetCurrentDirectory())
        //           .AddJsonFile("appsettings.json")
        //           .Build();
        //        var connectionString = configuration.GetConnectionString("DbCoreConnectionString");
        //        optionsBuilder.UseSqlServer(connectionString);
        //    }
        //}

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
