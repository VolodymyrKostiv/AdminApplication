﻿using System.Collections.Generic;

namespace AdminApplication.Models
{
    public partial class EmployeeType
    {
        public EmployeeType()
        {
            Employees = new HashSet<Employee>();
        }

        public int EmployeeTypeId { get; set; }
        public string Title { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
