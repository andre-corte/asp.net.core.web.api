using Aula.Domain.Entidades;
using Aula.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aula.Infra.Data.Repository
{
    public class UsuarioRepository : BaseRepository, IUsuarioRepostory
    {
        public IEnumerable<Usuario> Listar(Usuario obj)
        {
            string sql = $"select * from Usuario";

            return base.Listar<Usuario>(sql, obj);
        }

        public Usuario Login(Usuario obj)
        {
            string sql = $"select * from Usuario where Usuario = @Usuario and Senha = @Senha;";

            return base.Obter<Usuario>(sql, obj);
        }

        public Usuario Obter(Usuario obj)
        {
            string sql = $"select * from Usuario " +
                $"where (@Id <> 0 or Id = @Id) and (@Email is null or Email = @Email);";

            return base.Obter<Usuario>(sql, obj);
        }

        public void Adicionar(Usuario obj)
        {
            string sql = $"insert into Usuario (Nome, Email, Senha, DataCadastro, ResponsavelCadastro, Ativo) " +
                $"values (@Nome, @Email, @Senha, @DataCadastro, @ResponsavelCadastro, @Ativo);";

            base.AdicionarOuAtualizar<Usuario>(sql, obj);
        }

        public void Atualizar(Usuario obj)
        {
            string sql = $"update Usuario set " +
                $"Nome = @Nome," +
                $"Email = @Email," +
                $"Senha = @Senha," +
                $"Ativo = @Ativo " +
                $"where Id = @id;";

            base.AdicionarOuAtualizar<Usuario>(sql, obj);
        }

        public void Remover(Usuario obj)
        {
            string sql = $"delete from Usuario where Id = @Id;";
            base.AdicionarOuAtualizar<Usuario>(sql, obj);
        }
    }
}
