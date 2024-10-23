using Microsoft.EntityFrameworkCore;

namespace WebApiWithOData
{
    public class PersonDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Department> Departments { get; set; }

        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .EnableSensitiveDataLogging();
        }
    }
}
