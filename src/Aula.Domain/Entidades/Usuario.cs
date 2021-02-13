using System;
using System.Collections.Generic;
using System.Text;

namespace Aula.Domain.Entidades
{
    public class Usuario : BaseEntidade
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
