using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend_1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PizzaMenuController : ControllerBase
    {
        private s17194Context _context;
        public PizzaMenuController(s17194Context context)
        {
            _context = context;
        }
        public IActionResult getPizzas()
        {
            return Ok(_context.PizzaMenu.ToList());
        }
        [HttpPut("{Id:int}")]
        public IActionResult Update(PizzaMenu updatedpizza,int Id)
        {
            if (_context.PizzaMenu.Count(e => e.Id == Id)==0)
            {
                return NotFound();
            }
            _context.PizzaMenu.Attach(updatedpizza);
            _context.Entry(updatedpizza).State =EntityState.Modified;
            _context.SaveChanges();
            return Ok(updatedpizza);

        }
         [HttpPost]
         public object Create(PizzaMenu pizza)
        {
            _context.PizzaMenu.Add(pizza);
            _context.SaveChanges();
            return StatusCode(201, pizza);
        }

        [HttpDelete("{Id:int}")]
        public IActionResult Delete(int id)
        {
            var pizza = _context.PizzaMenu.FirstOrDefault(e => e.Id == id);
            if (pizza == null)
            {
                return NotFound();
            }
            _context.PizzaMenu.Remove(pizza);
            _context.SaveChanges();
            return Ok(pizza);
        }
        
        [HttpGet("{id:int}")]
        public IActionResult getPizza(int id)
        {
            var pizza = _context.PizzaMenu.FirstOrDefault(d => d.Id == id);
            if (pizza == null)
                return NotFound();
            else
                return Ok(pizza);
        }
    }
}