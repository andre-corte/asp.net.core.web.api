using Aula.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aula.Domain.Validation
{
    public static class UsuarioValidation
    {
        public static bool Validar(Usuario usuario)
        {
            List<string> vs = new List<string>(0);

            if (string.IsNullOrWhiteSpace(usuario.ResponsavelCadastro))
            {
                vs.Add("Responsável cadastro");
            }

            if (string.IsNullOrWhiteSpace(usuario.Email))
            {
                vs.Add("E-mail");
            }

            if (string.IsNullOrWhiteSpace(usuario.Senha))
            {
                vs.Add("Senha");
            }

            if (usuario.DataCadastro == default)
            {
                vs.Add("Data cadastro");
            }

            if (vs.Any())
            {
                throw new Exception($"Informe os campos abaixo: {Environment.NewLine}{string.Join(", ", vs)}");
            }

            return true;
        }
    }
}
