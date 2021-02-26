using Aula.Domain.Entidades;
using Aula.Domain.Interfaces.Repository;
using Aula.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Aula.Domain.Validation;

namespace Aula.Services.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepostory _usuarioRepository;

        public UsuarioService(IUsuarioRepostory usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
         
        public void Adicionar(Usuario obj)
        {
            obj.Validar();

            _usuarioRepository.Adicionar(obj);
        }

        public void Atualizar(Usuario obj)
        {
            obj.ValidarAtualizar();

            _usuarioRepository.Atualizar(obj);
        }

        public IEnumerable<Usuario> Listar(Usuario obj)
        {
            return _usuarioRepository.Listar(obj);
        }

        public Usuario Login(Usuario obj)
        {
            return _usuarioRepository.Login(obj);
        }

        public Usuario Obter(Usuario obj)
        {
            return _usuarioRepository.Obter(obj);
        }
        
        public Usuario ObterPor(Usuario obj)
        {
            return _usuarioRepository.ObterPor(obj);
        }

        public void Remover(Usuario obj)
        {
            obj.ValidarRemover();

            _usuarioRepository.Remover(obj);
        }
    }
}
