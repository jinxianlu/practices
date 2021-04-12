using Microsoft.EntityFrameworkCore;

namespace DbContextChangeTrackerDemo
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public override int SaveChanges()
        {

            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Deleted)
                {
                    ((ISoftDeleted)entry.Entity).IsDeleted = true;
                    entry.State = EntityState.Modified;
                }
            }

            return base.SaveChanges();
        }

        public DbSet<Foo> Foos { get; set; }

    }
}