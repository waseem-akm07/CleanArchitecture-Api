using CleanArchitecture.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interface
{
    public interface IRepository
    {
        Task<bool> AddEmployee(EmployeeReturnDto employeeDto);
        Task<bool> UpdateEmployee(EmployeeReturnDto dto);
        Task<IEnumerable<EmployeeReturnDto>> GetAllEmployee();
        Task<EmployeeReturnDto> GetEmployee(int id);
        Task<bool> DeleteEmployee(int id);
    }
}
