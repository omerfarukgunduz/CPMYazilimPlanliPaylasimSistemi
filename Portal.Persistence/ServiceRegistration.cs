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

           
            services.AddScoped<IEventWriteRepository, EventWriteRepository>();
            services.AddScoped<IEventReadRepository, EventReadRepository>();
            

            services.AddScoped<IEmployeeReadRepository , EmployeeReadRepository>();
            services.AddScoped<IEmployeeWriteRepository , EmployeeWriteRepository>();
            
            services.AddScoped<IPostReadRepository , PostReadRepository>();
            services.AddScoped<IPostWriteRepository , PostWriteRepository>();

            services.AddScoped<ISocialMediaAccountReadRepository , SocialMediaAccountReadRepository>();
            services.AddScoped<ISocialMediaAccountWriteRepository , SocialMediaAccountWriteRepository>();

            services.AddScoped<ISocialMediaAccountTypeReadRepository , SocialMediaAccountTypeReadRepository>();
            services.AddScoped<ISocialMediaAccountTypeWriteRepository , SocialMediaAccountTypeWriteRepository>();

            services.AddScoped<IUserReadRepository , UserReadRepository>();
            services.AddScoped<IUserWriteRepository , UserWriteRepository>();

            
        }
     
    }
}
