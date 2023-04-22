using XUnit.Service.Data.Config;
using Microsoft.EntityFrameworkCore;
using XUnit.Service.Data.Domain;

namespace XUnit.Service.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Cms Builder

            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ContentConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            #endregion


        }


        #region Cms DbSet

        public DbSet<Author> Author { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Content> Content { get; set; }
        public DbSet<Role> Role { get; set; }

        #endregion

    }
}
