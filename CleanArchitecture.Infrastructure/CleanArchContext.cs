using CleanArchitecture.Application.Interface;
using CleanArchitecture.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure
{
    public class CleanArchContext : DbContext, ICleanArchContext
    {
        public CleanArchContext() 
        { }

        public CleanArchContext(DbContextOptions<CleanArchContext> options):base(options)
        { }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Details> Details { get; set; }

        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
