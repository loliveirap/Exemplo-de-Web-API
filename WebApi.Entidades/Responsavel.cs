using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entidades.ObjetoValor;

namespace WebApi.Entidades
{
    public class Responsavel
    {
        public virtual string Id { get; set; }

        public virtual Pessoa Pessoa { get; set; }

        public virtual string Nome { get; set; }

        private RG _rg;
        public virtual RG RG
        {
            get { return _rg; }
            set { _rg = value ?? new RG(); }
        }

        private Endereco _endereco;
        public virtual Endereco Endereco
        {
            get { return _endereco; }
            set { _endereco = value ?? new Endereco(); }
        }

        public virtual string Sexo { get; set; }

        public virtual string EstadoCivil { get; set; }
    }
}
