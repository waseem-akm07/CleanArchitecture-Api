using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.DTO
{
    public class EmployeeReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Salary { get; set; }
        public string FatherName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
