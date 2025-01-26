using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Hmn_API.Models;
using Hmn_API.Services;

namespace Hmn_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //Api controller enables opinionated behaviors that make it
    //easier to build web APIs. Some behaviors inlude parmeter source
    //inference, attribute routing, and model validation error-handling enhancements


    public class HumanController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Human>> GetAll() => HumanServices.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Human> Get(int id)
        {
            var human = HumanServices.Get(id);

            if (human == null) return NotFound();

            return human;
        }

        [HttpPost]
        public IActionResult Create(Human human)
        {
            HumanServices.Create(human);
            return CreatedAtAction(nameof(Create), new { id = human.Id }, human);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var human = HumanServices.Get(id);
            if (human is null) return NotFound();
            HumanServices.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Human human)
        {
            if (id != human.Id) return BadRequest();
            var existingHuman = HumanServices.Get(id);
            if (existingHuman is null) return NotFound();
            HumanServices.Update(human);
            return NoContent();
        }
    }
}

    