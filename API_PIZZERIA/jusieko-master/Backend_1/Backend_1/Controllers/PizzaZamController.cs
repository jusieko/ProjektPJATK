using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend_1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend_1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PizzaZamController : ControllerBase
    {
        private s17194Context _context;
        public PizzaZamController(s17194Context context)
        {
            _context = context;
        }
        public IActionResult getPizzas()
        {
            return Ok(_context.PizzaZamowienie.ToList());
        }
        [HttpGet("{id:int}")]
        public IActionResult getPizza(int id)
        {
            var pizza = _context.PizzaZamowienie.FirstOrDefault(d => d.Id == id);
            if (pizza == null)
                return NotFound();
            else
                return Ok(pizza);
        }
    }
}