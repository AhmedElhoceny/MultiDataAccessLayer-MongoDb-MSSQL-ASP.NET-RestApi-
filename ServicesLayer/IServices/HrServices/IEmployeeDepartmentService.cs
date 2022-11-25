using DomainLayer.DTOs.Request;
using DomainLayer.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.IServices.HrServices
{
    public interface IEmployeeDepartmentService
    {
        Task<List<EmployeeResponse>> GetEmployeesByDepartment(int DepartmentId);
        Task<AddOrderToEmployeeResponse> AddOrderToEmployee(AddOrderToEmployeeRequest model);
        Task<List<AddOrderToEmployeeResponse>> GetOrdersByEmployeeId(int EmployeeId);
    }
}
