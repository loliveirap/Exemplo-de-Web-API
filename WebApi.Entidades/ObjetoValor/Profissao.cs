using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entidades.ObjetoValor
{
    public class Profissao
    {
        public virtual string Numero { get; set; }
        public virtual string Nome { get; set; }

        public virtual string Cargo { get; set; }

        public virtual string ConselhoRegional { get; set; }

        public virtual string Empresa { get; set; }

        public virtual string Serie { get; set; }

        public virtual DateTime? Expedicao { get; set; }

        private Endereco _endereco;
        public virtual Endereco Endereco
        {
            get { return _endereco; }
            set { _endereco = value ?? new Endereco(); }
        }
        
        public virtual string Email { get; set; }

        private Contato _contato;
        public virtual Contato Contato
        {
            get { return _contato; }
            set { _contato = value ?? new Contato(); }
        }

        public virtual string Area { get; set; }

        public virtual string Especializacao { get; set; }

        public string UF { get; set; }
    }
}
