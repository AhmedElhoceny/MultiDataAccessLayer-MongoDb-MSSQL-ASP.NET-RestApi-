using AutoMapper;
using DataAccessLayerMongoDB.IServices;
using DomainLayer.DTOs.Request;
using DomainLayer.DTOs.Responses;
using DomainLayer.IRepositories;
using DomainLayer.Models.HR;
using ServicesLayer.IServices.HrServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.HrServices
{
    public class EmployeeDepartmentService : IEmployeeDepartmentService
    {
        private IMapper _mapper { get; set; }
        private IBaseRepository<HrEmployee> _baseRepository { get; set; }
        private IOrderingServices _orderingServices { get; set; }
        public EmployeeDepartmentService(IMapper mapper , IBaseRepository<HrEmployee> baseRepository , IOrderingServices orderingServices)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
            _orderingServices = orderingServices;
        }
        public async Task<List<EmployeeResponse>> GetEmployeesByDepartment(int DepartmentId)
        {
            var data = (await _baseRepository.GetAllData(filter : x => x.DepartmentEmployees.Any(x => x.Department_Id == DepartmentId))).ToList();
            return _mapper.Map<List<EmployeeResponse>>(data);
        }

        public async Task<AddOrderToEmployeeResponse> AddOrderToEmployee(AddOrderToEmployeeRequest model)
        {
            var ResData = await _orderingServices.Add(_mapper.Map<HrOrders>(model));
            return _mapper.Map<AddOrderToEmployeeResponse>(ResData);
        }

        public async Task<List<AddOrderToEmployeeResponse>> GetOrdersByEmployeeId(int EmployeeId)
        {
            return _mapper.Map<List<AddOrderToEmployeeResponse>>( await _orderingServices.GetAsync(EmployeeId));   
        }
    }
}
