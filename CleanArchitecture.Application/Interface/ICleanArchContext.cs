using CleanArchitecture.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interface
{
    public interface ICleanArchContext
    {
        DbSet<Employee> Employee { get; set; }
        DbSet<Details> Details { get; set; }
        Task<int> SaveChanges();
    }
}
