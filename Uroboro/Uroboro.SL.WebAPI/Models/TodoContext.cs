using Microsoft.EntityFrameworkCore;
using Uroboro.Common.Models;

namespace Uroboro.SL.WebAPI.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
