using hello_docker.Model;
using Microsoft.EntityFrameworkCore;


namespace hello_docker
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public  DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserId);
                entity.Property(u => u.Name).HasDefaultValue("docker");
                entity.HasIndex(u => u.UserName).IsUnique();
            });
        }
    }
}
