﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dating_App.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dating_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ValuesController(ApplicationContext context)
        {
            _context = context;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
           var values = await _context.Values.ToListAsync();
           return Ok(values);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value = await _context.Values.SingleOrDefaultAsync(v => v.Id == id);
            if(value == null)
            {
                return NotFound();
            }

            return Ok(value);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
