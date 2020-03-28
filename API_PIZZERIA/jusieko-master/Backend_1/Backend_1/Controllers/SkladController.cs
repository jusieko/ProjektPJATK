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
    public class SkladController : ControllerBase
    {
        private s17194Context _context;
        public SkladController(s17194Context context)
        {
            _context = context;
        }
        public IActionResult getSkladniki()
        {
            return Ok(_context.PizzaSklad.ToList());
        }
    }
}