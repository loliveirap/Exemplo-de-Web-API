using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entidades.ObjetoValor
{
    public class Endereco
    {
        public virtual string Numero { get; set; }

        public virtual string Logradouro { get; set; }

        public virtual string Complemento { get; set; }

        public virtual string Bairro { get; set; }

        public virtual string CEP { get; set; }

        private Municipio _municipio;
        public virtual Municipio Municipio
        {
            get { return _municipio; }
            set { _municipio = value ?? new Municipio(); }
        }
        
        public virtual string Pais { get; set; }

        private Contato _contato;
        public virtual Contato Contato
        {
            get { return _contato; }
            set { _contato = value ?? new Contato(); }
        }

        public virtual string Confirmado { get; set; }

        public Endereco()
        {
            this.Contato = new Contato();
        }
    }
}
