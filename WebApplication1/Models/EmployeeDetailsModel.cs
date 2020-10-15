using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class EmployeeDetailsModel :EmployeeDetailsUpdateModel
    {
        public int DepartmentId { get; set; }
        public bool IsDisabled { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
