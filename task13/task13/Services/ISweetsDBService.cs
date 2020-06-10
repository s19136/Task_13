using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task13.DTO;
using task13.Entities;

namespace task13.Services
{
    public interface ISweetsDBService
    {
        void InitContext(SweetsDBContext context);
        OrdersResponse getOrders(string Name);
        OrdersResponse addOrder(int idCustomer, AddOrderRequest req);
    }
}
