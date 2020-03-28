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
    public class NapojController : ControllerBase
    {
        private s17194Context _context;
        public NapojController(s17194Context context)
        {
            _context = context;
        }
        public IActionResult getNapoje()
        {
            return Ok(_context.Napoje.ToList());
        }
    }
}
}