using Microsoft.EntityFrameworkCore;
using Portal.Domain.Entities;
using Portal.Domain.Entities.Common;

namespace Portal.Persistence.Context
{
    public class PortalDbContext : DbContext
    {
        public PortalDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Etkinlik> etkinliks { get; set; }
        public DbSet<Role> roles { get; set; }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //ChangeTracker : Entityler üzerinden yapılan değişikliklerin veya yeni eklenen şeylerin yakalanmasını sağlayan proportydir.Update operasyonlarında track edilen verileri yakalayıp elde etmemizi sağlar

            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                if (data.State == EntityState.Modified)
                {
                    data.Entity.UpdatedDate = DateTime.Now;
                }
                if (data.State == EntityState.Added)
                {
                    if(data.Entity.Id ==null) 
                    {
                        data.Entity.Id = Guid.NewGuid();
                    }
                    
                    data.Entity.CreatedDate = DateTime.Now;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }


    }
}
