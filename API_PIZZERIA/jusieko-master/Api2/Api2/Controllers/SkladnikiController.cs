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
    public class SkladnikiController : ControllerBase
    {
        private s17194Context _context;
        public SkladnikiController(s17194Context context)
        {
            _context = context;
        }
        public IActionResult getSkladniki()
        {
            return Ok(_context.SkladDod.ToList());
        }
    }
}
