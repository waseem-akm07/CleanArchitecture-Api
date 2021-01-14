using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CleanArchitecture.Core.Model
{
    public class Employee
    {
        public Employee()
        {
            Details = new HashSet<Details>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Salary { get; set; }

        [InverseProperty("Employee_")]
        public virtual ICollection<Details> Details { get; set; }

    }
}
