using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTOs.Request
{
    public class AddOrderToEmployeeRequest
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int EmployeeId { get; set; }
    }
}
