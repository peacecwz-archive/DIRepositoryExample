using DIRepositoryExample.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DIRepositoryExample.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
    }
}