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
    public class DodatekController : ControllerBase
    {
        private s17194Context _context;
        public DodatekController(s17194Context context)
        {
            _context = context;
        }
        public IActionResult getDodateki()
        {
            return Ok(_context.Dodatek.ToList());
        }
        [HttpGet("{id:int}")]
        public IActionResult getDodatek(int id)
        {
            var dodatek = _context.Dodatek.FirstOrDefault(d => d.Id == id);
            if (dodatek == null)
                return NotFound();
            else
            return Ok(dodatek);
        }
    }
}