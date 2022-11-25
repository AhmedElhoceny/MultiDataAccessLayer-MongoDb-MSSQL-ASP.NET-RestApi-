using AutoMapper;
using DomainLayer.DTOs.Request;
using DomainLayer.DTOs.Responses;
using DomainLayer.Models.HR;

namespace MultiDataAccessLayers.Profiler
{
    public class HrProfiler: Profile
    {
        public HrProfiler()
        {
            CreateMap<HrEmployee, EmployeeResponse>()
                .ReverseMap();
            CreateMap<AddOrderToEmployeeRequest, HrOrders>()
                .ReverseMap();
            CreateMap<HrOrders, AddOrderToEmployeeResponse>()
                .ReverseMap();
        }
    }
}
