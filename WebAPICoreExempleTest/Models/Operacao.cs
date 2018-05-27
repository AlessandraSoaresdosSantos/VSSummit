using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPICoreExempleTest.Models
{
    public class Operacao
    {
        public int OperacaoId { get; set; }

        public int GrupoOperacaoId { get; set; }

        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
