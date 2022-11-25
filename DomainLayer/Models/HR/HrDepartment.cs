using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.HR
{
    public class HrDepartment
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<HrDepartmentEmployee> DepartmentEmployees { get; set; }
    }
}