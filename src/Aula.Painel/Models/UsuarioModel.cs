using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula.Painel.Models
{
    public class UsuarioModel
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("senha")]
        public string Senha { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("dataCadastro")]
        public DateTime DataCadastro { get; set; }

        [JsonProperty("responsavelCadastro")]
        public string ResponsavelCadastro { get; set; }

        [JsonProperty("ativo")]
        public bool Ativo { get; set; }
    }
}
