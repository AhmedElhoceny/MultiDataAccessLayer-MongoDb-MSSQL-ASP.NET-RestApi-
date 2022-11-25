using DomainLayer.Models.HR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerEntityFrameWork.ContextDbs
{
    public class DbContextSystem : DbContext
    {
        public DbContextSystem(DbContextOptions<DbContextSystem> options) : base(options){}
        public DbSet<HrEmployee> Employees { get; set; }
        public DbSet<HrDepartment> Departments { get; set; }
    }
}
