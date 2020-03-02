using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using TaskAuth.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

namespace TaskAuth.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    
    public class ProductsController : ControllerBase
    {
        private readonly TheCustomerContext _context;
        public ProductsController(TheCustomerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var pro = _context.ProductsData;
            return Ok(new {message = "success retrieve data", status = true, data = pro});
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
            var pro = _context.ProductsData.First(e => e.id == id);
            _context.SaveChanges();
            return Ok(new {message = "success retrieve data", status = true, data = pro});
            }

            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Post(Productnya pros)
        {
            var p = pros.data.attributes;
            _context.ProductsData.Add(p);
            var time = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds;
            p.created_at = (long)time;
            p.updated_at = (long)time;
            _context.SaveChanges();
            return Ok(new {message = "success retrieve data", status = true, data = p});
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
            var del = _context.ProductsData.First(e => e.id == id);
            _context.ProductsData.Remove(del);
            _context.SaveChanges();
            return Ok("The product has been deleted.");
            }

            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Productnya pros)
        {
            var p = pros.data.attributes;
            try
            {
               var f = _context.ProductsData.Find(id);
               f.name = p.name;
               f.price = p.price;
               var time = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds;
               f.updated_at = (long)time;
               _context.SaveChanges();
               return Ok(new {message = "success retrieve data", status = true, data = p});
            }

            catch (Exception)
            {
                return NotFound();
            }

        }

    }

    public class Productnya
    {
        public Attribute data { get; set; }
    }

    public class Attribute
    {
        public Products attributes { get; set; }
    }
}