using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using CSA.IStorage;
using CSA.Model;

namespace CSA
{
    [Route("api/[controller]")]
    [ApiController]
    public class Lab1Controller : ControllerBase
    {


        //private static IStorage<Laptop> _LaptopList = new LaptopList();
        private IStorage<Laptop> _LaptopList;

        public Lab1Controller(IStorage<Laptop> LaptopList)
        {
            _LaptopList = LaptopList;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Laptop>> Get()
        {

            return Ok(_LaptopList.All);
        }

        [HttpGet("{id}")]

        public ActionResult<Laptop> Get(Guid id)
        {

            if (_LaptopList.Has(id)) return NotFound("No such");

            return Ok(_LaptopList[id]);
        }

        [HttpPost]

        public IActionResult Post([FromBody] Laptop value)
        {
            var validationResult = value.Validate();

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            _LaptopList.Add(value);

            return Ok($"{value.ToString()} has been added");
        }

        [HttpPut("{id}")]

        public IActionResult Put(Guid id, [FromBody] Laptop value)
        {

            if (_LaptopList.Has(id)) return NotFound("No such");

            var validationResult = value.Validate();

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            var previousValue = _LaptopList[id];
            _LaptopList[id] = value;
            return Ok($"{previousValue.ToString()} has been updated to {value.ToString()}");
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(Guid id)
        {

            if (_LaptopList.Has(id)) return NotFound("No such");

            var valueToRemove = _LaptopList[id];
            _LaptopList.RemoveAt(id);
            return Ok($"{valueToRemove.ToString()} has been removed");
        }
    }
}