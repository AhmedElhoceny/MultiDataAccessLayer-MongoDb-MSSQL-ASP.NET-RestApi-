using DomainLayer.DTOs.Request;
using DomainLayer.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.IServices.HrServices;

namespace MultiDataAccessLayers.Areas.Hr
{
    [Area("HR")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "HR")]
    public class HrController : ControllerBase
    {
        private IEmployeeDepartmentService _employeeDepartmentService { get; set; }
        public HrController(IEmployeeDepartmentService employeeDepartmentService)
        {
            _employeeDepartmentService = employeeDepartmentService;
        }
        [HttpGet("/Hr/GetEmployees/{DepartmentId}")]
        public async Task<IActionResult> GetEmployees(int DepartmentId)
        {
            var data = await _employeeDepartmentService.GetEmployeesByDepartment(DepartmentId);
            return Ok(data);
        }
        [HttpGet("/Hr/GetOrdersByEmployees/{EmployeeId}")]
        public async Task<IActionResult> GetOrdersByEmployees(int EmployeeId)
        {
            var data = await _employeeDepartmentService.GetOrdersByEmployeeId(EmployeeId);
            return Ok(data);
        }
        [HttpPost("/Hr/AddOrderToEmployee")]
        public async Task<IActionResult> AddOrder(AddOrderToEmployeeRequest model)
        {
            var data = await _employeeDepartmentService.AddOrderToEmployee(model);
            return Ok(data);
        }
    }
}
