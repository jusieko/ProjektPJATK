using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrzekaskiController : ControllerBase
    {
        private s17194Context _context;
        public PrzekaskiController(s17194Context context)
        {
            _context = context;
        }
        public IActionResult getDodatki()
        {
            return Ok(_context.Przekaski.ToList());
        }
    }
}