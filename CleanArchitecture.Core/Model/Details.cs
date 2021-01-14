using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CleanArchitecture.Core.Model
{
    public class Details
    {
        [Key]
        public int Id { get; set; }
        public string FatherName { get; set; }
        public string PhoneNumber { get; set; }
        public int Employee_Id { get; set; }

        [ForeignKey(nameof(Employee_Id))]
        [InverseProperty(nameof(Employee.Details))]
        public virtual Employee Employee_ { get; set; }
    }
}
