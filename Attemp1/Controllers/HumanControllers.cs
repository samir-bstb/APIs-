using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Attemp1.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace Attemp1.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/human")]
    [ApiController]
    public class HumanControllers : ControllerBase
    {
        private readonly AppDBContext _context;
        public HumanControllers(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var humans = _context.Human.ToList();
            return Ok(humans);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var human = _context.Human.Find(id);
            if (human == null)
            {
                return NotFound();
            }
            return Ok(human);
        }

    }

    
}