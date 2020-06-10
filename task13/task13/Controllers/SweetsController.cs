using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task13.DTO;
using task13.Entities;
using task13.Services;

namespace task13.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class SweetsController : ControllerBase
    {
        private ISweetsDBService _service;

        public SweetsController(ISweetsDBService service, SweetsDBContext context)
        {
            _service = service;
            _service.InitContext(context);
        }

        [HttpGet]
        public IActionResult getOrders(string name)
        {
            var res = _service.getOrders(name);
            if (res.orders != null)
                return Ok(res.orders);
            else
                return BadRequest(res.Error);
        }

        [HttpPost("{idCustomer}", Name = "addOrder")]
        public IActionResult addOrder(int idCustomer, AddOrderRequest req)
        {
            var res = _service.addOrder(idCustomer, req);
            if (res.orders != null)
                return Ok(res.orders);
            else
                return BadRequest(res.Error);
        }
    }
}
