using System.Data.Entity;

namespace Demo.Infrastructure
{
    public class DataContext : DbContext, IDbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Couch> Couches { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().ToTable("Teams");
            modelBuilder.Entity<Team>().HasKey(c => c.Id);
            modelBuilder.Entity<Team>().Property(c => c.City).IsRequired();
            modelBuilder.Entity<Team>().Property(c => c.Title).HasMaxLength(1000).IsRequired();

            base.OnModelCreating(modelBuilder);
        }

        public IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}