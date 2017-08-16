using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entidades
{
    public class Municipio
    {        
        public virtual string Id { get; set; }

        public virtual string Nome { get; set; }

        public virtual string UF { get; set; }

        public virtual string Estado { get; set; }
    }
}
