using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class EmployeeUpdateEntity
    {
        public long EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
