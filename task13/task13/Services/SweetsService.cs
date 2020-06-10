using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task13.DTO;
using task13.Entities;

namespace task13.Services
{
    public class SweetsService : ISweetsDBService
    {
        SweetsDBContext context;
        public void InitContext(SweetsDBContext _context)
        {
            context = _context;
        }

        public OrdersResponse getOrders(string name)
        {
            if (name == null)
                return new OrdersResponse
                {
                    orders = context.Orders.Select(order => new OrdersDTO{
                        IdOrder = order.IdOrder,
                        DateAccepted = order.DateAccepted,
                        DateFinished = order.DateFinished,
                        confList = (from o in context.Orders
                                    join c_o in context.Confectionery_Orders on o.IdOrder equals c_o.IdOrder
                                    join c in context.Confectioneries on c_o.IdConfectionery equals c.IdConfectionery
                                    where o.IdOrder == order.IdOrder
                                    select c).ToList()
                    }).ToList(),
                    Error = ""
                };
            else
            {
                if (!context.Customers.Any(c => c.Name == name))
                    return new OrdersResponse
                    {
                        orders = null,
                        Error = "No customer with such name"
                    };
                return new OrdersResponse
                {
                    orders = (from o in context.Orders
                        join c in context.Customers on o.IdCustomer equals c.IdCustomer
                        where c.Name == name
                        select o)
                    .Select(order => new OrdersDTO
                    {
                        IdOrder = order.IdOrder,
                        DateAccepted = order.DateAccepted,
                        DateFinished = order.DateFinished,
                        confList = (from o in context.Orders
                                    join c_o in context.Confectionery_Orders on o.IdOrder equals c_o.IdOrder
                                    join c in context.Confectioneries on c_o.IdConfectionery equals c.IdConfectionery
                                    where o.IdOrder == order.IdOrder
                                    select c).ToList()
                    }).ToList(),
                    Error = ""
                };
            }

        }

        public OrdersResponse addOrder(int idCustomer, AddOrderRequest req)
        {
            if (!context.Customers.Any(c => c.IdCustomer == idCustomer))
                return new OrdersResponse
                {
                    orders = null,
                    Error = "No customer with such id"
                };
            foreach (ConfectioneryDTO con in req.Confectionery)
            {
                if (!context.Confectioneries.Any(c => c.Name == con.Name))
                    return new OrdersResponse
                    {
                        orders = null,
                        Error = "no such confectionery as " + con.Name
                    };
            }

            Order newOrder = new Order
            {
                DateAccepted = req.DateAccepted,
                DateFinished = DateTime.Now,
                Notes = req.Notes,
                IdEmployee = 1,
                IdCustomer = idCustomer
            };
            context.Add<Order>(newOrder);
            context.SaveChanges();

            foreach (ConfectioneryDTO con in req.Confectionery)
            {
                Confectionery_Order newC_Order = new Confectionery_Order
                {
                    IdOrder = context.Orders.Max(o => o.IdOrder),
                    IdConfectionery = context.Confectioneries.Where(c => c.Name == con.Name).First().IdConfectionery,
                    Quantity = con.Quantity,
                    Notes = con.Notes
                };
                context.Add<Confectionery_Order>(newC_Order);
                context.SaveChanges();
            }

            return getOrders(null);
        }

    }
}
