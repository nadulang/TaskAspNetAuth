using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using TaskAuth.Models;
using Microsoft.AspNetCore.Authorization;

namespace TaskAuth.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/Customer")]

    public class CustomersController : ControllerBase
    {
        private readonly TheCustomerContext _context;

        public CustomersController(TheCustomerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var cust = _context.CustomersDatas;
            return Ok(new {message = "success retrieve data", status = true, data = cust});
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try 
            {
            var getit = _context.CustomersDatas.First(e => e.id == id);
            _context.SaveChanges();
            return Ok(new {message = "success retrieve data", status = true, data = getit});
            }

            catch (Exception)
            {
                return NotFound();
            }

        }

        [HttpPost]
        public IActionResult Post(Customer custs)
        {
            var customer = custs.data.attributes;
            _context.CustomersDatas.Add(customer);
            var time = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds;
            customer.created_at = (long)time;
            customer.update_at = (long)time;
            _context.SaveChanges();
            return Ok(new {message = "success retrieve data", status = true, data = customer});
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
            var del = _context.CustomersDatas.First(e => e.id == id );
            _context.CustomersDatas.Remove(del);
            _context.SaveChanges();
            return Ok("Your data has been deleted.");
            }

            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Customer cust)
        {
            var customer = cust.data.attributes;

            try
            {
            var g = _context.CustomersDatas.Find(id);
            g.full_name = customer.full_name;
            g.username = customer.username;
            g.email = customer.email;
            g.phone_number = customer.phone_number;
            var time = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds;
            g.update_at = (long)time;
            _context.SaveChanges();
            return Ok(new {message = "success retrieve data", status = true, data = customer});
            }

            catch (Exception)
            {
                return NotFound();
            }
        }
    }

    public class Customer
    {
        public Attributes data { get; set; }
    }

    public class Attributes
    {
        public CustomersData attributes { get; set; }
    }
}