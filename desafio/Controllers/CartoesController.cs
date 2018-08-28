using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using desafio.Data.Models;
using desafio.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace desafio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartoesController : ControllerBase
    {
        private CartaoService _cartaoService;
        private ILogger _logger;
        public CartoesController(CartaoService cartaoService, ILoggerFactory loggerFactory)
        {
            _cartaoService = cartaoService;
            _logger = loggerFactory.CreateLogger(typeof(CartoesController));
        }


        [Authorize("Bearer")]
        [ProducesResponseType(200, Type = typeof(Cartao))]
        [ProducesResponseType(404)]
        [HttpGet("{numeroCartao}")]
        public ActionResult<Cartao> ConsultarPorNumero(string numeroCartao)
        {
            try
            {
                _logger.LogInformation("Consultado o cartão: {cartao}", numeroCartao);

                var cartao = _cartaoService.ObterporNumeroCartao(numeroCartao);
                _logger.LogInformation("Retornado os dados do cartão: {@cartao}", cartao);
                return cartao;

            }
            catch (Exception e)
            {

                return NotFound(e);
            }
        }
        [HttpPost("novo")]
        [ProducesResponseType(200, Type = typeof(Cartao))]
        [ProducesResponseType(404)]
        public ActionResult EnviarLote(Cartao cartao)
        {
            try
            {
                _logger.LogInformation("Novo cartão");
                var retornoCartao = _cartaoService.InserirCartao(cartao);
                return Ok(retornoCartao);

            }
            catch (Exception e)
            {

                return NotFound(e);
            }
        }


        //[Authorize("Bearer")]
        [HttpPost("lote")]
        public ActionResult<int> EnviarLote(CartaoLote cartaoLote)
        {
            try
            {
                _logger.LogInformation("Recebido arquivo de lote");
                var cartao = _cartaoService.InserirCartaoLote(cartaoLote.arquivo);
                return Ok();

            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }
    }
}
