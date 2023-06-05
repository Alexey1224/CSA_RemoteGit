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

        //private static List<Laptop> _memCache = new List<Laptop>();
        private static IStorage<Laptop> _LaptopList = new LaptopList();

        [HttpGet]
        public ActionResult<IEnumerable<Laptop>> Get()
        {
            //return _LaptopList;
            return Ok(_LaptopList.All);
        }

        [HttpGet("{id}")]
        //public ActionResult<Laptop> Get(int id)
        public ActionResult<Laptop> Get(Guid id)
        {
            //if (_LaptopList.Count <= id) throw new IndexOutOfRangeException("Нет такого у нас");

            return _LaptopList[id];
        }

        [HttpPost]
        public void Post([FromBody] Laptop value)
        {
            _LaptopList.Add(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Laptop value)
        {
            if (_LaptopList.Count <= id) throw new IndexOutOfRangeException("Нет такого у нас");

            _LaptopList[id] = value;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (_LaptopList.Count <= id) throw new IndexOutOfRangeException("Нет такого у нас");

            _LaptopList.RemoveAt(id);
        }
    }
}