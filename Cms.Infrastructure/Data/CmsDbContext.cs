using Cms.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Infrastructure.Data
{
    public class CmsDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public CmsDbContext(DbContextOptions options):base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PostTagConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        }
    }
    public class BloggingContextFactory : IDesignTimeDbContextFactory<CmsDbContext> 
    {
        public CmsDbContext CreateDbContext(string[] args) 
        {
            var optionsBuilder = new DbContextOptionsBuilder<CmsDbContext>();
            optionsBuilder.UseSqlServer(@"");
            return new CmsDbContext(optionsBuilder.Options);
        }
    }
}
