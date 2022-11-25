using DomainLayer.Models.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerMongoDB.IServices
{
    public interface IOrderingServices
    {
        Task<List<HrOrders>> GetAsync(int EmployeeId);
        Task<HrOrders> Add(HrOrders order);
    }
}
