using Aula.Domain.Entidades;
using Aula.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula.WebAPI.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/public/usuario")]
    [ApiController]
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("todos")]
        public IActionResult Listar()
        {
            IEnumerable<Usuario> usuario = _usuarioService.Listar(new Usuario
            {
                Email = GetSearchParameters("email"),
                Id = GetSearchIntParameters("id")
            });
            return Ok(usuario);
        }

        [HttpGet("obter")]
        public IActionResult Obter(string id = null, string email = null)
        {
            Usuario usuario = _usuarioService.Obter(new Usuario
            {
                Email = email,
                Id = string.IsNullOrWhiteSpace(id) ? 0 : int.Parse(id)
            });
            return Ok(usuario);
        }

        [HttpGet("obter-por/{id}")]
        public IActionResult ObterPor(int id)
        {
            Usuario usuario = _usuarioService.ObterPor(new Usuario
            {
                Id = id
            });
            return Ok(usuario);
        }

        [HttpPost("cadastrar")]
        public IActionResult Post(Usuario usuario)
        {
            _usuarioService.Adicionar(usuario);
            return Ok("Registro salvo com sucesso");
        }

        [HttpPut("atualizar")]
        public IActionResult Put(Usuario usuario)
        {
            _usuarioService.Atualizar(usuario);
            return Ok("Registro atualizado com sucesso");
        }

        [HttpDelete("remover/{id}")]
        public IActionResult Delete(int id)
        {
            _usuarioService.Remover(new Usuario { Id = id });
            return Ok("Registro removido com sucesso");
        }
    }
}
