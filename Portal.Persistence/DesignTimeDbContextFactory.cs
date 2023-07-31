using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Portal.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PortalDbContext>
    {
        public PortalDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<PortalDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer("Server=10.10.10.60;Database=PortalDb;User Id=sa;Password=123456;Trusted_Connection=True;TrustServerCertificate=True;");
            return new PortalDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
