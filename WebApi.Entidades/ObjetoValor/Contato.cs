using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entidades.ObjetoValor
{
    public class Contato
    {
        public Telefone Telefone { get; set; }

        public Telefone Celular { get; set; }

        public Telefone Fax { get; set; }

        public Telefone Recado { get; set; }

        public Contato()
        {
            this.Telefone = new Telefone();
            this.Celular = new Telefone();
            this.Fax = new Telefone();
            this.Recado = new Telefone();
        }
    }
}
