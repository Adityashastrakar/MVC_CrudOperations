using Microsoft.EntityFrameworkCore;
using MVC_CrudOperations.Models;

namespace MVC_CrudOperations.Data
{
    public class ApplicationContext:DbContext
    {
      public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
