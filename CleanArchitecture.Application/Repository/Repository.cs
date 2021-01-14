using CleanArchitecture.Application.Interface;
using CleanArchitecture.Core.DTO;
using CleanArchitecture.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Repository
{
    public class Repository: IRepository
    {
        private readonly ICleanArchContext _context;
        public Repository(ICleanArchContext context)
        {
            _context = context;
        }

        public async Task<bool> AddEmployee(EmployeeReturnDto employeeDto)
        {
            Employee employee = new Employee();
            Details details = new Details();

            employee.Name = employeeDto.Name;
            employee.Salary = employeeDto.Salary;
            _context.Employee.Add(employee);
            await _context.SaveChanges();

            details.FatherName = employeeDto.FatherName;
            details.PhoneNumber = employeeDto.PhoneNumber;
            details.Employee_Id = employee.Id;
            _context.Details.Add(details);
            await _context.SaveChanges();
            return true;
        }

        public async Task<bool> UpdateEmployee(EmployeeReturnDto dto)
        {
            Employee employee =await _context.Employee.Where(x => x.Id == dto.Id).FirstOrDefaultAsync();
            Details details = await _context.Details.Where(x => x.Employee_Id == dto.Id).FirstOrDefaultAsync();

            employee.Name = dto.Name;
            employee.Salary = dto.Salary;
            _context.Employee.Update(employee);

            details.FatherName = dto.FatherName;
            details.PhoneNumber = dto.PhoneNumber;
            _context.Details.Update(details);
            await _context.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<EmployeeReturnDto>> GetAllEmployee()
        {
            var employee = await _context.Employee.Include(x => x.Details)
                            .Select(y => new EmployeeReturnDto
                            {
                                Id = y.Id,
                                Name = y.Name,
                                Salary = y.Salary,
                                FatherName = y.Details.Select(z=>z.FatherName).FirstOrDefault(),
                                PhoneNumber = y.Details.Select(z=>z.PhoneNumber).FirstOrDefault()
                            }).ToListAsync();
            return employee;
        }

        public async Task<EmployeeReturnDto> GetEmployee(int id)
        {
            var employee = await _context.Employee.Include(x => x.Details)
                             .Where(x=>x.Id == id)
                            .Select(y => new EmployeeReturnDto
                            {
                                Id = y.Id,
                                Name = y.Name,
                                Salary = y.Salary,
                                FatherName = y.Details.Select(z => z.FatherName).FirstOrDefault(),
                                PhoneNumber = y.Details.Select(z => z.PhoneNumber).FirstOrDefault()
                            }).SingleOrDefaultAsync();
            return employee;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            Employee employee = _context.Employee.Find(id);
            _context.Employee.Remove(employee);
            await _context.SaveChanges();
            return true;
        }
    }
}
