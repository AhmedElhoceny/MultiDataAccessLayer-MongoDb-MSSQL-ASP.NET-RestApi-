using DataAccessLayerMongoDB.IServices;
using DataAccessLayerMongoDB.Setting;
using DomainLayer.Models.HR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerMongoDB.Services
{
    public class OrderingServices : IOrderingServices
    {
        private readonly IMongoCollection<HrOrders> _Orders;
        public OrderingServices(IEmployeeDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _Orders = database.GetCollection<HrOrders>(settings.EmployeesCollectionName);
        }
        public async Task<List<HrOrders>> GetAsync(int EmployeeId)
        {
            return await (await _Orders.FindAsync(ord => ord.EmployeeId == EmployeeId)).ToListAsync();
        }
        public async Task<HrOrders> Add(HrOrders order)
        {
           await _Orders.InsertOneAsync(order);
            return order;
        }
    }
}
