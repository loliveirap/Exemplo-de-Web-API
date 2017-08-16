using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entidades.ObjetoValor
{
    public class Certidao
    {
        public virtual string Numero { get; set; }
        public virtual string Pai { get; set; }
        public virtual string Mae { get; set; }

        public virtual string Data { get; set; }

        public virtual string Pais { get; set; }

        public virtual string Nacionalidade { get; set; }

        public virtual string Folha { get; set; }

        public virtual string Livro { get; set; }

        public virtual string Cartorio { get; set; }

        public virtual DateTime? Emissao { get; set; }

        public Municipio Municipio { get; set; }

        public string Raca { get; set; }
    }
}
