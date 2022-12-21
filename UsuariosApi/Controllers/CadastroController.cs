using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Data.Request;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private CadastroServices _cadastroService;

        public CadastroController(CadastroServices cadastroService)
        {
            _cadastroService = cadastroService;
        }

        [HttpPost]
        public IActionResult CadastraUsuario([FromBody] CreateUsuarioDto createDto)
        {

            //TODO chamar o service
            Result resultado = _cadastroService.CadastroUsuario(createDto);

            if (resultado.IsFailed)
            {
                return StatusCode(500);
            }

            return Ok(resultado.Successes);
        }

        //[HttpPost("/ativa")]
        [HttpGet("/ativa")]
        public IActionResult AtivaContaUsuario([FromQuery] AtivaContaRequest request)
        {
            //[FromBody] AtivaContaRequest request

            Result resultado = _cadastroService.AtivaContaUsuario(request);

            if(resultado.IsFailed)
            {
                return StatusCode(500);
            }

            return Ok(resultado.Successes);
        }
    }
}
