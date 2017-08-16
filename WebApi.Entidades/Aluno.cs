using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entidades
{
    public class Aluno
    {
        public string Id { get; set; }

        public string Nome { get; set; }

        public string IngressoEm { get; set; }

        public string TipoIngresso { get; set; }

        public Curriculo Curriculo { get; set; }

        public decimal Serie { get; set; }

        public string SituacaoAluno { get; set; }

        public UnidadeFisica Unidade { get; set; }

        public IEnumerable<Historico> Historicos { get; set; }

        public IEnumerable<Nota> Notas { get; set; }

        public IEnumerable<Aviso> Avisos { get; set; }
    }
}
