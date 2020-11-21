using Microsoft.EntityFrameworkCore;

namespace DbLOL
{
    class ApplicationContext : DbContext
    {
        public DbSet<Champion> Champions { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Role> Roles { get; set; }

        public ApplicationContext()
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Champion>().Property(p => p.Name).IsRequired(); // Обязательное свойство имя
            modelBuilder.Entity<Role>().Property(p => p.Name).IsRequired();     //
            modelBuilder.Entity<Region>().Property(p => p.Name).IsRequired();   //
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=LoL;Trusted_Connection=True;");
        }
    }
}
