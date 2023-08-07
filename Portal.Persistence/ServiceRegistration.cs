using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Portal.Application.Repositories;
using Portal.Persistence;
using Portal.Persistence.Context;
using Portal.Persistence.Repositories;
using System;
using System.Data.SqlClient;

namespace ControlPortal.Persistence
{
    public static class ServiceRegistiration
    {

        public static void AddPersistenceServices(this IServiceCollection services)
        {
            
            services.AddDbContext<PortalDbContext>(options=>options.UseSqlServer("Server=10.10.10.60;Database=PortalDb;User Id=sa;Password=123456;TrustServerCertificate=True;"));

           

            services.AddScoped<IUserReadRepository , UserReadRepository>();
            services.AddScoped<IUserWriteRepository , UserWriteRepository>();

            
        }
     
    }
}
