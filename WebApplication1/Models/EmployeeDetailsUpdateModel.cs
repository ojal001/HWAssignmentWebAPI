using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
   public  class EmployeeDetailsUpdateModel
    {
        public long EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int? UpdatedBy { get; set; }
        
    }
}
