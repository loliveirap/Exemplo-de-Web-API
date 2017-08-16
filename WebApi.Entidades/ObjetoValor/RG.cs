using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entidades.ObjetoValor
{
    public class RG
    {
        protected internal virtual string Tipo { get; set; }
        public virtual string Numero { get; set; }
                
        public virtual string OrgaoEmissor { get; set; }

        public virtual DateTime? Expedicao { get; set; }

        public virtual string UF { get; set; }

        private Certidao _certidao;
        public virtual Certidao Certidao
        {
            get { return _certidao; }
            set { _certidao = value ?? new Certidao(); }
        }

        public string CPF { get; set; }

        public RG()
        {
            this.Tipo = "RG";
            this.Certidao = new Certidao();
        }
    }
}
