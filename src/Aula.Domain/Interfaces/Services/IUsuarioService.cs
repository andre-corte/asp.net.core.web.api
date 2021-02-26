using Aula.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aula.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        IEnumerable<Usuario> Listar(Usuario obj);
        Usuario Obter(Usuario obj);
        Usuario ObterPor(Usuario obj);
        Usuario Login(Usuario obj);
        void Adicionar(Usuario obj);
        void Atualizar(Usuario obj);
        void Remover(Usuario obj);
    }
}
