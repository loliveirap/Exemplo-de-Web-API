using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entidades.ObjetoValor
{
    public class TituloEleitoral
    {
        public virtual string Numero { get; set; }
        public virtual string Zona { get; set; }

        public virtual string Secao { get; set; }

        public virtual DateTime? Expedicao { get; set; }

        public Municipio Municipio { get; set; }
    }
}
