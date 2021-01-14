using CleanArchitecture.Application.Interface;
using CleanArchitecture.Application.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CleanArchitecture.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CleanArchContext>(option => option.UseSqlServer(
                configuration.GetConnectionString("Default"),
                b => b.MigrationsAssembly(typeof(CleanArchContext).Assembly.FullName)));

            services.AddScoped<ICleanArchContext>(provider => provider.GetService<CleanArchContext>());
            services.AddScoped<IRepository, Repository>();
        }
    }
}
