using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using desafio.Data.Interfaces;
using desafio.Data.Models;
using desafio.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace desafio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private CartaoService _cartaoService;

        public ValuesController(CartaoService cartaoService)
        {
            _cartaoService = cartaoService;
        }
        // GET api/values
        [HttpGet]
        [Authorize("Bearer")]
        public ActionResult<IEnumerable<string>> Get()
        {
            var cartao = _cartaoService.ObterporNumeroCartao("123457890123");

            return new string[] { "value1", "value2", cartao.NumCartao };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
