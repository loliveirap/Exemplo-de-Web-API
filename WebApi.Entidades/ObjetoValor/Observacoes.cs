using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entidades.ObjetoValor
{
    public class Observacoes
    {
        public virtual string Email { get; set; }
        public virtual string MailBox { get; set; }
        public virtual DateTime? Data { get; set; }
        public virtual string Observacao { get; set; }
        public virtual decimal? Renda { get; set; }
        public virtual string NecessidadeEspecial { get; set; }
        public virtual string CorRaca { get; set; }
        public virtual string DividaBiblioteca { get; set; }
        public virtual string EnviarEmail { get; set; }
    }
}
