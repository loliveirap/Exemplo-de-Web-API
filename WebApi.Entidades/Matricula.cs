using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entidades
{
    public class Matricula
    {
        public virtual Aluno Aluno { get; set; }

        public virtual Disciplina Disciplina { get; set; }

        public virtual string Turma { get; set; }

        public DateTime DataMatricula { get; set; }

        public virtual decimal? Ano { get; set; }

        public virtual decimal? Periodo { get; set; }

        public virtual decimal? Serie { get; set; }

        public virtual string Situacao { get; set; }

        public IEnumerable<Nota> Notas { get; set; }
    }
}
