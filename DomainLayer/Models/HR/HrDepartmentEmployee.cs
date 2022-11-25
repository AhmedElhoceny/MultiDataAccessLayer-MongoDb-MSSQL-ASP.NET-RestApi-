using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.HR
{
    public class HrDepartmentEmployee
    {
        [Key]
        public int Id { get; set; }
        public int Employee_Id { get; set; }
        [ForeignKey(nameof(Employee_Id))]
        public HrEmployee Employee { get; set; }
        public int Department_Id { get; set; }
        [ForeignKey(nameof(Department_Id))]
        public HrDepartment Department { get; set; }
    }
}
