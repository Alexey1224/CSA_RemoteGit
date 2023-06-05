using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;


namespace CSA
{
    [Route("api/[controller]")]
    [ApiController]
    public class Lab1Controller : ControllerBase
    {
        private static List<Laptop> _memCache = new List<Laptop>();

        [HttpGet]
        public ActionResult<IEnumerable<Laptop>> Get()
        {
            return _memCache;
        }

        [HttpGet("{id}")]
        public ActionResult<Laptop> Get(int id)
        {
            if (_memCache.Count <= id) throw new IndexOutOfRangeException("Нет такого у нас");

            return _memCache[id];
        }

        [HttpPost]
        public void Post([FromBody] Laptop value)
        {
            _memCache.Add(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Laptop value)
        {
            if (_memCache.Count <= id) throw new IndexOutOfRangeException("Нет такого у нас");

            _memCache[id] = value;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (_memCache.Count <= id) throw new IndexOutOfRangeException("Нет такого у нас");

            _memCache.RemoveAt(id);
        }
    }
}