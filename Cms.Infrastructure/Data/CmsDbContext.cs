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
        public CmsDbContext(DbContextOptions options):base(options) { }
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
