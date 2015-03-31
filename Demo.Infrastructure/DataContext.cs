using System.Data.Entity;

namespace Demo.Infrastructure
{
    /// <summary>
    /// Контекст, через который происходит работа с БД
    /// </summary>
    public class DataContext : DbContext, IDbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Couch> Couches { get; set; }

        /// <summary>
        /// В этом методе можно повлиять на структуру данных в БД
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Fluent API
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