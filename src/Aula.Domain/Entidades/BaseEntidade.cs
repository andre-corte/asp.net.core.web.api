using System;
using System.Collections.Generic;
using System.Text;

namespace Aula.Domain.Entidades
{
    public abstract class BaseEntidade
    {
        public long Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public string ResponsavelCadastro { get; set; }
        public bool Ativo { get; set; }
    }
}
